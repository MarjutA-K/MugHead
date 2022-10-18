using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPhase : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float Speed;
    public GameObject JibakuTensei;

    Transform NextPos;
    int PositionIndex;
    float nextAttack;
    float cooldown;

    public GameObject Prefabs;
    public Transform AttackSpawnPlace;

    // Start is called before the first frame update
    void Start()
    {
        NextPos = Positions[0];
        nextAttack = Time.time;
        cooldown = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();

        if(!Prefabs.activeInHierarchy)
        {
            Instantiate(Prefabs, AttackSpawnPlace.position, AttackSpawnPlace.rotation);
        }
    }


    void MoveObject()
    {
        transform.position = Vector3.MoveTowards(transform.position, NextPos.position, Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(Prefabs, AttackSpawnPlace.position, AttackSpawnPlace.rotation);
        transform.position = Vector3.MoveTowards(transform.position, NextPos.position, Speed * Time.deltaTime);
        //Destroy(gameObject);
    }
}

