using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramGuide : MonoBehaviour
{
    public Animator GuideAnim;

    public void ShowGuide(float flip , string animName , float destTime){
        this.transform.localScale = new Vector3(flip , this.transform.localScale.y , this.transform.localScale.z);
        GuideAnim.SetTrigger(animName);
        Destroy(this.gameObject , destTime);
    }
}
