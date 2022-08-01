using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform TargetPosition;
    [SerializeField] private Camera UiCamera;
   // [SerializeField] private Sprite arrowSprite , CrossSprite;
    [SerializeField]private RectTransform pointerRectTransform;
    public Transform[] Targets; 
    public GameObject Pointerr;
    
    private void Awake(){
      //  pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
    }

    // Update is called once per frame
     void Update()
    {
       /* if(TaskUIManager.GuideToThis != null){
            TargetPosition.position = TaskUIManager.GuideToThis.transform.position;
        }*/
        if(Pointerr.activeSelf == true){
        TargetPosition = Targets[CoinManager.CurrentLevel];
        Vector3 toPosition = TargetPosition.position;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition-fromPosition).normalized;
        float angle = UtilsClass.GetAngleFromVectorFloat(dir);
        pointerRectTransform.localEulerAngles = new Vector3(0 ,0 , angle);

        float borderSize = 100f;    
        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(TargetPosition.position);
        bool isOffScreen = targetPositionScreenPoint.x <= borderSize || targetPositionScreenPoint.x >= Screen.width - borderSize || targetPositionScreenPoint.y <= borderSize || targetPositionScreenPoint.y >= Screen.height - borderSize;

        if(isOffScreen){
            Vector3 CappedTargetScreenPosition = targetPositionScreenPoint;
            if(CappedTargetScreenPosition.x <= borderSize) CappedTargetScreenPosition.x = borderSize;
            if(CappedTargetScreenPosition.x >= Screen.width - borderSize) CappedTargetScreenPosition.x = Screen.width - borderSize;
            if(CappedTargetScreenPosition.y <= borderSize) CappedTargetScreenPosition.y = borderSize;
            if(CappedTargetScreenPosition.y >= Screen.height - borderSize) CappedTargetScreenPosition.y = Screen.height - borderSize;

            Vector3 PointerWorldPosition = UiCamera.ScreenToWorldPoint(CappedTargetScreenPosition);
            pointerRectTransform.position = PointerWorldPosition;
            pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x , pointerRectTransform.localPosition.y , 0f);
        }else{
            Vector3 PointerWorldPosition = UiCamera.ScreenToWorldPoint(targetPositionScreenPoint);
            pointerRectTransform.position = PointerWorldPosition;
            pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x , pointerRectTransform.localPosition.y , 0f);
        }
    }
    }
}
