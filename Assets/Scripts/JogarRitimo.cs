using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class JogarRitimo : MonoBehaviour
{
       
    // Start is called before the first frame update
    public void start1()
    {
        if(SetConfig._text == 0){
            StartCoroutine(JogarNotas());
        }else{
            StartCoroutine(Jogar());
        }
        
    }
    IEnumerator Jogar(){
		SceneManager.LoadScene("Play");
    	yield return 0;
	 }

         IEnumerator JogarNotas(){
		SceneManager.LoadScene("Play-1");
    	yield return 0;
	 }
    // Update is called once per frame
    void Update()
    {
        
    }
}
