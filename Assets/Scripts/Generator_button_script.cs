using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_button_script : MonoBehaviour
{

    private bool interaction = false;
    public Generator_script generator;

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

    void Update()
    {
        if (generator.gen_failure)
        {
            var rendering = gameObject.GetComponent<Renderer>();
            rendering.material.SetColor("_Color", Color.red);
        }

        if (interaction && Input.GetKeyDown(KeyCode.E) && generator.gen_failure)
        {
            var rendering = gameObject.GetComponent<Renderer>();
            rendering.material.SetColor("_Color", Color.green);
            generator.gen_failure = false;
            generator.launch_new_coroutine = true;
        }
    }
}
