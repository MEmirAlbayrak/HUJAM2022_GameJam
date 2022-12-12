using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : Collectable
{

    private float maxtimer;
    private float curtimer;
    [SerializeField] private Transform waveTransform;
    private bool _waveActive;

    [SerializeField] GameObject waveFx;
    [SerializeField] AudioClip shockWaveSFX;
    bool oneTime;

    private void Start()
    {
        oneTime = false;
        _waveActive = true;
        maxtimer = 4f;
        curtimer = maxtimer;
        if (_waveActive)
        {
            waveFx.SetActive(true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_waveActive)
        {

            if (curtimer >= 0)
            {
                curtimer -= Time.deltaTime;
            }
            else if (curtimer >= -1.5f)
            {
                curtimer -= Time.deltaTime;
                Grow();
                if (!oneTime)
                {
                    SoundManager.Instance.Play(shockWaveSFX);
                    oneTime = true;
                }
                
            }
            else
            {
                ResetSize();
                curtimer = maxtimer;
                oneTime = false;

            }
        }


    }

    void Grow()
    {
        waveTransform.localScale += new Vector3(0.5f, 0.5f, 0);
    }

    void ResetSize()
    {
        waveTransform.localScale = new Vector3(1, 1, 0);

    }





}
