using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitObstaclesDD : MonoBehaviour
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
        karencontDD.disobscatcher = true;
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "char"){
            print(karencontDD.disobscatcher);
            if(karencontDD.disobscatcher == true){
                charhitted = true;
                karencontDD.nowobscore = this.gameObject;
            }
            else if(karencontDD.disobscatcher == false){
               karencontDD.disobscatcher = true;
            }
            
        }
    }
}
