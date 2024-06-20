using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_escape_door : MonoBehaviour
{
    public Final_Timer_Script final_timer;
    public bool Second_level_finished = false;

    // Update is called once per frame
    void Update()
    {
        if(final_timer.FinalTimeLeft == 0)
        {
            gameObject.SetActive(false);
            Second_level_finished = true;
        }
    }
}
