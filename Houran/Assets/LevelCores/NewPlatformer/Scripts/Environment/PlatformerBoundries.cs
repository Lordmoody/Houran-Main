using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformerBoundries : MonoBehaviour
{
    public MovingPlatform movingPlatform;
    public UnityEvent OnIn , OnOut;
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "pplayer"){
            movingPlatform.InBound = true;
            movingPlatform.InBoundObject = other.gameObject.GetComponent<ShowYourParent>().MyParent;
            OnIn.Invoke();
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "pplayer"){
            movingPlatform.InBound = false;
            OnOut.Invoke();
        }
    }
}
