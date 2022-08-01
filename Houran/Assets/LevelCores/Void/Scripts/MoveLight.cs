using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLight : MonoBehaviour
{
    public bool go = false;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(go == true){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
