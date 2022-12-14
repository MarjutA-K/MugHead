using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    public int Health = 3;

    private Rigidbody2D rb;
    public Transform feet;
    public LayerMask groundLayers;

    [Space]
    public Transform Bulletspawn;
    public GameObject BulletOBJ;
    public int bulletDamage;

    public int BulletAmount = 5;
    public float ShootCooldown;

    private bool FacingRight = true;

    private GameObject Player;

    Animator animator;

    private GameController gameController;

    //start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        Player = gameObject;

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gameController.playerHealth = Health;
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");


        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Shooting();
        }

        if(moveInput < 0 && FacingRight)
        {
            FlipSprite();
        }
        else if(moveInput > 0 && !FacingRight)
        {
            FlipSprite();
        }
        
        if(moveInput == 0)
        {
            animator.SetBool("IsWalking?", false);
        }

        if (BulletAmount == 0)
        {
            Cooldown();
        }

        StayInWindow();
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(moveInput * speed, rb.velocity.y);

        rb.velocity = movement;
    }

    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

        rb.velocity = movement;
    }

    bool isGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null)
        {
            return true;
        }

        return false;
    }

    void Shooting()
    {
        if(BulletAmount > 0)
        {
            Instantiate(BulletOBJ, Bulletspawn.position, Bulletspawn.rotation);
            BulletAmount -= 1;
        }
    }

    void FlipSprite()
    {
        FacingRight = !FacingRight;

        transform.Rotate(0f, 180f, 0f);

        animator.SetBool("IsWalking?", true);
    }

    public void PlayerDamage(int damage)
    {
        Health -= damage;
        gameController.playerHealth = Health;
        
        GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(HitDetect());

        if (Health <= 0)
        {
            //Destroy(gameObject);
            Player.SetActive(false);
        }
    }

    void Cooldown()
    {
        ShootCooldown -= Time.deltaTime;
        if(ShootCooldown < 0)
        {
            BulletAmount += 5;
            ShootCooldown = 2;
        }
    }

    void StayInWindow()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6f, 6f),
            Mathf.Clamp(transform.position.y, -4f, 4f), transform.position.z);
    }

    IEnumerator HitDetect()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}