using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{
    public float speed = 23.0F;
    private Transform target;
    public GameObject player;
    
    // Start is called before the first frame update
    void Awake()
    {
        // Position the cube at the origin.
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        // Grab cylinder values and place on the target.
        target = player.Transform;
        target.transform.position = new Vector3(0.8f, 0.0f, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        var step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
