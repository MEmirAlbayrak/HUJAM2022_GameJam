using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private Rigidbody2D rocketRb;
    [SerializeField] private float rocketSpeed;
    [SerializeField] private float timeAlive;
    private static PlayerMovement _player;
    [SerializeField] AudioClip explosion;
    private void OnEnable()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        
    }

    void Start()
    {
        rocketRb.AddForce(transform.up * rocketSpeed, ForceMode2D.Impulse);
        rocketRb.transform.SetParent(null);
        //rocketRb.transform.localEulerAngles = new Vector3(0f, 0f, _player.transform.position.z - transform.position.z);

        Destroy(gameObject, timeAlive);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _player.hp -= damage;
            SoundManager.Instance.Play(explosion);
            Destroy(gameObject);
        }
    }
}