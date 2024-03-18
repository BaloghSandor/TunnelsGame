using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP_AI : MonoBehaviour
{

    public float speed = 11.0F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 20f)){
            Debug.Log("Hit Something");
        } else{
            Debug.Log("Hit nothing");
        }



        transform.LookAt(Vector3.zero);
    }
}
