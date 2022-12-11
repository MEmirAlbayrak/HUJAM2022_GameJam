using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rocketRb;
    [SerializeField] private float rocketSpeed;
    [SerializeField] private float timeAlive;
    private static GameObject _player;

    private void OnEnable()
    {
        _player = GameObject.FindWithTag("Player");
    }

    void Start()
    {
        rocketRb.transform.SetParent(null);
        rocketRb.transform.localEulerAngles = new Vector3(0f, 0f, _player.transform.position.z - transform.position.z);
        rocketRb.AddForce((_player.transform.position - transform.position).normalized * rocketSpeed,
            ForceMode2D.Impulse);
        
        Destroy(gameObject, timeAlive);
    }
}