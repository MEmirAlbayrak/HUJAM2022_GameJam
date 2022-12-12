using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Saw : Collectable 
{

    [SerializeField] GameObject sawCollider;

    void Start()
    {
        sawCollider.SetActive(true);
    }

  






}
