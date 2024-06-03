using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_Drop_off_script : MonoBehaviour
{

    private bool interaction = false;
    public Inventory_Toolbar_script inventory;
    public GameObject drop_off;
    public int item_dropped_off = 0;
    public bool first_demo_level_finished = false;

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
        if(interaction && Input.GetKeyDown(KeyCode.E) && inventory.item_count >= 1)
        {
            item_dropped_off += 1;
            inventory.item_count -= 1;
            drop_off.transform.GetChild(item_dropped_off - 1).gameObject.SetActive(true);
        }

        if(item_dropped_off == 4)
        {
            first_demo_level_finished = true;
        }
    }
}
