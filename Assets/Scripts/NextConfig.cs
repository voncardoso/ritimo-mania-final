using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class NextConfig : MonoBehaviour
{
    // Start is called before the first frame update
     public void start()
    {
        StartCoroutine(Play());
    }
    IEnumerator Play(){
		SceneManager.LoadScene("Config");
    	yield return 0;
	 }
    // Update is called once per frame
    void Update()
    {
        
    }
}
