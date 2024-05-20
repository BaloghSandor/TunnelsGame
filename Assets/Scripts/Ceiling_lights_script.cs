using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceiling_lights_script : MonoBehaviour
{
    public Light targetLight; // Reference to the Light component
    public Generator_script generator;

    void Update()
    {
        if (generator.gen_failure)
        {
            targetLight.enabled = false;
        }
        else
        {
            targetLight.enabled = true;
        }
    }
}

