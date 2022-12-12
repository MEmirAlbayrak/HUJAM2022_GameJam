using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerAdvanced : MonoBehaviour
{
    [SerializeField] private List<StageSO> allStages = new List<StageSO>();
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private float bossSpawnTime;
    public List<Transform> spawnPlaces;
    public Queue<GameObject> EnemyQueue = new Queue<GameObject>();

    private ObjectPooler _objectPool;
    private StageSO _currentStage;
    private int _stageIndex = 0;
    private bool _bossSpawned = false;


    private void Start()
    {
        _objectPool = FindObjectOfType<ObjectPooler>();
        _currentStage = allStages[_stageIndex];
        Debug.Log("Bruh");
        SetEnemyQueue();

        Invoke(nameof(SpawnBoss), bossSpawnTime);
    }

    private void FixedUpdate()
    {
        SpawnNonBossEnemies();
    }

    private void SetEnemyQueue()
    {
        foreach (var enemy in _currentStage.enemies)
        {
            EnemyQueue.Enqueue(enemy);
        }
    }

    private void SpawnNonBossEnemies()
    {
        if (!_bossSpawned)
        {
            _currentStage.timeSinceSpawn += Time.deltaTime;

            if (_currentStage.timeSinceSpawn >= _currentStage.timeTakesToSpawn)
            {
                if (EnemyQueue.Count <= 0)
                {
                    if (_stageIndex + 1 != allStages.Count)
                    {
                        _stageIndex++;
                        _currentStage = allStages[_stageIndex];
                        SetEnemyQueue();
                    }
                    else
                    {
                        Debug.Log("Stage finished, stage was " + _currentStage);
                        //this.gameObject.SetActive(false);
                    }
                }
                else
                {
                    GameObject newObject = _objectPool.GetObject(EnemyQueue.Dequeue());
                    newObject.transform.position = spawnPlaces[Random.Range(0, spawnPlaces.Count)].position;
                    newObject.SetActive(true);
                    _currentStage.timeSinceSpawn = 0f;
                }
            }
        }
    }

    private void SpawnBoss()
    {
        Instantiate(bossPrefab, spawnPlaces[Random.Range(0, spawnPlaces.Count)]);
        _bossSpawned = true;
    }
}