using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTskItem : MonoBehaviour
{
    public string ItemName;
    public Transform forItem;
    GameObject target;

    public void FindProperItem(){
        if(GameObject.Find(ItemName) != null){
            target = GameObject.Find(ItemName);
            target.GetComponent<ThrowItem>().EnemyTransform = forItem;
            target.GetComponent<ThrowItem>().EnemyScale = this.gameObject.transform;
            target.GetComponent<ThrowItem>().Throw();
        }
        
    }
}
