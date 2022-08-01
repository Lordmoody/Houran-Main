using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitObstacles1 : MonoBehaviour
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
        karencont1.disobscatcher = true;
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "char"){
            print(karencont1.disobscatcher);
            if(karencont1.disobscatcher == true){
                charhitted = true;
                karencont1.nowobscore = this.gameObject;
            }
            else if(karencont1.disobscatcher == false){
               karencont1.disobscatcher = true;
            }
            
        }
    }
}
