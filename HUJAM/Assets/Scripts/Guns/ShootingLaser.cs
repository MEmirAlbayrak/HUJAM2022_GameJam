using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingLaser : ItemSpawner
{
    
    private float maxtimer;
    private float curtimer;
    
    private void Start()
    {
        maxtimer = 4f;
        curtimer = maxtimer;
    }

   
    public override void Spawn()
    {
        if (curtimer >= 0)
        {
            curtimer -= Time.deltaTime;
        }
        else
        {
            ObjGO = Instantiate(prefabObj, SpawnPoint.transform.position, transform.rotation);
            ObjGO.GetComponent<LaserMove>().MovePos = transform.rotation.z;
            curtimer = maxtimer;
        }
       
    }
}
