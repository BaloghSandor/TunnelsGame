using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract_test : MonoBehaviour
{

    private bool interaction = false;
    private float state = 1.0f;
    private bool color_switch = false;
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
        if (interaction && Input.GetKeyDown(KeyCode.E))
        {
            var rendering = gameObject.GetComponent<Renderer>();
            rendering.material.SetColor("_Color", Color.green);
            state *= -1;
        }

        if(state == 1.0f){
            color_switch = true;
        } else {
            color_switch = false;
        }

        if(color_switch){
            var rendering = gameObject.GetComponent<Renderer>();
            rendering.material.SetColor("_Color", Color.red);
        }
    }
}
