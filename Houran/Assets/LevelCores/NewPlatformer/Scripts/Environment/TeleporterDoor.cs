using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterDoor : MonoBehaviour
{
     ItemController itemController;
    public int missionNumb;
    public GameObject Black;
    public Animator TeleAnim;
    public GameObject lightt;
    // Start is called before the first frame update
    void Start()
    {
        itemController = GameObject.FindGameObjectWithTag("EnvBase").GetComponent<ItemController>();
        if(itemController.MissionsDone[missionNumb] == true){
            TurnOnTeleporter();
        }
    }

    
    void TurnOnTeleporter(){
        Black.SetActive(false);
        TeleAnim.SetBool("teleon" , true);
        lightt.SetActive(true);
    }

}
