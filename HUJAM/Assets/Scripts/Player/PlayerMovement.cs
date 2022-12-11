using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal, vertical;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] public float hp;

    private void Start()
    {
        lastPlayerpos = gameObject.transform.position;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        StarsParallax();

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }


    public void TakeDamage(float damage)
    {
        if (hp > 0)
        {   
            hp -= damage;

        }
    }

    Vector3 lastPlayerpos;
    [SerializeField] GameObject starsGameobject;
    [SerializeField, Range(0,1)] float parallaxEffect;
    public void StarsParallax()
    {
        Vector3 deltaMovement = transform.position - lastPlayerpos;
        parallaxEffect = 0.2f;
        starsGameobject.transform.position += deltaMovement * parallaxEffect * -1;
        lastPlayerpos = transform.position;
    }
}
