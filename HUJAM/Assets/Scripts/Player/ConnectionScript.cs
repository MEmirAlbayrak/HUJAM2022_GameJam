using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ConnectionScript : MonoBehaviour
{

    public bool collected;
    [SerializeField] GameObject tempCollectable;

    [SerializeField] CinemachineVirtualCamera vCam;
    [SerializeField] GameObject tempUiConnectionPoint;
    [SerializeField] Rigidbody2D rb;

    RaycastHit2D raycastHit;
    Ray ray;
    public Sprite hoverSprite, defultSprite;

    public Camera cameraGO;


   [SerializeField] int _tempOrderLayer;

    void Update()
    {
        if (collected)
        {

            Debug.Log("Aktif");
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            raycastHit = Physics2D.Raycast(ray.origin, ray.direction, 1000);
            if (raycastHit.collider != null)
            {
                Debug.Log("Inside If");

                CurrentClickedGameObject(raycastHit.collider.gameObject);

            }
            else
            {
                if (tempUiConnectionPoint != null)
                {
                    SetSpriteDefult();
                }
            }

        }



    }
    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.CompareTag("Connection"))
        {
            Debug.Log("Inside Tag");


            tempUiConnectionPoint = gameObject.gameObject;
            tempUiConnectionPoint.GetComponent<SpriteRenderer>().sprite = hoverSprite;

            tempCollectable.transform.parent = tempUiConnectionPoint.transform;
            tempCollectable.transform.localEulerAngles = new Vector3(0, 0, tempUiConnectionPoint.transform.rotation.z);
            tempCollectable.transform.localPosition = new Vector3(0, 0, 0);

            tempCollectable.GetComponent<SpriteRenderer>().color = new Color(0, 0.7f, 0.2f, 0.3f);

            if (Input.GetMouseButtonDown(0))
            {
                tempCollectable.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);

                foreach (Transform child in tempCollectable.transform)
                {
                    if (child.transform.CompareTag("Connection"))
                    {

                        child.transform.parent = transform;
                    }
                }
                if (tempCollectable.GetComponent<Collectable>() != null)
                    tempCollectable.GetComponent<Collectable>().enabled = true;

                tempCollectable.transform.parent = transform;

                Destroy(tempUiConnectionPoint);
                tempUiConnectionPoint = null;

                ResumeGame();
            }
        }
        else
        {
            SetSpriteDefult();
        }


    }

    void SetSpriteDefult()
    {
        tempUiConnectionPoint.GetComponent<SpriteRenderer>().sprite = defultSprite;
    }

    void ResumeGame()
    {

        GetComponent<PlayerRotation>().enabled = true;
        GetComponent<PlayerMovement>().enabled = true;
        collected = false;
        Time.timeScale = 1;
        rb.constraints = RigidbodyConstraints2D.None;
        for (int i = 0; i < transform.childCount; i++)
        {

            if (transform.GetChild(i).CompareTag("Connection"))
            {
                Debug.Log("on connection child");
                transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
            }

        }
        var composer = vCam.GetCinemachineComponent<CinemachineFramingTransposer>();
        composer.m_DeadZoneWidth = 0.1f;
        composer.m_DeadZoneHeight = 0.1f;

      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {


            tempCollectable = collision.gameObject;
            tempCollectable.transform.position += new Vector3(0, 500, 0);

           


            _tempOrderLayer += 1;
            tempCollectable.GetComponent<SpriteRenderer>().sortingOrder = _tempOrderLayer;
            collected = true;
            GetComponent<PlayerRotation>().enabled = false;
            GetComponent<PlayerMovement>().enabled = false;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;

            }
            GetComponent<SpriteRenderer>().sortingOrder = 1;
            var composer = vCam.GetCinemachineComponent<CinemachineFramingTransposer>();
            composer.m_DeadZoneWidth = 0;
            composer.m_DeadZoneHeight = 0;

            Time.timeScale = 0.15f;
            collision.tag = "Player";



        }
    }




}
