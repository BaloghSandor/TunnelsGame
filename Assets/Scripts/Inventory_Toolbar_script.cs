using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Toolbar_script : MonoBehaviour
{
    public int item_count;
    public bool item_1 = false;
    public bool item_2 = false;
    public bool item_3 = false;
    public bool item_4 = false;
    // Start is called before the first frame update
    void Start()
    {
        item_count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(item_count >= 1)
        {
            item_1 = true;
        } else{
            item_1 = false;
        }

        if(item_count >= 2)
        {
            item_2 = true;
        } else{
            item_2 = false;
        }

        if(item_count >= 3)
        {
            item_3 = true;
        } else{
            item_3 = false;
        }

        if(item_count == 4)
        {
            item_4 = true;
        } else{
            item_4 = false;
        }

        if(item_count <= 0)
        {
            item_count = 0;
        }
    }
}
