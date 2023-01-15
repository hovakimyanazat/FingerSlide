using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addScore : MonoBehaviour
{

    private float speed = 20;
    
    public static float updaterScore;
    private int actualScore;

    public static int best = 0;

    private Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        score.text = "Score  "+ actualScore +"\n<color=black>Best "+ PlayerPrefs.GetInt("bestScore")  + "</color>";
    }

    // Update is called once per frame
    void Update()
    {
        if(Spike.youLost == false && moveOfEnemy.gameOver == false){
        updaterScore += speed * Time.deltaTime; 
        actualScore = (int) updaterScore;
        if(PlayerPrefs.GetInt("bestScore") < actualScore){
            PlayerPrefs.SetInt("bestScore" , actualScore);
        }
        score.text = "Score  "+ actualScore +"\n<color=black>Best "+ PlayerPrefs.GetInt("bestScore")  + "</color>";
        }
        

        
    }
}
