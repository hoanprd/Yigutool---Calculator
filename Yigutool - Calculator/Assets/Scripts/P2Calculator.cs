using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2Calculator : MonoBehaviour
{
    public GameObject P2Panel;
    public InputField P2CurLPInput, ValueInput;
    public Button Add, Sub, Div;

    public string Value;
    int IndexCal;

    // Start is called before the first frame update
    void Start()
    {
        P2CurLPInput.text = "" + MainController.P2LP;
        IndexCal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        P2CurLPInput.text = "" + MainController.P2LP;
    }

    void UIUpdate()
    {
        P2CurLPInput.text = "" + MainController.P2LP;
        ValueInput.text = "" + Value;
    }

    public void AddValue()
    {
        IndexCal = 1;
        Add.image.color = Color.green;
        Sub.image.color = Color.white;
        Div.image.color = Color.white;
    }

    public void SubValue()
    {
        IndexCal = 2;
        Add.image.color = Color.white;
        Sub.image.color = Color.green;
        Div.image.color = Color.white;
    }

    public void DivValue()
    {
        IndexCal = 3;
        Add.image.color = Color.white;
        Sub.image.color = Color.white;
        Div.image.color = Color.green;
    }

    public void button0()
    {
        Value += "0";
        UIUpdate();
    }

    public void button1()
    {
        Value += "1";
        UIUpdate();
    }

    public void button2()
    {
        Value += "2";
        UIUpdate();
    }

    public void button3()
    {
        Value += "3";
        UIUpdate();
    }

    public void button4()
    {
        Value += "4";
        UIUpdate();
    }

    public void button5()
    {
        Value += "5";
        UIUpdate();
    }

    public void button6()
    {
        Value += "6";
        UIUpdate();
    }

    public void button7()
    {
        Value += "7";
        UIUpdate();
    }

    public void button8()
    {
        Value += "8";
        UIUpdate();
    }

    public void button9()
    {
        Value += "9";
        UIUpdate();
    }

    public void DeleteValue()
    {
        Value = null;
        UIUpdate();
    }

    public void OKP2()
    {
        if (IndexCal == 1)
        {
            MainController.P2LP += Convert.ToInt32(Value);
            if (MainController.P2LP < 0)
            {
                MainController.P2LP = 0;
            }
            DeleteValue();

            P2CalPanelClose();
        }
        else if (IndexCal == 2)
        {
            MainController.P2LP -= Convert.ToInt32(Value);
            if (MainController.P2LP < 0)
            {
                MainController.P2LP = 0;
            }
            DeleteValue();

            P2CalPanelClose();
        }
        else if (IndexCal == 3)
        {
            MainController.P2LP /= Convert.ToInt32(Value);
            if (MainController.P2LP < 0)
            {
                MainController.P2LP = 0;
            }
            DeleteValue();


            P2CalPanelClose();
        }
    }

    public void P2CalPanelClose()
    {
        P2Panel.SetActive(false);
    }
}
