using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pan : MonoBehaviour
{
    Vector3 touchStart;
    public Camera cam;
    
    public static bool pann = true;
    
    public float MinX , MinY , MaxX , MaxY;
   
    public static string WhichState;
    public string thisState;
    // Start is called before the first frame update
    void Awake(){
        WhichState = "Main";
    }
    void Start()
    {
        

        
        
    }

    // Update is called once per frame
    void Update()
    {
       if(WhichState == thisState){
        if(pann == true){
            if(Input.GetMouseButtonDown(0)){
            touchStart = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.GetMouseButton(0)){
            Vector3 direction = touchStart - cam.ScreenToWorldPoint(Input.mousePosition);
               // cam.transform.position += direction;
                this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x + direction.x , MinX , MaxX ), Mathf.Clamp(this.transform.position.y + direction.y, MinY , MaxY ) , this.transform.position.z);
            }
        }
       }
       else{
           this.transform.position = new Vector3(MinX , MinY , this.transform.position.z);
       }
    }
}
