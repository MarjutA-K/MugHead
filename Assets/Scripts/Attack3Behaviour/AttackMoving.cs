using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMoving : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float Speed;

    Transform NextPos;
    int PositionIndex;

    // Start is called before the first frame update
    void Start()
    {
        NextPos = Positions[0];
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }

    void MoveObject()
    {
        transform.position = Vector3.MoveTowards(transform.position, NextPos.position, Speed * Time.deltaTime);
    }
}
