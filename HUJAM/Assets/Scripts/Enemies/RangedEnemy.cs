using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RangedEnemy : Enemy
{
   
    [SerializeField] private float spinSpeed;


    private void Awake()
    {
        AssignValues();
        
    }
    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
        transform.Rotate(0f,0f,-spinSpeed, Space.Self);
    }

    public override void Move()
    {
        /*var angle = Mathf.Atan2(Target.position.y - transform.position.y, Target.position.x - transform.position.x) *
                    Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));*/

        transform.position = Vector3.MoveTowards(transform.position, Target.position, moveSpeed);
    }
    public void ResetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

   
}