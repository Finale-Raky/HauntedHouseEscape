using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private int actived;
    
    void Start()
    {
        //PlayerPrefs.SetInt("act",0);
        Debug.Log(PlayerPrefs.GetInt("act"));
        actived = PlayerPrefs.GetInt("act");
        if(actived == 0){
            PlayerPrefs.SetInt("dif",0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
