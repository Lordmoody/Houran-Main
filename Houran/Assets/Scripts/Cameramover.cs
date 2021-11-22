using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramover : MonoBehaviour
{
    public float speed;
    public static float speed2 = 8f;
    public static bool camstop = false;
    public static float globalblurrate;
    // Start is called before the first frame update
    void Awake(){
        globalblurrate = 0f;
        camstop = false;
    }
    void Start()
    {
        speed2 = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        speed = speed2;
        if(camstop == true){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        
    }
}
