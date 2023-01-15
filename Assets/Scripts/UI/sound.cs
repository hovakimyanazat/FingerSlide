using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sound : MonoBehaviour
{
    private void Start(){
    if(PlayerPrefs.GetString("music") == "No"){
        GetComponent<Image>().sprite = soundOff; 
    }
}

    public Sprite soundOn , soundOff;
    

    
    public void musicOnorOff(){
        if(PlayerPrefs.GetString("music") == "No"){
            PlayerPrefs.SetString("music" , "Yes");
            GetComponent<Image>().sprite = soundOn;
             
        }else{
            PlayerPrefs.SetString("music","No");
            GetComponent<Image>().sprite = soundOff;
            
        }
    }
}
