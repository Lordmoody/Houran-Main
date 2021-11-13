using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramover : MonoBehaviour
{
    public float speed;
    public static float speed2 = 8f;
    // Start is called before the first frame update
    void Start()
    {
        speed2 = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        speed = speed2;
        if(karencont.stopEve == false){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        
    }
}
