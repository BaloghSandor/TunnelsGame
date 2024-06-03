using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Demo_Level_Doors_script : MonoBehaviour
{
    public Demo_Drop_off_script first_level;
    public GameObject door;

    // Update is called once per frame
    void Update()
    {
        if(first_level.first_demo_level_finished)
        {
            door.transform.GetChild(0).gameObject.SetActive(false);
        }   
    }
}
