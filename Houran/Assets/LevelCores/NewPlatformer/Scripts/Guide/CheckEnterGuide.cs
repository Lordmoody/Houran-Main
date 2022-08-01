using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnterGuide : MonoBehaviour
{
    public string thisGuide , thisTrans;
    public ControlGuide controlGuide;
    public float TimeToCancel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player" && ControlGuide.FirstTime == true){
            ControlGuide.CurrentGuide = thisGuide;
            ControlGuide.CurrentTransition = thisTrans;
            controlGuide.PlayAnim(thisTrans , TimeToCancel);
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            Destroy(this.gameObject);
        }
    }
    
}
