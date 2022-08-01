using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropRunner : MonoBehaviour , IPointerDownHandler , IBeginDragHandler , IEndDragHandler , IDragHandler , IDropHandler
{
    private RectTransform rectTransform;
    public RectTransform hometransform;
    private CanvasGroup canvasGroup;
    [SerializeField] private Canvas canvas;
    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData){
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData){
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData){
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = hometransform.anchoredPosition;
        
    }
    public void OnPointerDown(PointerEventData eventData){
       
    }
    
    public void OnDrop(PointerEventData eventData){

    }
    
}
