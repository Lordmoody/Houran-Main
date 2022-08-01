using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEndOfFOV : MonoBehaviour
{
    public GameObject AreaEnemy;
   // public GameObject FOV;
    public EnemyFieldOfView enemyFOV;
    public Vector3 EndPointleft , EndPointRight;
    public float IdealDistance;
    public float Radius = 8;
    bool Onleft = false , Onright = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // foreach(Transform enemy in AreaEnemy){
            if(Mathf.Abs(AreaEnemy.transform.position.x) - Mathf.Abs(EndPointleft.x) < IdealDistance && Onright == false){
                
             //  FOV = AreaEnemy.GetChild(2).gameObject;
               Onleft = true;
               enemyFOV.radius = 0;
            }
            else if(Mathf.Abs(AreaEnemy.transform.position.x) - Mathf.Abs(EndPointleft.x) >= IdealDistance && Onright == false){
               // FOV = AreaEnemy.GetChild(2).gameObject;
              enemyFOV.radius = Radius;
              Onleft = false;
            }

            if(   Mathf.Abs(EndPointRight.x) - Mathf.Abs(AreaEnemy.transform.position.x) <IdealDistance && Onleft == false){
                
             //  FOV = AreaEnemy.GetChild(2).gameObject;
               Onright = true;
               enemyFOV.radius = 0;
            }
            else if(  Mathf.Abs(EndPointRight.x) - Mathf.Abs(AreaEnemy.transform.position.x) >= IdealDistance && Onleft == false){
               // FOV = AreaEnemy.GetChild(2).gameObject;
              enemyFOV.radius = Radius;
              Onright = false;
            }
       // }
    }
}
