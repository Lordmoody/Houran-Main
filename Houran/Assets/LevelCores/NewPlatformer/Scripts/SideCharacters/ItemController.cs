using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    
    public string[] itemsname;
    public string[] ItemsCollected;
    public static int ItemNum;
    public GameObject GiveButton;
    public AudioSource GiveSound;
    
    
    
    public ParticleSystem GiveParticle;
    public static GameObject CurretQuestMaster;
    public TreeSpeechController treeSpeechController;

    //forSave
    public SideCharacterController[]  AllMissions;
    public bool[] MissionsDone;
    ///
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveItem(){
       // ItemsCollected = new string[itemsname.Length];
       treeSpeechController.StartSpeaking(itemsname[ItemNum]);
        ItemsCollected[ItemNum] = itemsname[ItemNum];
        itemsname[ItemNum] = itemsname[ItemNum] + "Done";
        GiveButton.SetActive(false);
        GiveSound.Play();
        GiveParticle.Play();
        if(TaskUIManager.EnteredChar.GetComponent<Animator>() != null){
            TaskUIManager.EnteredChar.GetComponent<Animator>().SetTrigger("Happy");
        }
        
    }
}
