using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawDamageScript : MonoBehaviour , ICanDealDamage
{
    [SerializeField] float rotateSpeed;

    [SerializeField] float damage;
    public float Damage { get => damage; set => damage = value; }

    void Start()
    {
        
    }

    // Update is called once per frame
  
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            DealDamage(Damage, collision.GetComponent<Enemy>());
        }
    }

    public void DealDamage(float damage, Enemy enemy)
    {
        enemy.TakeDamage(damage);
    }
}
