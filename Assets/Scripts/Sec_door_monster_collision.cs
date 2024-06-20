using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sec_door_monster_collision : MonoBehaviour
{
    private bool interaction = false;
    public Monster_spawning_script monster_object;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ennemy")
        {
            interaction = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ennemy")
        {
            interaction = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(interaction)
        {
            monster_object.monster_spawn = false;
        }
    }
}
