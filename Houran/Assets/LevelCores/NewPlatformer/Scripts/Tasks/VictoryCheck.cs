using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class VictoryCheck : MonoBehaviour
{
    public string[] ItemsToFinish;
    public ItemController itemController;
    int progress = 0;
    public int neededprogress;
    public GameObject PanelVictory;
    public AudioSource victorySound;
    public GameObject infoButton;
    public GameObject[] itemBtns;
    public GameObject ItemPanel , HubPanel;
    public SideCharacterController sideCharacter;
    public UnityEvent VictoryEvent , StartEvent;
    public GameObject VertCont , HorzCont;

    GameObject ToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("forStart" , 1f);
        Debug.Log(sideCharacter.ThisisDone);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void forStart(){
        if(sideCharacter.ThisisDone == true){
            Debug.Log("true");
            StartEvent.Invoke();
        }
    }

    public void CheckVictory(string ItemCheck){
        for(int i = 0; i < ItemsToFinish.Length ; i++){
            if(ItemsToFinish[i] == ItemCheck){
                if(progress < neededprogress){
                    progress += 1;
                    Debug.Log(progress);
                }
            }
        }
        if(progress == neededprogress){
            
            sideCharacter.ThisisDone = true;
            sideCharacter.AddToList();
            sideCharacter.ThisTskAccepted = false;
            PanelVictory.SetActive(true);
            CheckForGuide.OnAllCollected = false;
            CheckForGuide.EndGuid = true;
            victorySound.Play();
            infoButton.SetActive(false);
            CoinManager.CurrentLevel +=1;
            ToDestroy = TaskUIManager.EnteredChar;
            Destroy(ToDestroy , 5f);
            TaskUIManager.EnteredChar = null;
            ItemPanel.SetActive(false);
            HubPanel.SetActive(false);
            HorzCont.SetActive(true);
            VertCont.SetActive(true);
             VictoryEvent.Invoke();
            foreach(GameObject btn in itemBtns){
                btn.SetActive(false);
            }
        }
    }


    
}
