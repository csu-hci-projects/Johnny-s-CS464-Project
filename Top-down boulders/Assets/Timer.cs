using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public Text timeCounter;
    private TimeSpan timeSoFar;
    private bool timerRunning;
    private float timePassed;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        timeCounter.text = "Time survived: 00:00.0";
        timerRunning = true;
    }
    public void StartTimer()
    {
        timerRunning = true;
        timePassed = 0f;
        StartCoroutine(TimerTick());
    }
    public void EndTimer()
    {
        timerRunning = false;
    }
    private IEnumerator TimerTick()
    {
        while (timerRunning)
        {
            timePassed += Time.deltaTime;
            timeSoFar = TimeSpan.FromSeconds(timePassed);
            string timeSoFarStr = "Time survived: " + timeSoFar.ToString("mm':'ss'.'f");
            timeCounter.text = timeSoFarStr;
            yield return null;
        }
    }
}
