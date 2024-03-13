using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{
    public float speed = 11.0F;
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        var step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(GameObject.Find("Player").transform.position.x, 1.5F, GameObject.Find("Player").transform.position.z), step);
    }
}