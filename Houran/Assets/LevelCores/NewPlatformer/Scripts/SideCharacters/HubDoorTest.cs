using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HubDoorTest : MonoBehaviour
{
    
    public GameObject HubPanel;
    public GameObject ItemPanel;
    public Text wordText;
    public SideCharacterController sideCharacter;
    public int ItemNumFromHere;
    int i = 0;
    public GameObject VertCont , HorzCont , infoButton;
    


    public GameObject Door;
    public Vector2 positionToOpen;
    bool openIt = false;
    public ParticleSystem OpeningParticle;
    public AudioSource openingSound;


   
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player" && sideCharacter.ThisTskAccepted == true){
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
    void Update(){
        

        if(openIt == true){
            if(Vector2.Distance(Door.transform.position , positionToOpen) >= 0.1f){
                 Door.transform.position = Vector2.MoveTowards(Door.transform.position , positionToOpen , Time.deltaTime * 3);
            }
            else{
                openIt = false;
                OpeningParticle.Stop();
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

    
    public void OpenDoor(){
        openIt = true;
        openingSound.Play();
        OpeningParticle.Play();
        VertCont.SetActive(true);
        HorzCont.SetActive(true);
        i = 0;
    }

   
}
