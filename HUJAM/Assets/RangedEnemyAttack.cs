using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject[] shootingPoints;
    [SerializeField] private GameObject rocketPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(4f, 6f));
            Instantiate(rocketPrefab, shootingPoints[0].transform);
            Instantiate(rocketPrefab, shootingPoints[1].transform);
        }
    }
}
