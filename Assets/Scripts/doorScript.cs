using UnityEngine;
using System.Collections;
 
public class doorScript : MonoBehaviour
{
//box collider to see if player is near the door
     public Collider theCollider;
     public Canvas doortext;
     public bool doorisClosed;
//I added the following line for referencing the animator
     public Animator anim;
 
 
     void Awake ()
     {
          theCollider = GetComponent <BoxCollider> ();
          doortext = doortext.GetComponent<Canvas> ();
          doortext.enabled = false;
//to get the animator component
          anim = GetComponent<Animator> ();
     }
 
     void Update ()
     {
          if (doortext.enabled == true && (Input.GetKeyDown(KeyCode.R)))
          {
               StartCoroutine ("changeDoorState");
          }
     }
 
     IEnumerator changeDoorState ()
     {
          if (doorisClosed == true)
          {
               anim.Play("doorOpen");
               doorisClosed = false;
               yield return new WaitForSeconds (5);
               anim.Play ("doorClose");
               doorisClosed = true;
          }
     }
 
     void OnTriggerEnter(Collider other)
     {
          if(other.gameObject.tag == "Player")
          {
               doortext.enabled = true;
          }
     }
 
     void OnTriggerExit(Collider other)
     {
          if (other.gameObject.tag == "Player")
          {
               doortext.enabled = false;
          }
     }
}
 