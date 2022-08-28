using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLvl3 : MonoBehaviour
{
     
    public doorOpener doorOpener;
    bool Opened = false;


     void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "pplayer" && Opened == false){
            doorOpener.OpenDoor();
            Opened = true;
        }   
    }
}
