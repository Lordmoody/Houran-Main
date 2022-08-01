using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaytimeController : MonoBehaviour
{
    [Range(0 , 1)]public float Daytime;
    public LightColorController lightColorController;
    // Start is called before the first frame update
    void Start()
    {
       lightColorController.time = Daytime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
