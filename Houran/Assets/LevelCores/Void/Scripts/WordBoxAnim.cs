using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordBoxAnim : MonoBehaviour
{
    public bool nowAnim = false;
    public Animator wordbox;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(nowAnim == true){
               wordbox.SetTrigger("show");
               nowAnim = false;
        }
    }
}
