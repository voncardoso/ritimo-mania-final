using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float timeLevel;
    public static bool stopTime = false;
    //public Text timeLevel_txt;


    public void Update(){
        if(stopTime == false){
            timeLevel = timeLevel + Time.deltaTime;
           // timeLevel_txt.text = timeLevel.ToString("F0");
            print("time" + timeLevel);
        }
    }
}
