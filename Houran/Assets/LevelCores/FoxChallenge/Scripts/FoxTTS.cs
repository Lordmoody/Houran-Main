using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class FoxTTS : MonoBehaviour
{
    public static string LANG_CODE = "en_US";
    [SerializeField]
   // Text uiText;
    void Start(){
        Setup(LANG_CODE);
    #if UNITY_ANDROID
        TextSpeech.SpeechToText.instance.onPartialResultsCallback = OnPartialSpeechResult;
    #endif
        TextSpeech.SpeechToText.instance.onResultCallback = OnFinalSpeechResult;

        TextSpeech.TextToSpeech.instance.onStartCallBack = OnSpeakStart;
        TextSpeech.TextToSpeech.instance.onDoneCallback = OnSpeakStop;

        CheckPermission();
    }

    void CheckPermission(){
        #if UNITY_ANDROID
            if(!Permission.HasUserAuthorizedPermission(Permission.Microphone)){
                Permission.RequestUserPermission(Permission.Microphone);
            }
        #endif
    }

    #region Text To Speech
    public void StartSpeaking(string message){
      //  message = managertree.readThis;
        TextSpeech.TextToSpeech.instance.StartSpeak(message);
    }
    public void StopSpeaking(){
        TextSpeech.TextToSpeech.instance.StopSpeak();
    }
    void OnSpeakStart(){
        Debug.Log("Talking started...");
    }

        void OnSpeakStop(){
        Debug.Log("Talking stopped...");
    }
    #endregion

    #region Speech To Text
    public void StartListening(){
        TextSpeech.SpeechToText.instance.StartRecording();
    }
    public void StopListening(){
        TextSpeech.SpeechToText.instance.StopRecording();
    }
    void OnFinalSpeechResult(string result){
      //  uiText.text = result;
    }
    void OnPartialSpeechResult(string result){
      //  uiText.text = result;
    }
    #endregion
    public void Setup(string code){
        TextSpeech.TextToSpeech.instance.Setting(code , 1 , 1);
        TextSpeech.SpeechToText.instance.Setting(code);
    }
}
