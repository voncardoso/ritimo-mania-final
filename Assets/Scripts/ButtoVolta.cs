using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtoVolta : MonoBehaviour
{
    // Start is called before the first frame update
 public void OnMouseDown()
    {
        StartCoroutine(Jogar2());
    }

    IEnumerator Jogar2(){
		SceneManager.LoadScene("Config");
    	yield return 0;
	 }
}
