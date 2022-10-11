using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int Health = 50;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(Health);
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

    IEnumerator ColourChange()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.yellow;
    }
}
