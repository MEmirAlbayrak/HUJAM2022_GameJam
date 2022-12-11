using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Serializable]
    public class SpawnInfo
    {
        public string Tag;      // Must be the same as in the Object Pooler! 
        [SerializeField] public float timeToSpawn = 5f;
        [HideInInspector] public float timeSinceSpawn;
    }
    
    private static ObjectPooler _objectPool;
    
    public List<SpawnInfo> SpawnInfos = new List<SpawnInfo>();

    /*[SerializeField] private float timeToSpawn = 5f;
    private float _timeSinceSpan;
    private ObjectPooler _objectPool;
    */

    private void Start()
    {
        _objectPool = FindObjectOfType<ObjectPooler>();
    }

    private void Update()
    {
        foreach (var spawning in SpawnInfos)
        {
            spawning.timeSinceSpawn += Time.deltaTime;

            if (spawning.timeSinceSpawn >= spawning.timeToSpawn)
            {
                try
                {
                    GameObject newObject = _objectPool.GetObject(spawning.Tag);
                    newObject.transform.position = this.transform.position;     // Change here to Random!!
                    spawning.timeSinceSpawn = 0f;
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e);
                }
                
            }
        }
        
        /*_timeSinceSpan += Time.deltaTime;

        if (_timeSinceSpan >= timeToSpawn)
        {
            GameObject newObject = _objectPool.GetObject();
            newObject.transform.position = this.transform.position;
            _timeSinceSpan = 0f;
        }*/
    }
}
