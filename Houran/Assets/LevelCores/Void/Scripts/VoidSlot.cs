using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VoidSlot : MonoBehaviour, IDropHandler
{
    public static bool here = false;
    public static string CorrectOne;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData){
        if(eventData.pointerDrag != null){
            if(eventData.pointerDrag.gameObject.tag == CorrectOne){
                here = true;
            }
            else{
                here = false;
                VoidDrag.Incorrect = true;
            }
        }
    }
}
