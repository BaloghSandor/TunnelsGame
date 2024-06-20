using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_kill_collision_script : MonoBehaviour
{
    private bool interaction = false;  
    public GameObject monster;
    public bool game_over = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == monster)
        {
            interaction = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == monster)
        {
            interaction = false;
        }
    }  
    // Update is called once per frame
    void Update()
    {
        if(interaction)
        {
            game_over = true;
        }
    }
}
