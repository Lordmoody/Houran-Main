using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject ButtonTeleport;
    public Transform NextPos;
    public CanvasController canvasController;
    public GameObject effecttele;
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
            ButtonTeleport.SetActive(true);
            canvasController.thispos = NextPos;
            CanvasController.teleeffect = effecttele;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "pplayer"){
            ButtonTeleport.SetActive(false);
            
        }
    }
}
