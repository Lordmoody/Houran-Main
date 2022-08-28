using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleporterDoor : MonoBehaviour
{
    ItemController itemController;
    public int missionNumb;
    public GameObject Black;
    public Animator TeleAnim;
    public GameObject lightt;
    public Image Circle;
    bool Complete = false;
    public int nextEnvNum;
    private GameObject Fader;
    // Start is called before the first frame update
    void Start()
    {
        itemController = GameObject.FindGameObjectWithTag("EnvBase").GetComponent<ItemController>();
        if(itemController.MissionsDone[missionNumb] == true){
            TurnOnTeleporter();
        }
    }

    void Update(){
        if(Complete == true){
            if(Circle.fillAmount != 1){
                Circle.fillAmount = Circle.fillAmount + Time.deltaTime;
            }
            else if(Circle.fillAmount == 1){
                GoNextLvl();
                Complete = false;
                Circle.fillAmount = 0;
            }
            
        }
        else{
            if(Circle.fillAmount != 0){
                Circle.fillAmount = Circle.fillAmount - Time.deltaTime;
            }
        }
    }
    public void TurnOnTeleporter(){
        Black.SetActive(false);
        TeleAnim.SetBool("teleon" , true);
        lightt.SetActive(true);
    }

     void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "pplayer"){
            if(itemController.MissionsDone[missionNumb] == true){
                Complete = true;
            }
           
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "pplayer"){
            if(itemController.MissionsDone[missionNumb] == true){
                Complete = false;
            }
        }
    }
    
    void GoNextLvl(){
        if(CoinManager.CurrentLevel >= nextEnvNum){
                LevelEnvController.LevelNumber = nextEnvNum;
                Fader = GameObject.FindGameObjectWithTag("off");
               // Fader.SetActive(true);
                Fader.GetComponent<Animator>().SetBool("fade" , true);
                Invoke("ForEvent" , 1f);
        }
    }
    void ForEvent(){
        GameObject.FindGameObjectWithTag("EnvBase").GetComponent<LevelEnvController>().ChangeEnvironment();
    }

   
}
