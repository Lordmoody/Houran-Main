using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;



public class destroy : MonoBehaviour
{
        public  GameObject des;
        [SerializeField]
        private CinemachineVirtualCamera vcam1;
  
    public  void dest()
    {
        des.SetActive(false);
        vcam1.Priority = 15;
        Invoke("cameraSwitch" , 5);
    }

    public void cameraSwitch(){
        vcam1.Priority = 8;

    }
}
