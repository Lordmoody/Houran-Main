using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitObstacles : MonoBehaviour
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
        karencont.disobscatcher = true;
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "char"){
            print(karencont.disobscatcher);
            if(karencont.disobscatcher == true){
                charhitted = true;
                karencont.nowobscore = this.gameObject;
            }
            else if(karencont.disobscatcher == false){
               karencont.disobscatcher = true;
            }
            
        }
    }
}
