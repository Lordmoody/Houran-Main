using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkdoor : MonoBehaviour
{
    public GameObject text;
    public GameObject lockk;
    public Text textmaze;
    [System.Serializable]
    public class Player{
        public string name;
        public string sent;
    }

    [System.Serializable]
    public class PlayerList{
        public Player[] player;
    }
    
    public PlayerList myPlayerList = new PlayerList();
    public string gamePath;
    public TextAsset textJasoneng;
    public int textnum;
    // Start is called before the first frame update
    void Start()
    {
        gamePath = Application.dataPath + "/Resources";
        textJasoneng = Resources.Load<TextAsset>("JsonMaze");
        myPlayerList = JsonUtility.FromJson<PlayerList>(textJasoneng.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "lioncore"){
            text.SetActive(true);
            lockk.SetActive(true);
            if(managertree.BaseLang == "Persian"){
                textmaze.text = myPlayerList.player[textnum].name;
            }
            else if(managertree.BaseLang == "English"){
                textmaze.text = myPlayerList.player[textnum].sent;
            }
        }
    }
}
