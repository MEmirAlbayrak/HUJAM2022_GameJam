using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] internal EnemyValuesSO valuesSO;
    [SerializeField] protected List<GameObject> lootboxes;
    protected float health;
    protected float moveSpeed;
    
    //protected float rotationSpeed;
    protected float damage;

    public static Transform Target;
    public GameObject explodeParticle;
    public GameObject explodeParticleRocket;

    [SerializeField]


    private void OnEnable()
    {
        Target = GameObject.FindWithTag("Player").transform;
    }

    protected void AssignValues()
    {
        health = valuesSO.health;
        moveSpeed = valuesSO.moveSpeed;
        //rotationSpeed = valuesSO.rotationSpeed;
        damage = valuesSO.damage;
    }

    public abstract void Move();

    public void TakeDamage(float damage)
    {
        health -= damage;

        SoundManager.Instance.Play(valuesSO.getHitSoundFX);
        if (health <= 0)
        {
            EnemyDied();
        }
    }

    public void SlowDown(float amount)
    {
        moveSpeed = amount;
    }

    public void EnemyDied()
    {
        Instantiate(explodeParticle, transform.position, Quaternion.identity);
            
        GameObject lootbox = Instantiate(lootboxes[Random.Range(0, lootboxes.Count)], transform.position,
            Quaternion.Euler(new Vector3(Random.Range(-1f, 1f), 0))) as GameObject;
        lootbox.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)));
        
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(collision.GetComponent<PlayerMovement>() !=null)
                collision.GetComponent<PlayerMovement>().TakeDamage(damage);


        }
    }

   public void Explode()
    {
        Instantiate(explodeParticleRocket, transform.position, Quaternion.identity);
    }
}