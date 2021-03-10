using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;




public class SetConfig : MonoBehaviour
{
    [SerializeField] private int _backgroundGameColor,
                                 _sonds,
                                 _speed;
                                 

    [SerializeField] public static int _text;
                                 
    [SerializeField] private float _buttonNumber, _sequenceSize;


    //public Image fundo;

    #region Properties

    public static SetConfig Instance { get; set; } = null;

    public float ButtonNumber
    {
        get { return _buttonNumber; }
        set { _buttonNumber = value; }
    }
    
    public int BackgroundGameColor
    {
        get { return _backgroundGameColor; }
        set { _backgroundGameColor = value; }
    }

    public int Sonds
    {
        get { return _sonds; }
        set { _sonds = value; }
    }

    public int Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public float SequenceSize
    {
        get { return _sequenceSize; }
        set { _sequenceSize = value; }
    }

    public int TypeText
    {
        get { return _text; }
        set { _text = value; }
    }


    #endregion


    

    private void InitializeIndex()
    {
        ButtonNumber = 2;
        Speed = 0;
        SequenceSize = 1;
        BackgroundGameColor = 0;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        //fundo.color = new Color(104, 115, 191);

        InitializeIndex();
        ButtonNumber = 5;
    }

    public void CarregarCnfig()
    {
        

    }

        public void CarregarMenu()
    {
        
        
       

    }
    public void Jogar()
    {

        Blue.Instance.GetSelectButtons();
        Green.Instance.GetSelectButtons();
        Red.Instance.GetSelectButtons();
        Yellow.Instance.GetSelectButtons();
        Pink.Instance.GetSelectButtons();
        Wtblue.Instance.GetSelectButtons();
        Orange.Instance.GetSelectButtons();

        GameController.Instance.InitializeIndex();
    }

    public void SelectButtonNumber() => ButtonNumber = ConfigController.Instance.SliderButtonNumber.value;
    public void SelectSequenceSize() => SequenceSize = ConfigController.Instance.SliderSequenceSize.value;
    public void SelectSpeed() => Speed = ConfigController.Instance.DropdownSpeed.value;
    public void SelectBackgroundColor() => BackgroundGameColor = ConfigController.Instance.DropdownBackgroundColor.value;
    public void SelectSonds() => Sonds = ConfigController.Instance.DropdownSonds.value;
    public void SelectText() => TypeText = ConfigController.Instance.DropdownText.value;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Jogar();
        }
    }

    /*
    void Save()
    {
        //JSONObject setConfigJson = new JSONObject(JSONObject.Type.OBJECT);
        //int x = button;
        //JSONobject setConfigJson = new JSON();
        //setConfigJson.AddField("SelectButton", 7);
        //Debug.Log(setConfigJson.CreateString());
        //setConfigJson.Replace("SelectButton", x);
        //string encodedString = setConfigJson.Print();
        //Debug.Log(encodedString);
        seila();
        int r = PlayerPrefs.GetInt("button");
        Debug.Log(r);
    }

    void seila()
    {
        int x = 6;
        PlayerPrefs.SetInt("button", x);
    }
    */

}
