using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawning_spikes : MonoBehaviour 
{
    [SerializeField]
    private GameObject spikePrefab; // The prefab of spikes spawning
    public GameObject spikeSpawner; // Spikespawner
    public GameObject enemy; // Enemy
    public GameObject restartButton; // Restart Button
    public GameObject homeButton; // home Button
    public Text score; // Actual score
    public Text endScore; // Score in the end of game
    public static float platform_spawn_timer = 1f; // Spike spawning speed
    private float current_platform_spawn_timer; 
    private float min_X = -2f , max_X = 2f; // Bounces of spawned spikes
    
    
    // Start is called before the first frame update
    void Start()
    {
        current_platform_spawn_timer = platform_spawn_timer;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnSpikes();
        Losing();
    }

    // Spawning spikes
    void SpawnSpikes()
    {
        current_platform_spawn_timer += Time.deltaTime;
        if(current_platform_spawn_timer >= platform_spawn_timer){
                Vector3 temp = transform.position;
                temp.x = Random.Range(min_X,max_X);
                GameObject newSpike = null;
                
                newSpike = Instantiate(spikePrefab,temp,Quaternion.identity); 
                current_platform_spawn_timer = 0; 
                newSpike.transform.parent = transform;
                platform_spawn_timer -= 4 * Time.deltaTime;
                if(platform_spawn_timer <= .5f){
                    platform_spawn_timer = .5f;
                }             
        }
        
    }
    
    //When lose
    void Losing(){
        if(Spike.youLost == true ){
            gameObject.SetActive(false);
            enemy.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(true);
            homeButton.gameObject.SetActive(true);
            score.gameObject.SetActive(false);
            endScore.gameObject.SetActive(true);
            foreach(Transform child in spikeSpawner.transform){
                Destroy(child.gameObject);
            }
            Spike.youLost = false;
            endScore.text = score.text;
            
        }

    }
}
