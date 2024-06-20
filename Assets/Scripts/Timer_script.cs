using UnityEngine;
using UnityEngine.UI;

public class Timer_script : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public Text TimerTxt;

    public First_Demo_Level_Doors_script demo_level;
   
    void Start()
    {
        TimerOn = true;
    }

    void Update()
    {
        if(TimerOn)
        {
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
            }
        }

        if(!demo_level.Demo_level_one)
        {
            TimerTxt.enabled = false;
            TimeLeft = 1;
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}