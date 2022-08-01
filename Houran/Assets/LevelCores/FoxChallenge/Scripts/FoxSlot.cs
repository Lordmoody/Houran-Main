using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class FoxSlot : MonoBehaviour , IDropHandler
{
    public static bool here = false;
    public static bool fwrong = false;
    public static bool secWrong = false;
    public static int wc = 0;

    public void OnDrop(PointerEventData eventData){
        if(eventData.pointerDrag != null){
            if(eventData.pointerDrag.gameObject.name == FoxCanvas.CorrectWord){
                here = true;
                this.GetComponent<AudioSource>().Play();
            }
            else{
                this.GetComponent<AudioSource>().Play();
                if(wc == 0){
                    wc += 1;
                    fwrong = true;
                }
                else if(wc > 0){
                    secWrong = true;
                    fwrong = false;
                    wc = 0;
                }
                
            }
        }
    }
}
