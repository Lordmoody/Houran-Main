using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyFieldOfView : MonoBehaviour
{
    public float radius = 5f;
    [Range(1 , 360)]public float angle = 45f;
    public LayerMask targetLayer;
    public LayerMask obstructionLayer;
    public GameObject playerRef;
    public bool PLayerDetected = false;

    public bool CanSeePlayer {get ; private set ;}
    public UnityEvent OnDetection , OnExit;

    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("PlayerCore");
        StartCoroutine(FOVCheck());
    }

    private IEnumerator FOVCheck(){
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while(true){
            yield return wait;
            FOV();
        }
    }
    
    private void FOV(){
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position , radius, targetLayer);
        if(rangeCheck.Length > 0){
            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;
            if(Vector2.Angle(transform.up , directionToTarget) < angle / 2){
                float distanceToTarget = Vector2.Distance(transform.position , target.position);
                if(!Physics2D.Raycast(transform.position , directionToTarget , distanceToTarget , obstructionLayer) && CanSeePlayer == false){
                    CanSeePlayer = true;
                    OnDetection.Invoke();
                }
                else if(Physics2D.Raycast(transform.position , directionToTarget , distanceToTarget , obstructionLayer) && CanSeePlayer == true){
                    CanSeePlayer = false;
                    OnExit.Invoke();
                }
            }
            else{
                CanSeePlayer = false;
                OnExit.Invoke();
            }
        }
        else if(CanSeePlayer){
            CanSeePlayer = false;
            OnExit.Invoke();
        }
    }
#if UNITY_EDITOR_WIN
    private void OnDrawGizmos(){
        Gizmos.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(transform.position , Vector3.forward , radius);

        Vector3 angle01 = DirectionFromAngle(-transform.eulerAngles.z, -angle / 2);
        Vector3 angle02 = DirectionFromAngle(-transform.eulerAngles.z, angle / 2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position , transform.position + angle01 * radius);
        Gizmos.DrawLine(transform.position , transform.position + angle02 * radius);

        if(CanSeePlayer){
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position , playerRef.transform.position);
        }
    }
    #endif

    private Vector2 DirectionFromAngle(float eulerY , float angleInDegrees){
        angleInDegrees += eulerY;
        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad) , Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
