using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectReturner : MonoBehaviour //Needs to be added to every bullet!
{
    [SerializeField] private EnemyValuesSO enemyValuesSo;
    private ObjectPooler _objectPool;
    private String _poolToReturnTo;

    void Start()
    {
        _objectPool = FindObjectOfType<ObjectPooler>();
        _poolToReturnTo = enemyValuesSo.tag.Trim();
    }

    // Update is called once per frame
    private void OnDisable()
    {
        if (_objectPool != null)
            _objectPool.ReturnObject(_poolToReturnTo.Trim(), this.gameObject);
    }
}