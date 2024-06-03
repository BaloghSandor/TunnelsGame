using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Slot_script1 : MonoBehaviour
{
    public Inventory_Toolbar_script inventory;
    public GameObject slot;

    // Update is called once per frame
    void Update()
    {
        if(!inventory.item_1)
        {
            slot.transform.GetChild(0).gameObject.SetActive(false);
        } else {
            slot.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
