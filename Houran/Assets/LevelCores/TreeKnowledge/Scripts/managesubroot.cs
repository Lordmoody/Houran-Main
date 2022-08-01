using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managesubroot : MonoBehaviour
{
    

    public GameObject[] SubWords;
    public int ThisRoot;
    int tillNow;
    public LevelAndKnowledgeManager levelAndKnowledgeManager;
    // Start is called before the first frame update
    void OnEnable(){
        tillNow = 0;
        foreach(GameObject word in SubWords){
            if(word.GetComponent<IconClicked>().RequiredLevel <= CoinManager.CurrentLevel){
                for(int i = 0; i < 3 ; i++){
                    word.GetComponent<Ring>().circles[i].SetActive(true);
                }
                word.GetComponent<Ring>().icon.color = Color.white;
                word.GetComponent<Ring>().web.color = Color.white;
                word.GetComponent<Ring>().ThisBought = false;
                tillNow += 1;
            }
        }
        levelAndKnowledgeManager.myProgressList.prog[ThisRoot].progress = tillNow;
    }
}
