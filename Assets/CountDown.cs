using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using TMPro;

public class CountDown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeLabel = null;
    [SerializeField] int countdownTime = 60;
    private void Start()
    {
        StartCoroutine("CountDownTime");
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(countdownTime <= 10)
        {
            timeLabel.color = Color.red;
        }

        timeLabel.text = ("" + countdownTime);

        if (countdownTime == 0)
        {
            EventManager.TriggerEvent("death");
        }       
    }

    IEnumerator CountDownTime()
    {
        while (countdownTime>0)
        {
            yield return new WaitForSeconds(1);
            countdownTime--;
        }
    }

}
