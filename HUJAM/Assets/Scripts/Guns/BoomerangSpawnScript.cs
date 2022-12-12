using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangSpawnScript : ItemSpawner
{
    [SerializeField] GameObject route;

    [SerializeField] AudioClip boomerangThrofSFX;
    void Start()
    {

        route = transform.GetChild(1).gameObject;
    }

  
    public override void Spawn()
    {
        
        if (ObjGO == null)
        {

            ObjGO = Instantiate(prefabObj, SpawnPoint.position, Quaternion.identity);


            ObjGO.GetComponent<RouteFollow>().routes[0] = route.transform;
            SoundManager.Instance.Play(boomerangThrofSFX);
        }
     
    }
    



}
