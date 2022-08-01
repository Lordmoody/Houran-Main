using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckForGuide : MonoBehaviour
{
    public static int Targetnum = 1;
    public static int ItemTillNow = 0;
    public static bool EndGuid;
    public GameObject GuideButton;
    public GameObject PathFinder;
    public GameObject Pointer;
    GameObject currentBirth;

    public static bool OnAllCollected = false;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(ItemTillNow == Targetnum){
            GuideButton.SetActive(true);
            Pointer.SetActive(true);
            OnAllCollected = true;
            ItemTillNow = 0;
        }
        if(EndGuid == true){
            GuideButton.SetActive(false);
            Pointer.SetActive(false);
            EndGuid = false;
        }
    }
    void Dis(){
        
    }

    public void Guidehimher(){
        currentBirth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().GuideBirth;
        if(GameObject.FindGameObjectWithTag("GuideSoul") != null){
            Destroy(GameObject.FindGameObjectWithTag("GuideSoul"));
        }
        Instantiate(PathFinder , currentBirth.transform.position , Quaternion.identity);
    }

    
}
