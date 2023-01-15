using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundsforEnemy : MonoBehaviour
{   
//Bounds of Position of an Enemy
private float Min_X=-2.07f , Max_X=2.07f , Min_Y=-4.98f , Max_Y =4.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkBounds();
    }


// Making Bounds for Enemy
    void checkBounds()
    {
        Vector3 temp = transform.position;
        if(temp.x < Min_X){
            temp.x = Min_X;
        }
        if(temp.x > Max_X){
            temp.x = Max_X;
        }
        if(temp.y < Min_Y){
            temp.y= Min_Y;
        }
        if(temp.y > Max_Y){
            temp.y = Max_Y;
        }

        transform.position = temp;

    }
}
