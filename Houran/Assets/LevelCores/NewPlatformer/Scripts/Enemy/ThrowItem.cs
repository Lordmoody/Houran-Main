using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItem : MonoBehaviour
{
    public SpriteRenderer Sprite;
    public BoxCollider2D collider2d;
    public float thrust;
    [HideInInspector]public Transform EnemyTransform;
    [HideInInspector]public Transform EnemyScale;
    public LayerMask Ground;
    public float radius;
    bool Thrown = false;

    void Update(){
        if(Thrown == true){
        Collider2D[] groundTouch = Physics2D.OverlapCircleAll(this.gameObject.transform.position , radius , Ground);
        foreach(Collider2D ground in groundTouch){
            Destroy(this.gameObject.GetComponent<Rigidbody2D>());
            Thrown = false;
        }
        }
    }

    public void Throw(){
        Sprite.enabled = true;
        this.gameObject.transform.position = EnemyTransform.position;
        collider2d.enabled = true;
        this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; 
        if(EnemyScale.localScale.x > 0){
            this.gameObject.GetComponent<Rigidbody2D>().velocity =  new Vector2(-1 , 1) * thrust;
        }
        else if(EnemyScale.localScale.x < 0){
            this.gameObject.GetComponent<Rigidbody2D>().velocity =  new Vector2(1 , 1) * thrust;
        }
        Thrown = true;
    }


    #if UNITY_EDITOR
        void OnDrawGizmosSelected(){
        

        Gizmos.DrawWireSphere(this.gameObject.transform.position , radius);
    }
    #endif
}
