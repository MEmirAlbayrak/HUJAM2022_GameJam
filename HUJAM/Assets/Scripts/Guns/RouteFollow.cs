using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class RouteFollow : MonoBehaviour , ICanDealDamage
{
    [SerializeField]
    public Transform[] routes;

    private int routeToGo;

    private float tParam;

    private Vector3 objectPosition;

    private float speedModifier;

    [SerializeField] private bool coroutineAllowed;

    public delegate void SpawnEvent();
    public  SpawnEvent OnSpawn;

    [SerializeField] float damage;
    public float Damage { get => damage; set => damage = value; }


    // Start is called before the first frame update
    void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.5f;
        coroutineAllowed = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(GoByTheRoute(routeToGo));
            coroutineAllowed = false;
            Debug.Log(tParam);
        }
        
    }

    private IEnumerator GoByTheRoute(int routeNum)
    {
        

        Vector2 p0 = routes[routeNum].GetChild(0).position;
        Vector2 p1 = routes[routeNum].GetChild(1).position;
        Vector2 p2 = routes[routeNum].GetChild(2).position;
        

        while (tParam < 1)
        {
            Vector2 p3 = routes[routeNum].GetChild(3).position;
            tParam += Time.deltaTime * speedModifier;
            transform.Rotate(Vector3.forward * 30f * Time.deltaTime * 20f);
            objectPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

            transform.position = objectPosition;
            
            yield return new WaitForEndOfFrame();
           
        }
       

        tParam = 0;
        //speedModifier = speedModifier *1.1f;
        routeToGo += 1;

        if (routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
        }
       
       
        Destroy(gameObject);
        yield return new WaitForSeconds(2f);

        coroutineAllowed = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            DealDamage(Damage, collision.GetComponent<Enemy>());
        }
    }

    public void DealDamage(float damage, Enemy enemy)
    {
        enemy.TakeDamage(damage);
    }
}
