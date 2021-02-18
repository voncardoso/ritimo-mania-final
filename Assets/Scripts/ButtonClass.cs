using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClass : MonoBehaviour
{

    public GameController gameController;
    public int idBotao;

    private void OnMouseDown()
    {

        if (gameController.gameState == GameState.RESPONDER)
        {
            gameController.StartCoroutine("Responder", idBotao);
        }
    }

    public void TesteDeHeranca()
    {
        Debug.Log("Herança obtida");
    } 
    
}
