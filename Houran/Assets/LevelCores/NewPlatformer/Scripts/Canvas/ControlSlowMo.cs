using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSlowMo : MonoBehaviour
{
    

    public void DoSlow(){
        Time.timeScale = 0.2f;
        Invoke("StopSlowMo" , 1f);

    }

    void StopSlowMo(){
        Time.timeScale = 1f;
    }
}
