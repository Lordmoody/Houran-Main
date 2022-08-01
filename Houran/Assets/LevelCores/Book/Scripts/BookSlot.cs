using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BookSlot : MonoBehaviour , IDropHandler
{
    public static bool here = false;

    public void OnDrop(PointerEventData eventData){
        if(eventData.pointerDrag != null){
            if(eventData.pointerDrag.gameObject.name == "nozha"){
                eventData.pointerDrag.gameObject.tag = "chosen";
                here = true;
            }
            else if(eventData.pointerDrag.gameObject.name == "karen"){
                eventData.pointerDrag.gameObject.tag = "chosen";
                here = true;
            }
            else if(eventData.pointerDrag.gameObject.name == "romak"){
                eventData.pointerDrag.gameObject.tag = "chosen";
                here = true;
            }
            else if(eventData.pointerDrag.gameObject.name == "avat"){
                eventData.pointerDrag.gameObject.tag = "chosen";
                here = true;
            }
            else{

            }
        }
    }
}
