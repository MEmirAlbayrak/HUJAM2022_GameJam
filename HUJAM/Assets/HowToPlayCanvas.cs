using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayCanvas : MonoBehaviour
{

    CanvasGroup cg;
    float ElapsedTIme;


    // Start is called before the first frame update
    void Start()
    {
        cg = GetComponent<CanvasGroup>();
        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if(ElapsedTIme < 90)
        {
            ElapsedTIme += Time.deltaTime;
            cg.alpha = Mathf.Cos(ElapsedTIme) * 5;
        }



    }
}
