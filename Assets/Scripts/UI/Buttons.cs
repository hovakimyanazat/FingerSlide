using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Buttons : MonoBehaviour
{
    public GameObject logo;
    public GameObject player;
    public GameObject enemy;
    public GameObject spikes;
    public GameObject insta;
    public GameObject twitter;
    public GameObject youtube;
    public GameObject facebook;
    public GameObject shop;
    public Text score;
    public Text endScore;
    public Text bestScore;
    private Coroutine showAd;
    private string gameId = "4505720" , type = "video";
    private bool testMode = true;

    public GameObject playButton;
    
    

    public GameObject home;

    public static int clickOnRestart;

    private GameObject[] childOfSpike;
    
    private void Start(){
        
        Advertisement.Initialize(gameId , testMode);
        
    }

    void Update(){
        
    }

    public void RestartGame(){
        
        gameObject.SetActive(false);
        home.gameObject.SetActive(false);
        player.gameObject.transform.SetPositionAndRotation(new Vector3(0,0,0),Quaternion.identity);
        enemy.gameObject.transform.SetPositionAndRotation(new Vector3(0,3,0),Quaternion.identity);
        player.gameObject.SetActive(true);
        enemy.gameObject.SetActive(true);
        spikes.gameObject.SetActive(true);
        score.gameObject.SetActive(true);
        Spike.youLost = false;
        addScore.updaterScore = 0;
        moveOfEnemy.gameOver = false;
        endScore.gameObject.SetActive(false);
        clickOnRestart++;
        spawning_spikes.platform_spawn_timer = 1;


    }

    

    public void openInstagram(){
        
        Application.OpenURL("https://www.instagram.com/hovakimyan888_/");
    }

    public void openTwitter(){
        
        Application.OpenURL("https://twitter.com/hovakimyan_azat");
    }


    public void startGame(){
        
        
        
        gameObject.SetActive(false);
        logo.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
        enemy.gameObject.SetActive(true);
        spikes.gameObject.SetActive(true);
        insta.gameObject.SetActive(false);
        twitter.gameObject.SetActive(false);
        youtube.gameObject.SetActive(false);
        facebook.gameObject.SetActive(false);
        shop.gameObject.SetActive(false);
        score.gameObject.SetActive(true);
        addScore.updaterScore = 0;
        Spike.youLost = false;
        moveOfEnemy.gameOver = false;
        

    }


    public void homeButton(){
        
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
    }

    IEnumerator ShowAd(){
        while (true)
        {
             if(Advertisement.IsReady(type)){
                 Advertisement.Show(type);
                 StopCoroutine(showAd);
             }
             yield return new WaitForSeconds(1f);
        }
    }


    
}
