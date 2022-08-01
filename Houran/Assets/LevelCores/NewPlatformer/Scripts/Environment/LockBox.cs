using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LockBox : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "pushable"){
            other.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            
        }
    }
}
