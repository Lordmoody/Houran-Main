using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableButtonPanel : MonoBehaviour
{
    public PanelItemGive panelItemGive;
    public GameObject[] NeedsToDisable;
    private void OnEnable(){
        if(TaskUIManager.EnteredChar != null && TaskUIManager.EnteredChar.gameObject.tag != "barrel"){
            foreach(GameObject dis in NeedsToDisable){
            dis.SetActive(false);
            }
        }   
    }
    public void OnVictory(){
        foreach(GameObject dis in NeedsToDisable){
            dis.SetActive(true);
        }
    }
}
