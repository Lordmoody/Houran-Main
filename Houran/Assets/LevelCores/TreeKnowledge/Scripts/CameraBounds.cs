using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
 private float rightBound;
 private float leftBound;
 private float topBound;
 private float bottomBound;
 private Vector3 pos;
 public Transform target;
 public SpriteRenderer spriteBounds;
 public Camera maincam;
 
 // Use this for initialization
 void Start () 
 {
     float vertExtent = maincam.orthographicSize;  
     float horzExtent = vertExtent * Screen.width / Screen.height;
    
     leftBound = (float)(horzExtent - spriteBounds.sprite.bounds.size.x / 2.0f);
     rightBound = (float)(spriteBounds.sprite.bounds.size.x / 2.0f - horzExtent);
     bottomBound = (float)(vertExtent - spriteBounds.sprite.bounds.size.y / 2.0f);
     topBound = (float)(spriteBounds.sprite.bounds.size.y  / 2.0f - vertExtent);
 }
 
 // Update is called once per frame
 void Update () 
 {
     //Debug.Log();
     var pos = new Vector3(target.position.x, target.position.y, transform.position.z);
     pos.x = Mathf.Clamp(pos.x, leftBound, rightBound);
     pos.y = Mathf.Clamp(pos.y, bottomBound, topBound);
   //  transform.position = pos;
 }
}
