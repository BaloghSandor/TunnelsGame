using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery_script : MonoBehaviour
{

    private bool interaction = false;
    public GameObject battery;
    public Inventory_Toolbar_script inventory;

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
            battery.gameObject.SetActive(false);
            inventory.item_count += 1;
        }
    }
}
