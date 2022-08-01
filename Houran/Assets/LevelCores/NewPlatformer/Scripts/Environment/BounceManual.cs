using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BounceManual : MonoBehaviour
{
    
    public float thrust;
    Vector3 LastVelocity;
    public UnityEvent OnBounce;
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
          //  other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * thrust , ForceMode2D.Impulse);
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * thrust;
            OnBounce.Invoke();
            
        }
    }
}
