using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] internal EnemyValuesSO valuesSO;
    protected float health;
    protected float moveSpeed;
    protected float rotationSpeed;
    protected float damage;

    public static Transform Target;
    public GameObject explodeParticle;

    private void OnEnable()
    {
        Target = GameObject.FindWithTag("Player").transform;
    }

    protected void AssignValues()
    {
        health = valuesSO.health;
        moveSpeed = valuesSO.moveSpeed;
        rotationSpeed = valuesSO.rotationSpeed;
        damage = valuesSO.damage;
    }

    public abstract void Move();
    public abstract void EnemyDied();
    public void TakeDamage(float damage)
    {
        health -= damage;
        
    }
    public void Explode()
    {
        Instantiate(explodeParticle, transform.position, Quaternion.identity);

    }
    public void SlowDown(float amount)
    {
        moveSpeed = amount;
        Debug.Log(moveSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(collision.GetComponent<PlayerMovement>() !=null)
                collision.GetComponent<PlayerMovement>().TakeDamage(damage);




        }
    }
}
