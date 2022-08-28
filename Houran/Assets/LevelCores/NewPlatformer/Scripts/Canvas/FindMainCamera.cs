using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindMainCamera : MonoBehaviour
{
    public Canvas thisCanvas;
    // Start is called before the first frame update
    void Start()
    {
        thisCanvas.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

   
}
