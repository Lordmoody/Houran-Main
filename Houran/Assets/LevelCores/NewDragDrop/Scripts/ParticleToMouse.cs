using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleToMouse : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     private void Update()
    {
        
        //For 2D Games Only set gameobject position to mouse position
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        this.transform.position = mouseWorldPosition;
        
        //
        
    }
}
