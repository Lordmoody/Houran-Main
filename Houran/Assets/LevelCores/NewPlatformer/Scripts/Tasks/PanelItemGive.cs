using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelItemGive : MonoBehaviour
{
    public GameObject[] Buttons;
    public Image[] btnimages;
    public Text[] btntxts;
    
    
    public ItemController itemController;
    public static string InItem;
    public GameObject errorPanel;
    public Text errortext;
    public GameObject ThisPanel;
    public GameObject itempanel;
    public TaskUIManager taskUIManager;
    public Animator WrongAnim;
    public GameObject infoButton , treeButton;
    
    int ForRandom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetImages(){
        for(int i = 0; i < TaskUIManager.EnteredChar.GetComponent<SideCharacterController>().itemsSprites.Length ; i++){
            Buttons[i].SetActive(true);
            
            ForRandom = Random.Range(0 , TaskUIManager.EnteredChar.GetComponent<SideCharacterController>().itemsSprites.Length);
            if(TaskUIManager.EnteredChar.GetComponent<SideCharacterController>().itemsSprites[ForRandom] != null){
                btnimages[i].sprite = TaskUIManager.EnteredChar.GetComponent<SideCharacterController>().itemsSprites[ForRandom];
                Buttons[i].gameObject.name = TaskUIManager.EnteredChar.GetComponent<SideCharacterController>().myWordList.Words[ForRandom].name;
                btntxts[i].text = TaskUIManager.EnteredChar.GetComponent<SideCharacterController>().myWordList.Words[ForRandom].trans;
                TaskUIManager.EnteredChar.GetComponent<SideCharacterController>().itemsSprites[ForRandom] = null;
            }
            else{
                i--;
            }
            
        }
    }

    public void GiveThisItem(int j){
       // for(int i = 0; i < itemController.itemsname.Length ; i++){
            //if(TaskUIManager.EnteredChar.GetComponent<VictoryCheck>().ItemsToFinish[j] == itemController.itemsname[i]){
                if(Buttons[j].name == InItem){
                    itemController.GiveItem();
                    if(TaskUIManager.EnteredChar.gameObject.tag == "barrel"){
                        ThisPanel.SetActive(false);
                        itempanel.SetActive(false);
                        infoButton.SetActive(true);
                        treeButton.SetActive(true);
                    }
                    else if(TaskUIManager.EnteredChar.gameObject.tag == "Hub"){
                        TaskUIManager.EnteredChar.GetComponent<HubDoorTest>().ShowWordsForTest();
                    }
                    else if(TaskUIManager.EnteredChar.gameObject.tag == "Twin"){
                        GameObject TrueChar;
                        TrueChar = TaskUIManager.EnteredChar.GetComponent<MyFinishPoint>().FinishPoint;
                        TrueChar.GetComponent<TestForAll>().ShowWordsForTest();
                    }
                    else {
                        TaskUIManager.EnteredChar.GetComponent<TestForAll>().ShowWordsForTest();
                    }
                    Buttons[j].GetComponent<Button>().interactable = false;
                    TaskUIManager.EnteredChar.GetComponent<VictoryCheck>().CheckVictory(Buttons[j].name);
                    return;
                }
                else{
                    WrongAnim.SetTrigger("wrong");
                }
            //}
        //}
        
    }


    public void CloseButton(){
         errorPanel.SetActive(false);
    }
}
