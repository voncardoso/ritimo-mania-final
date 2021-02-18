using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textoOnOffButton : MonoBehaviour
{
    public GameObject Onoff;
    public GameObject Cores;
    public GameObject Notas;
    public Text t1, t2, t3, t4, t5, t6, t7, ton;

    void Start()
    {
        ton.text = "Ligar";
    }

    public void LigarDesligar()
    {
        if (ton.text == "Desligar")
        {
            ton.text = "Ligar";
            Cores.SetActive(false);
            Notas.SetActive(false);
            t1.text = " ";
            t2.text = " ";
            t3.text = " ";
            t4.text = " ";
            t5.text = " ";
            t6.text = " ";
            t7.text = " ";
        }
        else {
            ton.text = "Desligar";
            Cores.SetActive(true);
            Notas.SetActive(true);
        }

    }

    public void LigarNotas()
    {
        t1.text = "Dó";
        t2.text = "Ré";
        t3.text = "Mi";
        t4.text = "Fá";
        t5.text = "Sol";
        t6.text = "Lá";
        t7.text = "Si";
    }

    public void LigarCores()
    {
        t1.text = "Azul";
        t2.text = "Verde";
        t3.text = "Vermelho";
        t4.text = "Amarelo";
        t5.text = "Rosa";
        t6.text = "Ciano";
        t7.text = "Laranja";
    }
    
}
