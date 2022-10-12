using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int Health = 50;
    public int EnemyBulletDamage = 1;

    float shootCooldown;
    float nextShoot;

    public GameObject Bullet;
    public Transform BulletSpawn;

    public bool phase1 = true;
    public bool phase2 = false;
    public bool phase3 = false;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = 2.5f;
        nextShoot = Time.time;

        animator = GetComponent<Animator>();

        phase1 = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(Health < 501)
        {
            phase1 = false;
            phase2 = true;
        }
        if(Health < 251)
        {
            phase2 = false;
            phase3 = true;
        }

        if(phase1)
        {
            BossShoot();
        }
        else if(phase2)
        {
            animator.SetBool("Phase2", true);
        }
        else if (phase3)
        {
            animator.SetBool("Phase2", false);
            animator.SetBool("Phase3", true);
        }
    }

    public void EnemyDamage(int damage)
    {
        Health -= damage;
        GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(ColourChange());

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void BossShoot()
    {
        if (Time.time > nextShoot)
        {
            Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
            nextShoot = Time.time + shootCooldown;
        }
    }

    IEnumerator ColourChange()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
