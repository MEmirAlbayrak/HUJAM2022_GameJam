using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCountdown());

    }

    float currCountdownValue;
    public IEnumerator StartCountdown(float countdownValue = 180)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
    }
    [SerializeField] TextMeshProUGUI timerTxt;
    private void FixedUpdate()
    {
        timerTxt.text = ""+currCountdownValue;

        if (currCountdownValue < 1)
        {
            Destroy(gameObject);
        }

    }

}
