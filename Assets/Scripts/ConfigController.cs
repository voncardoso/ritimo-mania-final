using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigController : MonoBehaviour
{
    
    [SerializeField] private Slider _sliderSequenceSize,
                                    _sliderButtonNumber;
    [SerializeField] private Dropdown _dropdownBackgroundColor, 
                                      _dropdownSpeed, 
                                      _dropdownSonds,
                                      _dropdownText;

    [SerializeField] private Text textSlider1,
                                  textSlider2;

    private static ConfigController _instance = null;

    private List<string> _colorsList;
    private List<string> _speedList;
    private List<string> _sondsList;

   
    private void Start()
    {
        
        SliderButtonNumber.value = 5;

        textSlider1.text = SliderButtonNumber.value.ToString("#");
        textSlider2.text = SliderSequenceSize.value.ToString("#");

        InitializeLists();
        InitializeDropdown();
        AddListeners();
        //UpdateIndex();
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public static ConfigController Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    #region Getters and Setters
    public Slider SliderSequenceSize
    {
        get { return _sliderSequenceSize; }
        set { _sliderSequenceSize = value; }
    }

    public Slider SliderButtonNumber
    {
        get { return _sliderButtonNumber; }
        set { _sliderButtonNumber = value; }
    }

    public Dropdown DropdownBackgroundColor
    {
        get { return _dropdownBackgroundColor; }
        set { _dropdownBackgroundColor = value; }
    }

    public Dropdown DropdownSpeed
    {
        get { return _dropdownSpeed; }
        set { _dropdownSpeed = value; }
    }

    public Dropdown DropdownSonds
    {
        get { return _dropdownSonds; }
        set { _dropdownSonds = value; }
    }

    public Dropdown DropdownText
    {
        get { return _dropdownText; }
        set { _dropdownText = value; }
    }
    #endregion

    private void InitializeLists()
    {
        _colorsList = new List<string> { "Branco", "Preto" };
        _speedList = new List<string> { "Rápido", "Normal", "Lento" };
        _sondsList = new List<string> { "Piano", "Digital", "Flauta" };
    }

    private void InitializeDropdown()
    {
        DropdownBackgroundColor.AddOptions(_colorsList);
        DropdownSpeed.AddOptions(_speedList);
        DropdownSonds.AddOptions(_sondsList);
    }

    private void AddListeners()
    {
        SliderButtonNumber.onValueChanged.AddListener((value) => { SetConfig.Instance.SelectButtonNumber(); });
        SliderSequenceSize.onValueChanged.AddListener((value) => { SetConfig.Instance.SelectSequenceSize(); });
        DropdownSpeed.onValueChanged.AddListener((value) => { SetConfig.Instance.SelectSpeed(); });
        DropdownBackgroundColor.onValueChanged.AddListener((value) => { SetConfig.Instance.SelectBackgroundColor(); });
        DropdownSonds.onValueChanged.AddListener((value) => { SetConfig.Instance.SelectSonds(); });
        DropdownText.onValueChanged.AddListener((value) => { SetConfig.Instance.SelectText(); });
    }

    private void TextSliderUpdate()
    {
        textSlider1.text = SliderButtonNumber.value.ToString("#");
        textSlider2.text = SliderSequenceSize.value.ToString("#");
    }

    private void Update()
    {
        TextSliderUpdate();
    }
}
