using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTypeMode : MonoBehaviour
{
    public float Delay = 0.1f;
    public string FullText;
    private string CurrentText = "";
    public GameObject AcceptBtn , DeclineBtn;
    public TaskUIManager taskUIManager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());
    }

    public IEnumerator ShowText(){
        for(int i= 0; i <= FullText.Length ; i++){
            if(i == FullText.Length -1){
                AcceptBtn.SetActive(true);
                DeclineBtn.SetActive(true);
                if(taskUIManager.CharANim != null){
                    taskUIManager.CharANim.SetBool("Talk" , false);
                }
                
            }
            CurrentText = FullText.Substring(0 , i);
            this.GetComponent<Text>().text = CurrentText;
            yield return new WaitForSeconds(Delay);
        }
    }
}
