using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchers : MonoBehaviour
{
    public static bool passed = false;
    // Start is called before the first frame update
    void Start()
    {
        passed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "sittagged"){
            canvascont.sitdown = false;
            passed = true;
        }
    }
}
