using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    
    public GameObject switchB;
    public GameObject stairs , changeswitch , swithcs;
    public Animator stairss , stairlight;
    public GameObject secondSwitch;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "pplayer"){
            switchB.SetActive(true);
            CanvasController.Stairs = stairs;
            CanvasController.changeswitch = changeswitch;
            CanvasController.switchs = swithcs;
            CanvasController.stairlight = stairlight;
            CanvasController.stairss = stairss;
            CanvasController.secswitch = secondSwitch;
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "pplayer"){
            switchB.SetActive(false);
            
        }
    }
}
