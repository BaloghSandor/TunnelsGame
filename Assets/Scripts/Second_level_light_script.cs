using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second_level_light_script : MonoBehaviour
{
    public Light Lighting; // Reference to the Light component
    public Monster_spawning_script monster;
    public Final_escape_door second_level;

    void Start()
    {
        Lighting = GetComponent<Light>();
    }

    void Update()
    {
        if (monster.monster_spawn_barrage && !second_level.Second_level_finished)
        {
            Lighting.color = Color.red;
        }
        else
        {
            Lighting.color = new Color(1f, 1f, 0.72f);
        }
    }
}
