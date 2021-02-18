using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//metodo de adicionar novos estilos de Botoes

public class BlueHerenca : Blue
{
    private void Start()
    {
        GetSelectButtons();
    }

    private void Update()
    {
        InputRadar();
    }
}
