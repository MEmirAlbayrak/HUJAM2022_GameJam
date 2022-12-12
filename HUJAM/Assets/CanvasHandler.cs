using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHandler : MonoBehaviour
{

   public GameObject winPanel;
    public static CanvasHandler Instance = null;
    void Start()
    {
        
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        
    }
}
