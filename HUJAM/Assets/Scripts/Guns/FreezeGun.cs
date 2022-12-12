using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGun : Collectable
{
    [SerializeField] CapsuleCollider2D capsuleCollider;
    private float maxtimer;
    private float curtimer;
    [SerializeField] SpriteRenderer maskObjectSpriteRenderer;

    bool oneTime;
    [SerializeField] AudioClip FreezeAudio;

    private void Start()
    {
        oneTime = false;
        maxtimer = 4f;
        curtimer = maxtimer;
    }

    void FixedUpdate()
    {

        if (curtimer >= 0)
        {
            capsuleCollider.enabled = false;
            curtimer -= Time.deltaTime;
            var temp = maskObjectSpriteRenderer.color;
            if (maskObjectSpriteRenderer.color.a >0)
            {
                temp.a -= 0.1f;
                maskObjectSpriteRenderer.color = temp;
            }
        }
        else if(curtimer >= -0.5f)
        {
            curtimer -= Time.deltaTime;
            var temp = maskObjectSpriteRenderer.color;
            if (maskObjectSpriteRenderer.color.a < 255)
            {
                temp.a += 0.1f;
                maskObjectSpriteRenderer.color = temp;
            }
            capsuleCollider.enabled = true;

            if (!oneTime)
            {
                SoundManager.Instance.Play(FreezeAudio);
                oneTime = true;
            }
        }
        else
        {
            curtimer = maxtimer;
            oneTime = false;
        }
    }
}

