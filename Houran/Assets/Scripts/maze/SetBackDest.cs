using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBackDest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "1"){
            CharMovements.lastKnob = other.gameObject;
            print(other.gameObject.name);
        }
        
    }
}
