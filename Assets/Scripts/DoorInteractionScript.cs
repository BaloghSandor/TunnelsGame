using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractionScript : MonoBehaviour
{

    private bool toggle = false;
    private bool rotation = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            toggle = true;
        }
    }

    void Update()
    {
        if (toggle && Input.GetKeyDown(KeyCode.E))
        {
            rotation = true;
        }

        if (rotation)
        {
            gameObject.transform.Rotate(0, 0, -90);
        }
    }
}
