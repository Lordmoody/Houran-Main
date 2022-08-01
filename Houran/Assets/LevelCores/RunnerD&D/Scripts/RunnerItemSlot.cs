using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RunnerItemSlot : MonoBehaviour , IDropHandler
{
    
    public canvascontDD cdd;
    public static bool NotHere = true;
    public RectTransform jumphome , sithome , walkhome , runhome;
    public void OnDrop(PointerEventData eventData){
        if(eventData.pointerDrag != null){
          //  eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
          //  NotHere = false;   
            if(eventData.pointerDrag.gameObject.name == "Bridge"){
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = jumphome.anchoredPosition;
                cdd.jumpb();
            }   
            else if(eventData.pointerDrag.gameObject.name == "TurnOff"){
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = sithome.anchoredPosition;
                cdd.sitdownb();
            }
            else if(eventData.pointerDrag.gameObject.name == "walk"){
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = walkhome.anchoredPosition;
                cdd.walkb();
            }
            else if(eventData.pointerDrag.gameObject.name == "sprint"){
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = runhome.anchoredPosition;
                cdd.runb();
            }
        }
    }
}
