using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerThePlatform : MonoBehaviour
{
    
    public SideCharacterController sideCharacter;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    public void ForAccepted()
    {
        if(sideCharacter.ThisTskAccepted == true ){
            GameObject.FindGameObjectWithTag("platform1").GetComponent<MovingPlatform>().gonow = true;
        }
    }
}
