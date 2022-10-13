using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamSize : MonoBehaviour
{

    public bool Far = false , Close = false;

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "pplayer"){
            if(Far == true){
                GameObject.Find("TreeCamerasStateDriven").GetComponent<CinemachinSwitcher>().SwitchToFar();
                Far = false;
            }
            else if(Close == true){
                GameObject.Find("TreeCamerasStateDriven").GetComponent<CinemachinSwitcher>().SwitchToPlatformer();
                Close = false;
            }
            
        }
    }
}
