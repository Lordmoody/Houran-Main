using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class VericalPanel : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public ControlGuide controlGuide;
    public GameObject CheckJump , CheckSit;
   #region FIELDS
    private Grid grid;
    public Image Panel;

    private enum DraggedDirection
    {
       
        Up,
        Down,
        Stand
    }
    #endregion

    #region  IDragHandler - IEndDragHandler 
    public void OnEndDrag(PointerEventData eventData)
    {
        CombatScript.FingerMoved = true;
        Debug.Log("Press position + " + eventData.pressPosition);
        Debug.Log("End position + " + eventData.position);
        Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition).normalized;
        Debug.Log("norm + " + dragVectorDirection);
        GetDragDirection(dragVectorDirection);
        NewPlayerMovementP.CrouchValue = false;
        Panel.color = new Color(Panel.color.r , Panel.color.g , Panel.color.b , 0);
    }

    

    //It must be implemented otherwise IEndDragHandler won't work 
    public void OnDrag(PointerEventData eventData)
    {
        if(ControlGuide.CurrentGuide == "JumpGuide"){
            ControlGuide.CurrentGuide = "None";
            controlGuide.ForCancel();
            Destroy(CheckJump);
        }
        if(ControlGuide.CurrentGuide == "SitGuide"){
            ControlGuide.CurrentGuide = "None";
            controlGuide.ForCancel();
            Destroy(CheckSit);
        }
        Debug.Log("Press position + " + eventData.pressPosition);
        Debug.Log("End position + " + eventData.position);
        Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition).normalized;
        Debug.Log("norm + " + dragVectorDirection);
        GetDragDirection(dragVectorDirection);
        if(GetDragDirection(dragVectorDirection) == DraggedDirection.Up){
            return;
        }
        
        Panel.color = new Color(Panel.color.r , Panel.color.g , Panel.color.b , 0.3f);
    }

    private DraggedDirection GetDragDirection(Vector3 dragVector)
    {
        float positiveX = Mathf.Abs(dragVector.x);
        float positiveY = Mathf.Abs(dragVector.y);
        DraggedDirection draggedDir;
        if (positiveX < positiveY)
        {
            draggedDir = (dragVector.y > 0) ? DraggedDirection.Up : DraggedDirection.Down;
            if(draggedDir == DraggedDirection.Up){
                NewPlayerMovementP.JumpValue = true;
            }
            else if(draggedDir == DraggedDirection.Down){
                NewPlayerMovementP.CrouchValue = true;
            }
        }
        else{
            draggedDir = DraggedDirection.Stand;
            
        }
        
        Debug.Log(draggedDir);
        return draggedDir;
    }
    #endregion
}
