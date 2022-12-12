using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeDamageScript : MonoBehaviour , ICanDealDamage
{

    private float damage=0;
    public float Damage { get => damage; set => damage = value; }
    [SerializeField] float slowAmount;

    public void DealDamage(float damage, Enemy enemy)
    {
        enemy.TakeDamage(damage);
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Enemy>() !=null)
            collision.GetComponent<Enemy>().SlowDown(slowAmount);


    }
}
