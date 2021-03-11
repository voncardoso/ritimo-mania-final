using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum GameState
{
    SEQUENCIA, 
    RESPONDER, 
    NOVA, 
    ERRO
}

public class GameController : MonoBehaviour
{
    private static GameController _instance = null;
   // private float timeLevel;
   // public static bool stopTime = false ;
    //public Text timeLevel_txt;
   
   
    public GameState gameState;
    public Text rodadaTxt, tamanhoSeqTxt;

    public float speed;

    public Color[] cor;
    public GameObject[] botoes;
    public GameObject startButton;

    public List<int> coresSeq;
    public int idResposta, tamanhoSeq,
               rodada;

    private AudioSource fonteAudio;
    public AudioClip[] sons;
    public AudioClip[] notasDigital, notasPiano, notasFlauta;
    public AudioClip somAplausos;
    public GameObject canonConfete1, canonConfete2;
    public GameObject confeteParticulas1, confeteParticulas2;

    public GameObject buttonRepetir;

    public bool verificar;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public static GameController Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    void Start()
    {
        
        InitializeIndex();

    }

    public void InitializeIndex()
    {

        fonteAudio = GetComponent<AudioSource>();
        SpeedSelect();
        tamanhoSeq = Mathf.FloorToInt(SetConfig.Instance.SequenceSize);
        SondSelect();
        buttonRepetir.SetActive(false);
        tamanhoSeqTxt.text = string.Format("Sequência: {0}", tamanhoSeq + rodada);
    }

    void SondSelect()
    {
        int j = Mathf.FloorToInt(SetConfig.Instance.ButtonNumber);

        if (SetConfig.Instance.Sonds == 0)
        {
            for (int q = 0; q < j; q++)
            {
                sons[q] = notasPiano[q];
            }
        }
        else if (SetConfig.Instance.Sonds == 1)
        {
            for (int q = 0; q < j; q++)
            {
                sons[q] = notasDigital[q];
            }
        }
        else
        {
            for (int q = 0; q < j; q++)
            {

                sons[q] = notasFlauta[q];
            }
        }

    }

    void SpeedSelect()
    {
        if (SetConfig.Instance.Speed == 0)
        {
            speed = 0.5f;
        }
        else if (SetConfig.Instance.Speed == 1)
        {
            speed = 1;
        }
        else
        {
            speed = 1.5f;
        }
    }

    public void StartGame()
    {

        buttonRepetir.SetActive(false);
        foreach (GameObject obj in botoes)
        {
            
            obj.SetActive(false);
            
        }
        // if(stopTime == false){
         //   timeLevel = timeLevel + Time.deltaTime;
           // timeLevel_txt.text = timeLevel.ToString("F0");
          //  print("time" + timeLevel);
      //  }
        StartCoroutine("Sequencia", tamanhoSeq + rodada);

    }

    public void NovaRodada()
    {
        
        foreach (GameObject obj in botoes)
        {
            obj.SetActive(false);
        }

        coresSeq.Clear();

        startButton.SetActive(true);
        rodadaTxt.text = string.Format("Rodada: {0}", rodada + 1);
        tamanhoSeqTxt.text = string.Format("Sequência: {0}", tamanhoSeq + rodada);

    }

    IEnumerator Sequencia(int qtd)
    {
        startButton.SetActive(false);

        for (int r = qtd; r > 0; r--)
        {
            //Debug.Log(botoes.Length);
            //Debug.Log(Mathf.FloorToInt(SetConfig.Instance.ButtonNumber));

            yield return new WaitForSeconds(speed);
            int i = Random.Range(0, Mathf.FloorToInt(SetConfig.Instance.ButtonNumber)); //<<<-----------aki
            botoes[i].SetActive(true);
            fonteAudio.PlayOneShot(sons[i]);

            coresSeq.Add(i);

            yield return new WaitForSeconds(speed);
            botoes[i].SetActive(false);
        }

        gameState = GameState.RESPONDER;
        idResposta = 0;
        buttonRepetir.SetActive(true);

    }

    IEnumerator Responder(int idbotao)
    {
        //buttonRepetir.SetActive(false); old

        botoes[idbotao].SetActive(true);

        if (coresSeq[idResposta] == idbotao)
        {
            print("correto");
            verificar = true;
            fonteAudio.PlayOneShot(sons[idbotao]);
            Timer.stopTime = true;
            
        }
        else
        {
            print("errado");
            gameState = GameState.ERRO;
            verificar = false;
            StartCoroutine("GameOver");
        }
        
        idResposta += 1;

        if (idResposta == coresSeq.Count)
        {
            gameState = GameState.NOVA;

            if (verificar == true)
            {
                 Timer.stopTime = false;
                rodada += 1;
                Instantiate(confeteParticulas1, canonConfete1.transform.position, canonConfete1.transform.rotation);
                Instantiate(confeteParticulas2, canonConfete2.transform.position, canonConfete2.transform.rotation);
                fonteAudio.PlayOneShot(somAplausos);
                buttonRepetir.SetActive(false);
            }


            yield return new WaitForSeconds(speed);
            NovaRodada();
        }

        yield return new WaitForSeconds(0.3f);
        botoes[idbotao].SetActive(false);
    }

    IEnumerator GameOver()
    {
        buttonRepetir.SetActive(false);
        if (rodada <= 0)
        {
            rodada = 0;
        }
        else
        {
            rodada--;
        }
        fonteAudio.PlayOneShot(sons[Mathf.FloorToInt(SetConfig.Instance.ButtonNumber)]);

        yield return new WaitForSeconds(1);
        for (int i = 3; i >= 0; i--)
        {
            foreach (GameObject obj in botoes)
            {
                obj.SetActive(true);
            }
            yield return new WaitForSeconds(0.3f);
            foreach (GameObject obj in botoes)
            {
                obj.SetActive(false);
            }
            yield return new WaitForSeconds(0.3f);
        }

        NovaRodada();
    }

    IEnumerator Repetir(int qtd)
    {
        startButton.SetActive(false);
        buttonRepetir.SetActive(false);

        for (int r = 0; r < qtd; r++)
        {
            yield return new WaitForSeconds(speed);
            int i = coresSeq[r];
            botoes[i].SetActive(true);
            fonteAudio.PlayOneShot(sons[i]);
            Debug.Log(i);

            yield return new WaitForSeconds(speed);
            botoes[i].SetActive(false);
        }

        gameState = GameState.RESPONDER;
        idResposta = 0;
        buttonRepetir.SetActive(true);
    }

    public void RepetirFun()
    {
        StartCoroutine("Repetir", tamanhoSeq + rodada);
    }
}
