using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody2D rb;

    public GameObject Boss;
    public GameObject Player;

    float target;
    Vector2 moveDir;

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        Player = GameObject.Find("TestPlayer");
        Boss = GameObject.Find("Boss");
=======
        Player = GameObject.Find("Player");
        Boss = GameObject.Find("EnemyTest");
>>>>>>> c600fba3cdc3bc5bfe244449be595d86e51a3cca

        moveDir = (Player.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDir.x, moveDir.y);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Player.GetComponent<PlayerController>().PlayerDamage(Boss.GetComponent<EnemyBehaviour>().EnemyBulletDamage);

            Destroy(gameObject);
        }
    }
}
