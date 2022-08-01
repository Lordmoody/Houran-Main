using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour
{
    public Sprite padOn , padOff;
    public SpriteRenderer pressurePad;
    public UnityEvent OnDown , OnUp , DownWithBox;
    bool BoxOn = false;

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player" && BoxOn == false){
            pressurePad.sprite = padOn;
            OnDown.Invoke();
        }
        if(other.gameObject.tag == "pushable"){
            pressurePad.sprite = padOn;
            OnDown.Invoke();
            DownWithBox.Invoke();
            BoxOn = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player" && BoxOn == false){
            pressurePad.sprite = padOff;
            OnUp.Invoke();
        }
        if(other.gameObject.tag == "pushable"){
            pressurePad.sprite = padOff;
            OnUp.Invoke();
            BoxOn = false;
        }
    }

}
