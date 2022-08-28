using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoThatVictoryThing : MonoBehaviour
{

    public UnityEvent AfterMissionDone;


    public void DoAfterVictory(){
        AfterMissionDone.Invoke();
    }
    
}
