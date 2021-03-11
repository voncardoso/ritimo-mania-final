using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameController gameController;
    public Timer  timer;

   public void OnMouseDown()
    {
        gameController.StartGame();
        timer.Update();
    }


}
