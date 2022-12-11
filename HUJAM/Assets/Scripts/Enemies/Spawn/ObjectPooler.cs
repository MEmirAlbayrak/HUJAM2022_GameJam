using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public ObjectPooler Instance { get; private set; }
    
    [System.Serializable]
    public class Pool
    {
        public string Tag;
        public GameObject Prefab;
        public Queue<GameObject> ObjectPool = new Queue<GameObject>();
        public int PoolStartSize = 5;
    }

    public List<Pool> PoolList = new List<Pool>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        foreach (var pool in PoolList)
        {
            for (int i = 0; i < pool.PoolStartSize; i++)
            {
                GameObject newObject = Instantiate(pool.Prefab) as GameObject;
                pool.ObjectPool.Enqueue(newObject);
                newObject.SetActive(false);
            }
        }
    }

    public GameObject GetObject(string poolTag)
    {
        var desiredPool = PoolList.Find(p => p.Tag == poolTag);

        if (desiredPool.ObjectPool.Count > 0)
        {
            GameObject newObject = desiredPool.ObjectPool.Dequeue();
            newObject.SetActive(true);
            return newObject;
        }
         else
         {
             GameObject newObject = Instantiate(desiredPool.Prefab) as GameObject;
             return newObject;
         }
        return null;
    }

    public GameObject GetObject(GameObject targetPrefab)
    {
        var desiredPool = PoolList.Find(p => p.Prefab == targetPrefab);

        if (desiredPool.ObjectPool.Count > 0)
        {
            GameObject newObject = desiredPool.ObjectPool.Dequeue();
            newObject.SetActive(true);
            return newObject;
        }
        else
        {
            GameObject newObject = Instantiate(desiredPool.Prefab) as GameObject;
            return newObject;
        }
        return null;
    }

    public void ReturnObject(string poolTag, GameObject objectToReturn)
    {
        var desiredPool = PoolList.Find(p => p.Tag == poolTag);

        desiredPool.ObjectPool.Enqueue(objectToReturn);
        objectToReturn.SetActive(false);
    }

    public void ReturnObject(GameObject objectToReturn)
    {
        var desiredPool = PoolList.Find(p => p.Prefab == objectToReturn);
        
        desiredPool.ObjectPool.Enqueue(objectToReturn);
        objectToReturn.SetActive(false);
    }


    /*[SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Queue<GameObject> bulletPool = new Queue<GameObject>();
    [SerializeField] private int poolStartSize = 5;

    private void Start()
    {
        for (int i = 0; i < poolStartSize; i++)
        {
            GameObject newBullet = Instantiate(bulletPrefab) as GameObject;
            bulletPool.Enqueue(newBullet);
            newBullet.SetActive(false);
        }
    }

    public GameObject GetBullet()
    {
        if (bulletPool.Count > 0)
        {
            GameObject newBullet = bulletPool.Dequeue();
            newBullet.SetActive(true);
            return newBullet;
        }
        else
        {
            GameObject newBulet = Instantiate(bulletPrefab) as GameObject;
            return newBulet;
        }
    }

    public void ReturnBullet(GameObject bullet)
    {
        bulletPool.Enqueue(bullet);
        bullet.SetActive(false);
    }*/
}