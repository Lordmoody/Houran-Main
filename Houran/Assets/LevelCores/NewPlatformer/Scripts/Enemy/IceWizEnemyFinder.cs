using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWizEnemyFinder : MonoBehaviour
{
    public static GameObject PlayerTarget;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("PlayerCore");
    }

    
}
