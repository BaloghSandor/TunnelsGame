using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovementScript : MonoBehaviour
{
    public GameObject specificObject; // The other GameObject to detect collision with

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is the specific object
        if (collision.gameObject == specificObject)
        {
            Debug.Log("Collision detected with the specific object!");
            // Handle the collision
        }
    }

    void FixedUpdate() 
    {
    Rigidbody rb = GetComponent<Rigidbody>();
    rb.velocity = new Vector3(-1, 0, 0);
    }
}
