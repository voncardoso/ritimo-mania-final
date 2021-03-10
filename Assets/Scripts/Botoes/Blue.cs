using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : ButtonClass
{
    private float x, y, z;
    private float sx, sy, sz;
    private float selectButton;

    public static Blue Instance { get; set; } = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
    }


    public float SelectButton
    {
        get => selectButton;
        set => selectButton = value;
    }

    void Start()
    {
        
        SelectButtons();

        //Debug.Log("BLUE");
        //Debug.Log(transform.position);
       // Debug.Log(transform.localScale);
       // Debug.Log("--------------------");
    }

    private void Update()
    {
        InputRadar();
    }

    public void InputRadar()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SelectButton = SetConfig.Instance.ButtonNumber;
            SelectButtons();
            //Debug.Log(selectButton);
        }
    }

    public void Load() => SetConfig.Instance.ButtonNumber = 3;

    public void GetSelectButtons() => SelectButtons();

    private void SelectButtons()
    {
        selectButton = SetConfig.Instance.ButtonNumber;

        if (selectButton == 7)
        {
            x = -6.5f;
            y = 1.9f;
            z = 85.8f;
            sx = 50f;
            sy = 50f;
            sz = 50f;
            transform.position = new Vector3(x, y, z);
            transform.localScale = new Vector3(sx, sy, sz);
        }
        else if (selectButton == 6)
        {
            x = -4.0f;
            y = 1.8f;
            z = 85.8f;
            sx = 50f;
            sy = 50f;
            sz = 50f;
            transform.position = new Vector3(x, y, z);
            transform.localScale = new Vector3(sx, sy, sz);
        }
        else if (selectButton == 5)
        {
            x = -3.9f;
            y = 1.7f;
            z = 85.8f;
            sx = 50f;
            sy = 50f;
            sz = 50f;
            transform.position = new Vector3(x, y, z);
            transform.localScale = new Vector3(sx, sy, sz);
        }
        else if (selectButton == 4)
        {
            x = -6.2f;
            y = 0;
            z = 85.8f;
            sx = 50f;
            sy = 50f;
            sz = 50f;
            transform.position = new Vector3(x, y, z);
            transform.localScale = new Vector3(sx, sy, sz);
        }
        else if (selectButton == 3)
        {
            x = -5.4f;
            y = 0f;
            z = 85.8f;
            sx = 60f;
            sy = 60f;
            sz = 60f;
            transform.position = new Vector3(x, y, z);
            transform.localScale = new Vector3(sx, sy, sz);
        }
        else if (selectButton == 2)
        {
            x = -4f;
            y = 0f;
            z = 85.8f;
            sx = 80f;
            sy = 80f;
            sz = 80f;
            transform.position = new Vector3(x, y, z);
            transform.localScale = new Vector3(sx, sy, sz);
        }
        else
        {
            x = 20;
            y = 0f;
            z = 85.8f;
            sx = 50f;
            sy = 50f;
            sz = 50f;
            transform.position = new Vector3(x, y, z);
            transform.localScale = new Vector3(sx, sy, sz);
        }
    }
}
