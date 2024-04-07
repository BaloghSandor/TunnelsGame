using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{

    private bool interaction = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interaction = true;
        }
    }

    void Update()
    {
        if (interaction && Input.GetKeyDown(KeyCode.E))
        {
            var rendering = gameObject.GetComponent<Renderer>();
            rendering.material.SetColor("_Color", Color.green);
        }
    }
}
