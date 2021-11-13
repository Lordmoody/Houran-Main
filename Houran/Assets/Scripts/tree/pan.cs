using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pan : MonoBehaviour
{
    Vector3 touchStart;
    public Camera cam;
    public static bool pann = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pann == true){
            if(Input.GetMouseButtonDown(0)){
            touchStart = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.GetMouseButton(0)){
            Vector3 direction = touchStart - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position += direction;
        }
        }
        
    }
}
