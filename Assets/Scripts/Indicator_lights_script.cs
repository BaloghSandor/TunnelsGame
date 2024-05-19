using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator_lights_script : MonoBehaviour
{
    public Light targetLight; // Reference to the Light component
    public Generator_script generator;

    void Update()
    {
        if (generator.gen_failure)
        {
            targetLight.color = Color.red;
        }
        else
        {
            targetLight.color = Color.green;
        }
    }
}

