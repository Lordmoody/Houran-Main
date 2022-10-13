using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    
     Vector3 SideMove;
    public float speed;
    public float DestTime;
   [HideInInspector] public Transform PlayerPos;
    public Rigidbody2D rb;

    void Start(){
       /* if(SnakeEyeController.SideOfShot == "Left"){
            SideMove = Vector3.left;
        }
        else if(SnakeEyeController.SideOfShot == "Right"){
            SideMove = Vector3.right;
        }*/
        Vector3 direction = PlayerPos.position - this.gameObject.transform.position;
        Vector3 rotation = this.gameObject.transform.position - PlayerPos.position;
        rb.velocity = new Vector2(direction.x , direction.y);
        float rot = Mathf.Atan2(rotation.y , rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0 , 0 , rot * 90);
        Destroy(this.gameObject , DestTime);
    }
    void Update(){
        
          //  this.gameObject.transform.position += SideMove * Time.deltaTime * speed; 
        
    }
    
    
}
