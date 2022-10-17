using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingAttack : MonoBehaviour
{
    float cooldown;
    float nextAttack;

    public GameObject ChibakuTensei;
    public Transform ChibakuTenseiSpawn;
    public GameObject Player;

    void Start()
    {
        cooldown = 13f;
        nextAttack = Time.time;

    }

    void Update()
    {
        Attacking();
    }

    void Attacking()
    {
        if(Time.time > nextAttack)
        {
            Instantiate(ChibakuTensei, ChibakuTenseiSpawn.position, ChibakuTenseiSpawn.rotation);
            nextAttack = Time.time + cooldown;
        }
    }
}
