using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRingsClick : MonoBehaviour
{
    public GameObject MainRoot;
    
    public CinemachinSwitcher cineswitch;
    public static GameObject CurrentSubCine;
    public GameObject BackButton;
    
    public GameObject[] blockers;
    public GameObject CloseButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubClicked(GameObject camera){
        foreach(GameObject bl in blockers){
            bl.SetActive(true);
        }
        CloseButton.SetActive(false);
        MainRoot.SetActive(false);
        camera.SetActive(true);
        CurrentSubCine = camera;
        cineswitch.SwitchToSub();
        pan.WhichState = "Sub";
        BackButton.SetActive(true);
        Invoke("DisBlockers" , 2f);
    }

    public void MainClicked(){
        foreach(GameObject bl in blockers){
            bl.SetActive(true);
        }
        CloseButton.SetActive(true);
        MainRoot.SetActive(true);
        CurrentSubCine.SetActive(false);
        cineswitch.SwitchToMain();
        pan.WhichState = "Main";
        BackButton.SetActive(false);
        Invoke("DisBlockers" , 2f);
    }


    void DisBlockers(){
        foreach(GameObject bl in blockers){
            bl.SetActive(false);
        }
    }
}
