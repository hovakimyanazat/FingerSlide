using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveOfEnemy : MonoBehaviour
{   
    
     private float speed = 3f; //Speed of Enemy
     public GameObject restartButton; // Restart Button
     public GameObject homeButton; // Home Button
     public GameObject spikes; // Spike Spawner
     public Text score; // The Actual Score during the game
     public Text endScore; // The score in the end of the game
     private Transform target; // The Player's Transform
     public static bool gameOver; // IS the game over or not
     private float timeToIncrease = 10f; //this is the time between "speedups"
     private float currentTime;  //to keep track
     private float speedIncrement = 0.05f; //how much to increase the speed by
    
    
    // Start is called before the first frame update
    void Start(){
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // Getting Player's position
    }

    void Update(){
        //Moving Enemy
        transform.position = Vector2.MoveTowards(transform.position,target.position,speed * Time.deltaTime);
        
        //Increasing Speed of Enemy by time
        if (Time.time >= currentTime)
        {
            speed += speedIncrement;
            if(speed > 7)
            {
                speed = 7;
            }
            currentTime = Time.time + timeToIncrease;
        }
    }

    // When Enemy hit the Player
    void OnCollisionEnter2D(Collision2D target){
        if(target.gameObject.tag == "Player"){
            target.gameObject.SetActive(false); // Off Player
            gameObject.SetActive(false); // Off Enemy
            spikes.gameObject.SetActive(false); // Off spikeSpawner
            // Destroying all spikes 
            foreach (Transform child in spikes.transform)
            {
                Destroy(child.gameObject);
            }
            restartButton.gameObject.SetActive(true); // On RestartButton
            homeButton.gameObject.SetActive(true); //On homeButton
            gameOver = true; // Set GameOverTrue
            score.gameObject.SetActive(false); // Off actualScore
            endScore.gameObject.SetActive(true); // On The score in the end of the game
            endScore.text = score.text; 
        
        }
    }
}



