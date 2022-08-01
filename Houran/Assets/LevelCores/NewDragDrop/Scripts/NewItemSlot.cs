using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class NewItemSlot : MonoBehaviour , IDropHandler
{
    public RectTransform wordhouse;
    public static bool here = false , darkness = false;
    public string WordName;
    public GameObject  darktri , wordbox , SWordbox , thisWord , lightyyy;
    public Animator burnanim , lightt , Sburnanim;
   // public NewDDCanvas newDD;
  //  public int thisNum;
    public void OnDrop(PointerEventData eventData){
        if(eventData.pointerDrag != null){
            Debug.Log(eventData.pointerDrag.gameObject.name);
          //  eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;   
            if(eventData.pointerDrag.gameObject.name == WordName){
                here = true;
            }
            else {
             //   newDD.firstt[thisNum] = null;
              //  newDD.secondd[thisNum] = null;
                lightyyy.gameObject.tag = "darkened";
                here = false;
                darkness = true;
                darktri.SetActive(true);
               // wordbox.SetActive(false);
                burnanim.SetBool("burn" , true);
                Sburnanim.SetBool("burn" , true);
                wordbox.tag = "wrongb";
                SWordbox.tag = "wrongb";
                Invoke("wordboxdis" , 1.1f);
                lightt.SetBool("dark" , true);
                thisWord.SetActive(false);
            }
        }
    }

    void wordboxdis(){
        burnanim.SetBool("burn" , false);
        Sburnanim.SetBool("burn" , false);
    }
}
