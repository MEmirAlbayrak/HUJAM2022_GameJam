using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    private void Start()
    {
        AssignValues();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public override void Move()
    {
        // var angle = Mathf.Atan2(Target.position.y - transform.position.y, Target.position.x - transform.position.x) *
        //             Mathf.Rad2Deg;
        // transform.rotation = Quaternion.Euler(new Vector3(0, 0 , angle));

        transform.right = Target.position - transform.position;

        transform.position = Vector3.MoveTowards(transform.position, Target.position, moveSpeed);
    }
}