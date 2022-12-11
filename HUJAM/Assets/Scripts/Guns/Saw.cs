using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Saw : Collectable , ICanDealDamage
{
    [SerializeField] float rotateSpeed;
    [SerializeField] Transform sawTransform;

    [SerializeField] float damage;
    public float Damage { get => damage; set => damage = value; }


    void Start()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    
    void FixedUpdate()
    {
        sawTransform.Rotate(Vector3.forward *rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Enemy>() != null)
        {
            DealDamage(Damage,collision.GetComponent<Enemy>());
        }
    }

    public void DealDamage(float damage,Enemy enemy)
    {
        enemy.TakeDamage(damage);
    }
}
