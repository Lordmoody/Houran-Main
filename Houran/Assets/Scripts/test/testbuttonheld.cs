using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class testbuttonheld : MonoBehaviour
{
    float lasttime;
    bool f = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPress(){
        if(f == false){
            Debug.Log("pressed");
        }
       
        
    }
    public void onhold(){
        Debug.Log("hold");
        f = true;
    }
}
