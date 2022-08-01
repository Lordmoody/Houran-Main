using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushableBox : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            
                other.gameObject.GetComponent<NewPlayerMovementP>().IsPushing = true;
            
            
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            
         other.gameObject.GetComponent<NewPlayerMovementP>().IsPushing = false;
            
        }
    }
}
