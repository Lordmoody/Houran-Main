using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.EventSystems;
 using UnityEngine.UI;

public class IconClicked : MonoBehaviour  
{
    public AudioSource ClickSound;
    public GameObject BuyMenu;
    public int RequiredLevel;
    public GameObject ErrorMenu;
    public BuyMenu buyMenuScript;
   // public int cost;
    public GameObject WordPanel;
    public Sprite thisWordSprite;
    public int j;
    public GameObject Blocker;
    public int num ;
    public TextController text;
    public Text LvlTxt;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown(){
       Blocker.SetActive(true);
            
            ClickSound.Play();
            pan.pann = false;
           /* if(this.gameObject.tag == "NotBought"){
                if(CoinManager.CurrentLevel >= RequiredLevel){
                 Invoke("Activation" , 0.2f);
                 
                 buyMenuScript.TheOneToBuy = this.gameObject;
                 buyMenuScript.Root = num;

                }
                else{
                 ErrorMenu.SetActive(true);
                }
            }*/
            //else if(this.gameObject.tag == "Bought"){
                if(CoinManager.CurrentLevel >= RequiredLevel){
                     WordPanel.SetActive(true);
                     TextController.i = j;
                     TextController.WordSprite = thisWordSprite;
                     text.ShowWord();
                }
                else{
                 LvlTxt.text = "Lvl: " + RequiredLevel;   
                 ErrorMenu.SetActive(true);
                }
            
            //}

        
    }

    void Activation(){
        BuyMenu.SetActive(true);
    }
    
}
