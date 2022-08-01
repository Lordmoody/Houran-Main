using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGuide : MonoBehaviour
{
    public static string CurrentGuide;
    public static string CurrentTransition;
    public static bool FirstTime = true;
    public Animator guideAnim;



    // Start is called before the first frame update
    void Start()
    {
        if(FirstTime == true){
            CurrentGuide = "Moveguide";
            CurrentTransition = "move";
            PlayAnim("move" , 5f);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
       
    }

    public void CancelAnim(string name , string trans){
        if(guideAnim.GetCurrentAnimatorStateInfo(0).IsName(name)){
            guideAnim.SetBool(trans , false);
        }
    }
    public void PlayAnim(string trans , float time){
        guideAnim.SetBool(trans , true);
        Invoke("ForCancel" , time);
    }
    void ForCancel(){
        CancelAnim(CurrentGuide , CurrentTransition);
    }
}
