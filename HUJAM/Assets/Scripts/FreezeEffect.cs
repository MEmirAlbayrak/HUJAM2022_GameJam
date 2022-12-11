using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEffect : MonoBehaviour
{
    [SerializeField] private GameObject maskObject;

    //private float _tempScaleY;
    private float _interpolation = 0;
    private readonly float _secondsUntillCompleted = 2;
    private float _progress;
    [SerializeField] SpriteRenderer maskObjectSpriteRenderer;
    [SerializeField] private float curtime, maxtime;
    bool test = false;
   
    private void Start()
    {
        maxtime = 5f;
        curtime = maxtime;
    }
    private void Update()
    {
       
    }


    

    void ScaleMask()
    {
        var temp = maskObjectSpriteRenderer.color;
        if(maskObjectSpriteRenderer.color.a < 255)
        {
            temp.a += 0.1f;
            maskObjectSpriteRenderer.color = temp;
        }
    }
    //private IEnumerator ScaleMask()
    //{
    //    var temp = maskObjectSpriteRenderer.color;

    //    while (maskObjectSpriteRenderer.color.a < 255)
    //    {
    //        temp.a += 0.01f;
    //        maskObjectSpriteRenderer.color = temp;
    //        yield return null;
    //    }
    //}

    void HideSprite()
    {
        var temp = maskObjectSpriteRenderer.color;
        if (maskObjectSpriteRenderer.color.a >0)
        {
            temp.a -= 0.01f;
            maskObjectSpriteRenderer.color = temp;
        }
    }
    //private IEnumerator HideSprite()
    //{
    //    var temp = maskObjectSpriteRenderer.color;

    //    while (maskObjectSpriteRenderer.color.a > 0f)
    //    {
    //        temp.a -= 0.01f;
    //        maskObjectSpriteRenderer.color = temp;
    //        yield return null;
    //    }
       
    //}


    

    /*private void ScaleMask()
    {
        while (_progress < _secondsUntillCompleted)
        {
            _progress += Time.deltaTime;
            _interpolation = _progress / _secondsUntillCompleted;

            /*maskObject.transform.localScale =
                new Vector3(maskObject.transform.localScale.x, Mathf.Lerp(0f, 27f, _interpolation),
                    maskObject.transform.localScale.z);#1#
            
            maskObject.transform.localScale = Vector3.Lerp(maskObject.transform.localScale,
                new Vector3(maskObject.transform.localScale.x, 27f, maskObject.transform.localScale.z), _interpolation);
            
        }
    }*/
}