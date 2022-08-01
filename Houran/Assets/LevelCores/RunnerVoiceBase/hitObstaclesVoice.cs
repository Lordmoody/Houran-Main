using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitObstaclesVoice : MonoBehaviour
{
    public static bool charhitted = false;
    // Start is called before the first frame update
    void Start()
    {
        charhitted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void enablethen(){
        karencontVoice.disobscatcher = true;
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "char"){
            print(karencontVoice.disobscatcher);
            if(karencontVoice.disobscatcher == true){
                charhitted = true;
                karencontVoice.nowobscore = this.gameObject;
            }
            else if(karencontVoice.disobscatcher == false){
               karencontVoice.disobscatcher = true;
            }
            
        }
    }
}
