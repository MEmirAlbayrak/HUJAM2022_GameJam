using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour, ICanDealDamage
{
    [SerializeField] float damage;
    public float MovePos;
    public float Damage { get => damage; set => damage = value; }


    void Start()
    {
        Quaternion tempTarget = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, tempTarget, Time.deltaTime * 1f);
        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(transform.rotation.z, 50f, 0f) * Time.deltaTime * 50f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    public void DealDamage(float damage, Enemy enemy)
    {
        throw new System.NotImplementedException();
    }
}
