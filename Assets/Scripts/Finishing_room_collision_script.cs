using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finishing_room_collision_script : MonoBehaviour
{
    private bool interaction = false;
    public bool game_finished = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interaction = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interaction = false;
        }
    }  
    // Update is called once per frame
    void Update()
    {
        if(interaction)
        {
            game_finished = true;
            Debug.Log("Finished!");
        }
    }
}
