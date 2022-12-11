using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RangedEnemy : Enemy
{
    [SerializeField] private GameObject[] shootingPoints;
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private float spinSpeed;
    
    private void Start()
    {
        AssignValues();
        StartCoroutine(Attack());
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

    private IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(2f, 4f));
            Instantiate(rocketPrefab, shootingPoints[0].transform);
            Instantiate(rocketPrefab, shootingPoints[1].transform);
        }
    }
}