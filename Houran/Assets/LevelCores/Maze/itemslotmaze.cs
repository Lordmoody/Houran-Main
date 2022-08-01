using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Pathfinding;
public class itemslotmaze : MonoBehaviour, IDropHandler
{
    public Animator door;
    public GameObject dooor;
    public GameObject text;
    public GameObject lockk;
    public GameObject key;
    public AstarPath astarPath;
    public void OnDrop(PointerEventData eventData){
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        door.SetBool("open" , true);
        text.SetActive(false);
        lockk.SetActive(false);
        key.SetActive(false);
        dooor.layer = default;
        astarPath.Scan();
//        AstarPath.OnGraphsUpdated(astarPath);
    }
}
