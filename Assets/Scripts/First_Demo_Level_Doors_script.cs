using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Demo_Level_Doors_script : MonoBehaviour
{
    public Demo_Drop_off_script first_level;
    public Trigger_second_level_script triggered;
    public bool Demo_level_one = true;
    public GameObject door;

    // Update is called once per frame
    void Update()
    {
        if(first_level.first_demo_level_finished)
        {
            door.transform.GetChild(0).gameObject.SetActive(false);
        }
        if(triggered.player_collided)
        {
            first_level.first_demo_level_finished = false;
            door.transform.GetChild(0).gameObject.SetActive(true);
            Demo_level_one = false;
        }
    }
}
