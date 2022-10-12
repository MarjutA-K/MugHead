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

    public Animator anim;

    public GameObject Player;

    private bool Phase1 = true;
    private bool Phase2 = false;
    private bool Phase3 = false;

    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = 2.5f;
        nextShoot = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health < 501)
        {
            Phase1 = false;
            Phase2 = true;
        }
    
        if (Health < 251)
        {
            Phase2 = false;
            Phase3 = true;
        }

        if (Phase1 && Player.active)
        {
            anim.SetBool("Phase3", false);
            anim.SetBool("Phase1", true);
            BossShoot();
        }
        else if(Phase2)
        {
            anim.SetBool("Phase1", false);
            anim.SetBool("Phase2", true);
        }
        
        if(Phase3)
        {
            anim.SetBool("Phase2", false);
            anim.SetBool("Phase3", true);
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
