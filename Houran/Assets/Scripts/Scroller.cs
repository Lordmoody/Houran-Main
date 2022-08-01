using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scroller : MonoBehaviour
{
    private float length , startpos;
    public GameObject cam;
    public float parallexeffect;
    public float add = 0f;
   
    // Start is called before the first frame update
    void Start()
    {
       startpos = transform.position.x;
       length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      //  if(karencont.stopEve == false){
        float temp = (cam.transform.position.x * (1 - parallexeffect));
        float dist = (cam.transform.position.x * parallexeffect);

        transform.position = new Vector3(startpos + dist + add , transform.position.y , transform.position.z);
        if(temp > startpos + length){
            startpos += length;
        }
        else if(temp < startpos - length){
            startpos -= length;
        }
       // }
        
    }
}
