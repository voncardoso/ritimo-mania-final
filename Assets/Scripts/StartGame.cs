using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameController gameController;

   public void OnMouseDown()
    {
        gameController.StartGame();
    }
}
