using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeEvent : MonoBehaviour
{
    
    public SpriteRenderer bridgeSprite;
    public GameObject Bridge;
        


    public void OnDeath(){
        bridgeSprite.enabled = false;
        Bridge.SetActive(false);
    }    
}
