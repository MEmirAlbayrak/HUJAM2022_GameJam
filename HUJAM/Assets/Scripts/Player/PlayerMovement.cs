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
    [SerializeField] AudioClip getHitSFX;
    [SerializeField] AudioClip dieSFX;
    [SerializeField] Slider hpSlider;


    [SerializeField] GameObject tryAgainCanvas;
    private void Start()
    {
        lastPlayerpos = gameObject.transform.position;
        timer = 0;
        tryAgainCanvas.SetActive(false);
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

        hpSlider.value = hp;

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
            SoundManager.Instance.Play(getHitSFX);
            StartCoroutine(_ProcessShake(1, 5f));
            damagedDealed = true;

        }
        else
        {
            SoundManager.Instance.Play(dieSFX);
            Time.timeScale = 0;
            tryAgainCanvas.SetActive(true);


        }
    }
    float newY;
    void ScreenBright()
    {

        timer += Time.deltaTime * 2;
        newY = Mathf.Sin(timer) * 27;

        damageImage.GetComponent<Image>().color = new Color32(255, 69, 69, (byte)newY);


    }

    public IEnumerator _ProcessShake(float shakeIntensity = 1.47f, float shakeTiming = 5f)
    {
        Noise(5, 1.5f);
        damagedDealed = true;

        yield return new WaitForSeconds(1);


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
    [SerializeField] GameObject starsGameobject1;
    [SerializeField] GameObject starsGameobject2;
    [SerializeField] GameObject starsGameobject3;
    [SerializeField, Range(0, 1)] float parallaxEffect;

    public void StarsParallax()
    {
        Vector3 deltaMovement = transform.position - lastPlayerpos;
        parallaxEffect = 0.1f;



        starsGameobject.transform.position += deltaMovement * parallaxEffect * -1;
        starsGameobject1.transform.position += deltaMovement * parallaxEffect * -1;
        starsGameobject2.transform.position += deltaMovement * parallaxEffect * -1;
        starsGameobject3.transform.position += deltaMovement * parallaxEffect * -1;



        lastPlayerpos = transform.position;
    }
}
