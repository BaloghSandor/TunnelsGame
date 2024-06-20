using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sec_door_button_script : MonoBehaviour
{
    private bool interaction = false;
    private int change = 1;
    public GameObject door;
    public bool closed_door_1 = false;
    public Sec_door_button_script_2 sec_door_2;
    public Sec_door_button_script_3 sec_door_3;

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
        if(!sec_door_2.closed_door_2 && !sec_door_3.closed_door_3)
        {
            if(interaction && Input.GetKeyDown(KeyCode.E))
            {
                change *= -1;
            }
                        
            if(change == 1)
            {
                var rendering = gameObject.GetComponent<Renderer>();
                rendering.material.SetColor("_Color", Color.red);
                door.transform.position = new Vector3(door.transform.position.x, 23f, door.transform.position.z);
                closed_door_1 = false;
            }else
            {
                var rendering = gameObject.GetComponent<Renderer>();
                rendering.material.SetColor("_Color", Color.green);
                door.transform.position = new Vector3(door.transform.position.x, 8f, door.transform.position.z);
                closed_door_1 = true;
            }
        }
    }
}
