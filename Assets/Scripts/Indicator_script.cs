using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator_script : MonoBehaviour
{
    public Generator_script generator;

    // Update is called once per frame
    void Update()
    {
        if (generator.gen_failure)
        {
            var rendering = gameObject.GetComponent<Renderer>();
            rendering.material.SetColor("_Color", Color.red);
        }
        else
        {
            var rendering = gameObject.GetComponent<Renderer>();
            rendering.material.SetColor("_Color", Color.green);
        }
    }
}
