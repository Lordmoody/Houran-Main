using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDestination : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "1"){
            print(other.gameObject.name);
            CharMovements.ForwardKnob = other.gameObject;
            
        }
    }
}
