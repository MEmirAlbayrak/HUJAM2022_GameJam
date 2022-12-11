using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxScript : MonoBehaviour
{

    [SerializeField] GameObject[] nodePrefs;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(nodePrefs[Random.Range(0,nodePrefs.Length)], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

}
