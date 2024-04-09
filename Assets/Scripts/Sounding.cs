using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour{
    void Start(){

    }

    void Update(){

        if (Input.GetKeyDown(KeyCode.LeftShift)){

            transform.localScale = new Vector3(10.0f, 10.0f, 10.0f);
                  }
        if (Input.GetKeyUp(KeyCode.LeftShift)){
            transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);

        }
    }
}
