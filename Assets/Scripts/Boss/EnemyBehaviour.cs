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


    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = 2.5f;
        nextShoot = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        print(Health);
        BossShoot();
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
        GetComponent<SpriteRenderer>().color = Color.yellow;
    }
}
