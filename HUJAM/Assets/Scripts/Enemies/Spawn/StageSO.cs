using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageSO", menuName = "Scriptable Objects/Stage")]
[Serializable]
public class StageSO : ScriptableObject
{
    public List<GameObject> enemies;    //Conver to queue in spawner!
    public float timeTakesToSpawn;
    [HideInInspector] public float timeSinceSpawn;
    //public float stageTime;
}
