using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack3Behaviour : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody2D rb;
    public GameObject Player;
    public GameObject Boss;

    float target;
    Vector2 Direction;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Boss = GameObject.Find("Boss");
        Direction = (Player.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(Direction.x, 0f) ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Player.GetComponent<PlayerController>().PlayerDamage(Boss.GetComponent<EnemyBehaviour>().EnemyBulletDamage);
            Destroy(gameObject);
        }

        if(collision.CompareTag("CollisionEnd"))
        {
            rb.velocity = transform.right * speed;
        }

        if(collision.CompareTag("CollisionStart"))
        {
            Destroy(gameObject);
        }
    }
}
