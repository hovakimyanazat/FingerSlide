using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    private float spike_speed = 3f;
    private float bound_y = -6.5f;
    
    public static bool youLost;
    
    
    



   // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void Move()
    {
        Vector2 temp = transform.position;
        temp.y -= spike_speed * Time.deltaTime;
        transform.position = temp;

        if(temp.y <= bound_y){
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "Player"){
            target.gameObject.SetActive(false);
            gameObject.SetActive(false);
            youLost = true;

        }
    }
    
}
