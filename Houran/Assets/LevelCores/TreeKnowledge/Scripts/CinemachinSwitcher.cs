using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachinSwitcher : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Awaken(){
        
    }
    public void SwitchToMain(){
        anim.Play("MainState");
    }
    public void SwitchToSub(){
        anim.Play("SubState");
    }
    public void SwitchToPlatformer(){
        anim.Play("TreeState");
    }
    public void SwitchToFar(){
        anim.Play("FarCam");
    }

    
}
