using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerCounter : MonoBehaviour
{
    public static TimerCounter instance;

    [SerializeField] TextMeshProUGUI timeText;

    private TimeSpan timeRunning;
    public bool timerCounting;

    private float elapsedTime = 0f;


    void Awake() 
    {
        instance = this;  
    }

    void Start()
    {
        timeText.text = "Time: 00:00.00";
        timerCounting = true;
    }

    public void BeginTimer()
    {
        timerCounting = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerCounting = false;
    }

    IEnumerator UpdateTimer()
    {
        while(timerCounting)
        {
            elapsedTime += Time.deltaTime;
            timeRunning = TimeSpan.FromSeconds(elapsedTime);
            string timeRunningStr = "Time " + timeRunning.ToString("mm':'ss'.'ff");
            timeText.text = timeRunningStr;

            yield return null;
        } 
    }
}
