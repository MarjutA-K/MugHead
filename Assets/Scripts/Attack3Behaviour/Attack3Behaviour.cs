using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack3Behaviour : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody2D rb;
    public GameObject Player;

    float target;
    Vector2 Direction;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Direction = (Player.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(Direction.x, 0f) ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if(collision.CompareTag("CollisionEnd"))
        {
            Destroy(gameObject);
        }
    }
}
