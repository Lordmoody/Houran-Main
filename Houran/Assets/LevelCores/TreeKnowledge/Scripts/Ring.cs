using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ring : MonoBehaviour
{
    [HideInInspector]public bool ThisBought = false;
    public GameObject[] circles;
    public SpriteRenderer icon;
    public SpriteRenderer web;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if(ThisBought == true){
            for(int i = 0; i < 3 ; i++){
                circles[i].SetActive(true);
            }
            icon.color = Color.white;
            web.color = Color.white;
            ThisBought = false;
        }*/
    }
}
