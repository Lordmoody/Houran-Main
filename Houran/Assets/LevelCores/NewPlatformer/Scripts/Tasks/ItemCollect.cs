using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{
    public TreeSpeechController treeSpeechController;
    public ItemController itemController;
    public LangController lang;
    public int arrayNum;
    public string ThisItemName;
    public int itemNum , NumInThis;
    public ParticleSystem PickUp;
    public AudioSource pickupSound; 
    public Button btn;  
    public Text wordPopop , transPopop;
    public Animator Canvanim;
    public Image WordImage;
    public Sprite WordSprite;
    public ControlSlowMo controlSlowMo;
    public TaskUIManager taskUIManager;
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "pplayer"){
            taskUIManager.Ticks[NumInThis].SetActive(true);
            CheckForGuide.ItemTillNow += 1;
            Debug.Log(CheckForGuide.ItemTillNow);
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Canvanim.SetTrigger("show");
            controlSlowMo.DoSlow();
            if(LangController.Lang == "Eng"){
                //treeSpeechController.StartSpeaking(lang.myPlayerList.player[itemNum].name);
                
                wordPopop.text = lang.myPlayerList.player[itemNum].name;
            }
            else if(LangController.Lang == "Fr"){
                //treeSpeechController.StartSpeaking(lang.myPlayerList.player[itemNum].fr);
                
                wordPopop.text = lang.myPlayerList.player[itemNum].fr;
            }
            WordImage.sprite = WordSprite;
            transPopop.text = lang.myPlayerList.player[itemNum].trans;
            ReadWord();
           // Canvanim.SetTrigger("pop");
           
           // itemController.itemsname = new string[itemController.itemsname.Length + 1];
            itemController.itemsname[arrayNum] = ThisItemName;
            btn.interactable = true;
            PickUp.Play();
            pickupSound.Play();
            Invoke("DisActiveItem" , 2f);
        }
    }

    void ReadWord(){
        if(LangController.Lang == "Eng"){
            treeSpeechController.StartSpeaking(lang.myPlayerList.player[itemNum].name);
        }
        else if(LangController.Lang == "Fr"){
            treeSpeechController.StartSpeaking(lang.myPlayerList.player[itemNum].fr);
        }
        
    }
    void DisActiveItem(){
        this.gameObject.SetActive(false);
    }
}
