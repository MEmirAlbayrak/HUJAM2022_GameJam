using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal, vertical;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] public float hp;
    [SerializeField] CinemachineVirtualCamera vCam;
    float timer;
    bool damagedDealed;
    [SerializeField] Image damageImage;

    private void Start()
    {
        lastPlayerpos = gameObject.transform.position;
        timer = 0;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        StarsParallax();

        if (damagedDealed)
        {
            ScreenBright();
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }


    public void TakeDamage(float damage)
    {
        if (hp > 0)
        {
            hp -= damage;
            StartCoroutine(_ProcessShake(10, 0.5f));
            damagedDealed = true;

        }
    }
    float newY;
    void ScreenBright()
    {

        timer += Time.deltaTime * 2;
        newY = Mathf.Sin(timer) * 27;

        damageImage.GetComponent<Image>().color = new Color32(255, 69, 69, (byte)newY);


    }

    public IEnumerator _ProcessShake(float shakeIntensity = 5f, float shakeTiming = 0.5f)
    {
        Noise(1, shakeIntensity);
        damagedDealed = true;

        yield return new WaitForSeconds(shakeTiming);


        timer = 0;
        newY = -1;
        damageImage.GetComponent<Image>().color = new Color32(255, 69, 69, 0);
        damagedDealed = false;

        Noise(0, 0);
    }

    public void Noise(float amplitudeGain, float frequencyGain)
    {
        var composer = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        composer.m_AmplitudeGain = amplitudeGain;
        composer.m_FrequencyGain = frequencyGain;
    }

    Vector3 lastPlayerpos;
    [SerializeField] GameObject starsGameobject;
    [SerializeField, Range(0, 1)] float parallaxEffect;

    public void StarsParallax()
    {
        Vector3 deltaMovement = transform.position - lastPlayerpos;
        parallaxEffect = 0.2f;
        starsGameobject.transform.position += deltaMovement * parallaxEffect * -1;
        lastPlayerpos = transform.position;
    }
}
