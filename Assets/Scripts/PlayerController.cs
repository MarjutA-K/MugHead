using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;
    public Transform feet;
    public LayerMask groundLayers;

    public Transform Bulletspawn;
    public GameObject BulletOBJ;

    private bool FacingRight = true;

    //start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        Instantiate(BulletOBJ, Bulletspawn.position, Bulletspawn.rotation);
    }

    void FlipSprite()
    {
        FacingRight = !FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
