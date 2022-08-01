using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyEffect : MonoBehaviour
{
    public _2dxFX_Jelly jelly;
    
    bool stillIn = false;
    

    

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            jelly.Heat = 4f;
            stillIn = true;
            NewPlayerMovementP.BounceLanded = true;
            
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            stillIn = false;
            Invoke("Lesser" , 5f);
            
            
        }
    }

    void Lesser(){
        if(stillIn == false){
            jelly.Heat = 0;
        }
    }
  
}
