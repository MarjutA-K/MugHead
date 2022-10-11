using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    public float speed = 10;
    public Rigidbody2D rb;

    public GameObject Boss;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;

        Boss = GameObject.Find("EnemyTest");
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
            Boss.GetComponent<EnemyBehaviour>().EnemyDamage(10);

            Destroy(gameObject);
        }
    }
}
