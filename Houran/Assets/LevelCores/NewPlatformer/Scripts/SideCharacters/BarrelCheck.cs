using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrelCheck : MonoBehaviour
{
    public string ItemName;
    
    public ItemController itemController;
    public GameObject GiveButton;
    public Animator animator;
    public GameObject Panel;
    public Text PanelText;
    public string thisTsk;
    public TaskUIManager taskUIManager;
    public int ThisNum;
    public bool Collected = false;
    public LangController langController;
    public int NumForWord;
    public SideCharacterController sideCharacter;
    public GameObject BookIcon , InfoIcon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
        if(taskUIManager.CurrentChild != null && Collected == false){
            if(sideCharacter.ThisisDone == false){
                
                PanelItemGive.InItem = sideCharacter.myWordList.Words[ThisNum].name;
                Panel.SetActive(true);
                if(LangController.Lang == "Eng"){
                    PanelText.text = langController.myPlayerList.player[NumForWord].name;
                }
                else if(LangController.Lang == "Fr"){
                    PanelText.text = langController.myPlayerList.player[NumForWord].fr;
                }
            
           // animator.SetBool( "Up",true);
                for(int i = 0; i < itemController.itemsname.Length ; i++){
                    if(itemController.itemsname[i] == ItemName){
                        GiveButton.SetActive(true);
                        BookIcon.SetActive(false);
                        InfoIcon.SetActive(false);
                        ItemController.ItemNum = ThisNum;
                    }
                }
                for(int i = 0; i < itemController.ItemsCollected.Length ; i++){
                    if(itemController.ItemsCollected[i] == ItemName){
                     Collected = true;
                    }
                }
             
            }
        }   
        }
        
        
    }

    void OnTriggerExit2D(Collider2D other){
        //if(taskUIManager.CurrentChild != null){
            //if(taskUIManager.CurrentChild.name == thisTsk){
            if(other.gameObject.tag == "Player"){
                
                if(sideCharacter.ThisTskAccepted == true){
                    
                    // animator.SetBool( "Up",false);
                    // animator.SetTrigger("Down");
                    GiveButton.SetActive(false);
                    Panel.SetActive(false);
                    //Invoke("DisActivator" , 0.4f);
                }
                else if(sideCharacter.ThisisDone == true){
                    
                    GiveButton.SetActive(false);
                    Panel.SetActive(false);
                }
                
            }
         //}
       // }
        
        
    }


    void DisActivator(){
        Panel.SetActive(false);
    }
}
