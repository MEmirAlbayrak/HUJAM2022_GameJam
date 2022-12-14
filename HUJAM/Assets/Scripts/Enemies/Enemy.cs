using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] internal EnemyValuesSO valuesSO;
    [SerializeField] protected List<GameObject> lootboxes;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Material defaultMaterial;
    [SerializeField] protected Material flashMaterial;


    protected float health;
    protected float moveSpeed;


    //protected float rotationSpeed;
    protected float damage;

    public static Transform Target;
    public GameObject explodeParticle;
    public GameObject explodeParticleRocket;
    protected SpriteRenderer enemySpriteRenderer;

    [SerializeField]


    private void OnEnable()
    {
        Target = GameObject.FindWithTag("Player").transform;
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected void AssignValues()
    {
        health = valuesSO.health;
        moveSpeed = valuesSO.moveSpeed;
        //rotationSpeed = valuesSO.rotationSpeed;
        damage = valuesSO.damage;
    }

    public abstract void Move();

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("damage: " + damage);
        StartCoroutine(Flash());

        rb.AddForce((transform.position - Target.transform.position).normalized * 20f, ForceMode2D.Impulse);  //Get pushed

        if (GetComponent<BossEnemy>() != null)
            GetComponent<BossEnemy>().HandleDamage();

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

    public IEnumerator Flash()
    {
        enemySpriteRenderer.material = flashMaterial;
        yield return new WaitForSecondsRealtime(0.25f);
        enemySpriteRenderer.material = defaultMaterial;
    }

    public void EnemyDied()
    {
        Instantiate(explodeParticle, transform.position, Quaternion.identity);
        SoundManager.Instance.Play(valuesSO.getDieSoundFX);

        float random = Random.Range(0, 100);
        if(random >75)
        {
            GameObject lootbox = Instantiate(lootboxes[Random.Range(0, lootboxes.Count)], transform.position,
            Quaternion.Euler(new Vector3(Random.Range(-1f, 1f), 0))) as GameObject;

        }


        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerMovement>() != null)
                collision.GetComponent<PlayerMovement>().TakeDamage(damage);


        }
    }

    public void Explode()
    {
        Instantiate(explodeParticleRocket, transform.position, Quaternion.identity);
    }
}