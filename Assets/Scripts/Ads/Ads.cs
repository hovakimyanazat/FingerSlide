using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class Ads : MonoBehaviour
{
    private Coroutine showAd;
    private string gameId = "4505720" , type = "video";
    private bool testMode = true;
    private bool needToStop;
    private static int countLoses;

    private void Start(){
        countLoses++;
        Advertisement.Initialize(gameId , testMode);
        if(PlayerPrefs.GetString("music") == "No"){
            GetComponent<AudioSource>().mute = true;
        }
        
    }

    void Update(){
        if(needToStop == true){
            needToStop = false;
            StopCoroutine(showAd);
        }
        if(countLoses % 2 == 0 || Buttons.clickOnRestart % 2 == 0){
        showAd = StartCoroutine(ShowAd());
        needToStop = true;
        }
        if(PlayerPrefs.GetString("music") == "No"){
            GetComponent<AudioSource>().mute = true;
        }else if(PlayerPrefs.GetString("music") == "Yes"){
            GetComponent<AudioSource>().mute = false;
        }
    }

    IEnumerator ShowAd(){
        while (true)
        {
             if(Advertisement.IsReady(type)){
                 Advertisement.Show(type);
                 needToStop = true;
             }
             yield return new WaitForSeconds(1f);
        }
    }
}
