using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Menuconfig1 : MonoBehaviour
{
    public GameObject configPanelTeste1;
    public GameObject configPanelTeste2;
    public GameObject netxConfig;
    public GameObject backConfig;
    public GameObject backInicial;
    public GameObject buttonPlay;
    
    
    public void start()
    {
        StartCoroutine(inicial());
    }

    public void CarregarConfig1() {
        configPanelTeste1.SetActive(true);
        configPanelTeste2.SetActive(false);
        netxConfig.SetActive(true);
        backConfig.SetActive(false);
        backInicial.SetActive(true);
        buttonPlay.SetActive(false);
    }

    public void CarregarConfig2() {
        configPanelTeste1.SetActive(false);
        configPanelTeste2.SetActive(true);
        netxConfig.SetActive(false);
        backConfig.SetActive(true);
        backInicial.SetActive(false);
        buttonPlay.SetActive(true);
    }

    IEnumerator inicial(){
		SceneManager.LoadScene("Inicial");
    	yield return 0;
	 }


    // Update is called once per frame
    void Update()
    {
        
    }
}
