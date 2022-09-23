using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelEnvController : MonoBehaviour
{
    public static int LevelNumber = 1;
    private int CurrentLevel = 1;
    public GameObject[] Envss;
    public Transform[] LevelPos; 
    public Transform[] forwardPos;
    public Transform[] backwardPos;
    public Transform EnvParent;
    GameObject GeneratedLevel;
    public Script script;
    private GameObject Currentlevelenv;

    public GameObject[] MissionHolders;
    public GameObject[] TskItems;
    public ItemController itemController;

    public Animator Fader;

    public UnityEvent OnNextLvl;
    
    // Start is called before the first frame update
    void Start()
    {
        StartGenerate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGenerate(){
        //if(SaveDatasPlayer.notFound == false){
            CurrentLevel = LevelNumber;
            GeneratedLevel = Instantiate(Envss[LevelNumber - 1] , LevelPos[LevelNumber - 1].position , Quaternion.identity);
            GeneratedLevel.transform.SetParent(EnvParent);
            script.CurrentCharacter.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            if(SaveDatasPlayer.notFound == false && LevelNumber == 5){
                script.CurrentCharacter.gameObject.transform.position = forwardPos[LevelNumber-1].position;
            }
            Currentlevelenv = GeneratedLevel;
            for(int i = 0; i < MissionHolders.Length ; i++){
                if(itemController.AllMissions[i].ThisisDone == true){
                    if(LevelNumber <= i){
                        Destroy(MissionHolders[i]);
                        Destroy(TskItems[i]);
                    }
                    else if(LevelNumber > i){
                        Destroy(MissionHolders[i]);
                        Destroy(TskItems[i]);
                    }
                    
                }
                else if(itemController.AllMissions[i].ThisisDone == false){
                    if(LevelNumber == i){
                        MissionHolders[i].SetActive(true);
                    }
                }
            }
        //}
        
    }

    public void ChangeEnvironment(){
        script.CurrentCharacter.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        if(LevelNumber < CurrentLevel){
            Destroy(Currentlevelenv);
            Invoke("ForBackward" , 0.5f);
        }
        else if(LevelNumber > CurrentLevel){
            Destroy(Currentlevelenv);
            Invoke("ForForward" , 0.5f);
        }
        Invoke("PlayFade" , 4f);
    }
    void ForForward(){
            if(LevelNumber >= CoinManager.CurrentLevel){
                MissionHolders[LevelNumber].SetActive(true);
            }
            GeneratedLevel = Instantiate(Envss[LevelNumber - 1] , LevelPos[LevelNumber - 1].position , Quaternion.identity);
            GeneratedLevel.transform.SetParent(EnvParent);
            script.CurrentCharacter.transform.position = forwardPos[LevelNumber - 1 ].position;
            Currentlevelenv = GeneratedLevel;
            CurrentLevel = LevelNumber;
            script.CurrentCharacter.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            OnNextLvl.Invoke();
    }

    void ForBackward(){
            GeneratedLevel = Instantiate(Envss[LevelNumber - 1] , LevelPos[LevelNumber - 1].position , Quaternion.identity);
            GeneratedLevel.transform.SetParent(EnvParent);
            script.CurrentCharacter.transform.position = backwardPos[LevelNumber - 1 ].position;
            Currentlevelenv = GeneratedLevel;
            CurrentLevel = LevelNumber;
            script.CurrentCharacter.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    void PlayFade(){
        Fader.SetBool("fade" , false);
        Fader.SetTrigger("out");
    }

    
    
}
