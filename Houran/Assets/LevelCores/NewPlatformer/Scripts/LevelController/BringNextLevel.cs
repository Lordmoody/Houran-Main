using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BringNextLevel : MonoBehaviour
{
    public int nextEnvNum;
    private GameObject Fader;
    
     void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "pplayer"){
            if(CoinManager.CurrentLevel >= nextEnvNum){
                LevelEnvController.LevelNumber = nextEnvNum;
                Fader = GameObject.FindGameObjectWithTag("off");
               // Fader.SetActive(true);
                Fader.GetComponent<Animator>().SetBool("fade" , true);
                Invoke("ForEvent" , 1f);
                
            }
            
        }    
    }


    void ForEvent(){
        GameObject.FindGameObjectWithTag("EnvBase").GetComponent<LevelEnvController>().ChangeEnvironment();
    }

    
    
}
