using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second_level_light_script : MonoBehaviour
{
    public Light Lighting; // Reference to the Light component
    public Monster_spawning_script monster;

    void Start()
    {
        Lighting = GetComponent<Light>();
    }

    void Update()
    {
        if (monster.monster_spawn)
        {
            Lighting.color = Color.red;
        }
        else
        {
            Lighting.color = new Color(1f, 1f, 0.72f);
        }
    }
}
