using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToLevel : MonoBehaviour
{
    public GameObject ShowLevel;
    public Animator levelshower;
    public GameObject ButtonGo;
    public string thisscene;
    public int posofThis;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RevFalse(){
        levelshower.SetBool("rev" , false);
    }
    void DisActive(){
        ShowLevel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "pplayer"){
            CanvasController.forPos = posofThis;
            CanvasController.levelname = thisscene;
            ShowLevel.SetActive(true);
            levelshower.SetBool("show" , true);
            ButtonGo.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "pplayer"){
           // ShowLevel.SetActive(false);
            levelshower.SetBool("rev" , true);
            ButtonGo.SetActive(false);
            Invoke("RevFalse" , 1.5f);
            Invoke("DisActive" , 2f);
        }
    }
}
