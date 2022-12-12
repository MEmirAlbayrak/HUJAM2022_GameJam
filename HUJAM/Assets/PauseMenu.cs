using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;

    bool isGameStoped;


    private void Start()
    {
        pauseMenu.SetActive(false);
        isGameStoped = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PuseFunction();

        }
    }


    public void PuseFunction()
    {
        if (isGameStoped)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            isGameStoped = false;

        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            isGameStoped = true;


        }
    }

}
