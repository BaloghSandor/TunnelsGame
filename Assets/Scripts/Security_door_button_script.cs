using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Security_door_button_script : MonoBehaviour
{
    private bool interaction = false;
    private int change = 1;

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
        if(interaction && Input.GetKeyDown(KeyCode.E))
        {
            change *= -1;
        }

        if(change == 1)
        {
            var rendering = gameObject.GetComponent<Renderer>();
            rendering.material.SetColor("_Color", Color.red);
        }
        
    }
}
