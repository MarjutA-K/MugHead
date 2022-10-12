using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    public float speed = 10;
    public Rigidbody2D rb;

    public GameObject Boss;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;

<<<<<<< HEAD
        Player = GameObject.Find("TestPlayer");
        Boss = GameObject.Find("Boss");
=======
        Player = GameObject.Find("Player");
        Boss = GameObject.Find("EnemyTest");
>>>>>>> c600fba3cdc3bc5bfe244449be595d86e51a3cca
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
        if(collision.CompareTag("Boss"))
        {
            Boss.GetComponent<EnemyBehaviour>().EnemyDamage(Player.GetComponent<PlayerController>().bulletDamage);

            Destroy(gameObject);
        }
    }
}
