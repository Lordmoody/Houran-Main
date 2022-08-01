using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestForAll : MonoBehaviour
{
    
    public GameObject HubPanel;
    public GameObject ItemPanel;
    public Text wordText;
    public SideCharacterController sideCharacter;
    public int ItemNumFromHere;
    int i = 0;
    public GameObject VertCont , HorzCont , infoButton;


    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "pplayer" && sideCharacter.ThisTskAccepted == true){
            if(CheckForGuide.OnAllCollected == true){
                HubPanel.SetActive(true);
                ItemPanel.SetActive(true);
                VertCont.SetActive(false);
                infoButton.SetActive(false);
                NewPlayerMovementP.HorizValue = 0;
                HorzCont.SetActive(false);
                ShowWordsForTest();
                CheckForGuide.OnAllCollected = false;
            }
        }
    }


    public void ShowWordsForTest(){
        if(i < sideCharacter.thisendnum){
            PanelItemGive.InItem = sideCharacter.myWordList.Words[i].name;
            ItemController.ItemNum = ItemNumFromHere;
            if(LangController.Lang == "Eng"){
                wordText.text = sideCharacter.myWordList.Words[i].name;
            }
            else if(LangController.Lang == "Fr"){
                wordText.text = sideCharacter.myWordList.Words[i].fr;
            }
            i++;
            ItemNumFromHere++;
        }
        else if(i >= sideCharacter.thisendnum){
            i = 0;
        }
    }
}
