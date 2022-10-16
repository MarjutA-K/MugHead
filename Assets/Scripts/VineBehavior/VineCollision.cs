using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineCollision : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject vine;
    public GameObject player;
    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            player.GetComponent<PlayerController>().PlayerDamage(boss.GetComponent<EnemyBehaviour>().EnemyBulletDamage);

            print("collision");
        }
    }
}
