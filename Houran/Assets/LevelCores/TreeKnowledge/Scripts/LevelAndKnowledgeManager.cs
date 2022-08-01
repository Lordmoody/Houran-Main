using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelAndKnowledgeManager : MonoBehaviour
{
    [System.Serializable]
    public class ProgressClass{
        public string name;
        public int progress;

    }
    [System.Serializable]
    public class progressList{
        public ProgressClass[] prog;
    }
    public progressList myProgressList = new progressList();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
