using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractionScript : MonoBehaviour
{

    private bool toggle = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            toggle = true;
            Debug.Log("Collision hit!");
        }
    }

    void Update()
    {
        if (toggle && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 0.85f);
        }
    }
}
