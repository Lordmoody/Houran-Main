﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class HorizontalPanel : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public ControlGuide controlGuide;
   #region FIELDS
    private Grid grid;

    public Image Panel;
    private enum DraggedDirection
    {
       
        Right,
        Left,
        Stand
    }
    #endregion

    #region  IDragHandler - IEndDragHandler
    public void OnEndDrag(PointerEventData eventData)
    {
      //  Debug.Log("Press position + " + eventData.pressPosition);
      //  Debug.Log("End position + " + eventData.position);
       // Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition).normalized;
      //  Debug.Log("norm + " + dragVectorDirection);
       // GetDragDirection(dragVectorDirection);
       NewPlayerMovementP.HorizValue = 0;
       CombatScript.FingerMoved = true;
       Panel.color = new Color(Panel.color.r , Panel.color.g , Panel.color.b , 0);
    }

    //It must be implemented otherwise IEndDragHandler won't work 
    public void OnDrag(PointerEventData eventData)
    {

        if(ControlGuide.CurrentGuide == "Moveguide"){
            ControlGuide.CurrentGuide = "None";
            controlGuide.ForCancel();
        }
        Debug.Log("Press position + " + eventData.pressPosition);
        Debug.Log("End position + " + eventData.position);
        Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition).normalized;
        Debug.Log("norm + " + dragVectorDirection);
        GetDragDirection(dragVectorDirection);
        Panel.color = new Color(Panel.color.r , Panel.color.g , Panel.color.b , 0.3f);
        
    }

    private DraggedDirection GetDragDirection(Vector3 dragVector)
    {
        float positiveX = Mathf.Abs(dragVector.x);
        float positiveY = Mathf.Abs(dragVector.y);
        DraggedDirection draggedDir;
        if (positiveX > positiveY)
        {
            draggedDir = (dragVector.x > 0) ? DraggedDirection.Right : DraggedDirection.Left;
            if(draggedDir == DraggedDirection.Right){
                NewPlayerMovementP.HorizValue = 1;
            }
            else if(draggedDir == DraggedDirection.Left){
                NewPlayerMovementP.HorizValue = -1;
            }
        }
        else{
            draggedDir = DraggedDirection.Stand;
            NewPlayerMovementP.HorizValue = 0;
        }
        
        Debug.Log(draggedDir);
        return draggedDir;
    }
    #endregion
}
