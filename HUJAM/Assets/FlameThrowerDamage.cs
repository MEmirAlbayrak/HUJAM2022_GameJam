using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerDamage : MonoBehaviour, ICanDealDamage
{

    [SerializeField] float damage;
    public float Damage { get => damage; set => damage = value; }

    public void DealDamage(float damage, Enemy enemy)
    {
        enemy.TakeDamage(damage);
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
            DealDamage(damage, collision.GetComponent<Enemy>());

    }
}
