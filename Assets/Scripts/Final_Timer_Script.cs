using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final_Timer_Script : MonoBehaviour
{
    public float FinalTimeLeft = 72f;

    public Text FinalTimerTxt;

    public First_Demo_Level_Doors_script first_level;

    void Update()
    {
        if(first_level.Second_level)
        {
            if(FinalTimeLeft > 0)
            {
            FinalTimeLeft -= Time.deltaTime;
            updateTimer(FinalTimeLeft);
            }
            else
            {
            FinalTimeLeft = 0;
            }
        } 
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        FinalTimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
