using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawnScript : ItemSpawner
{
    float curtimer, maxtimer;
    [SerializeField] ParticleSystem rocketLaunchParticle;
    [SerializeField] AudioClip rocketLunchSFX;

    void Start()
    {
        maxtimer = 0.3f;
        curtimer = maxtimer;
    }



    public override void Spawn()
    {
        if (ObjGO == null)
        {
            curtimer -= Time.deltaTime;
            if (curtimer <= 0)
            {
               
                ObjGO = Instantiate(prefabObj, SpawnPoint.position, Quaternion.identity);
                
                SoundManager.Instance.Play(rocketLunchSFX);
                rocketLaunchParticle.Play();
                curtimer = maxtimer;
            }


        }
    }
}
