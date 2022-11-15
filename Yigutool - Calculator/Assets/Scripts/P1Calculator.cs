using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1Calculator : MonoBehaviour
{
    public GameObject P1Panel;
    public InputField P1CurLPInput, ValueInput;
    public Button Add, Sub, Div;
    public Text LogText;
    public AudioSource NCS, CCS, CS;

    public string Value;
    int IndexCal;

    // Start is called before the first frame update
    void Start()
    {
        P1CurLPInput.text = "" + MainController.P1LP;
        IndexCal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UIUpdate()
    {
        LogText.text = MainController.Log;
        P1CurLPInput.text = "" + MainController.P1LP;
        ValueInput.text = "" + Value;
    }

    public void AddValue()
    {
        CCS.Play();
        IndexCal = 1;
        Add.image.color = Color.green;
        Sub.image.color = Color.white;
        Div.image.color = Color.white;
    }

    public void SubValue()
    {
        CCS.Play();
        IndexCal = 2;
        Add.image.color = Color.white;
        Sub.image.color = Color.green;
        Div.image.color = Color.white;
    }

    public void DivValue()
    {
        CCS.Play();
        IndexCal = 3;
        Add.image.color = Color.white;
        Sub.image.color = Color.white;
        Div.image.color = Color.green;
    }

    public void button0()
    {
        CCS.Play();
        Value += "0";
        UIUpdate();
    }

    public void button1()
    {
        CCS.Play();
        Value += "1";
        UIUpdate();
    }

    public void button2()
    {
        CCS.Play();
        Value += "2";
        UIUpdate();
    }

    public void button3()
    {
        CCS.Play();
        Value += "3";
        UIUpdate();
    }

    public void button4()
    {
        CCS.Play();
        Value += "4";
        UIUpdate();
    }

    public void button5()
    {
        CCS.Play();
        Value += "5";
        UIUpdate();
    }

    public void button6()
    {
        CCS.Play();
        Value += "6";
        UIUpdate();
    }

    public void button7()
    {
        CCS.Play();
        Value += "7";
        UIUpdate();
    }

    public void button8()
    {
        CCS.Play();
        Value += "8";
        UIUpdate();
    }

    public void button9()
    {
        CCS.Play();
        Value += "9";
        UIUpdate();
    }

    public void DeleteValue()
    {
        CCS.Play();
        Value = null;
        UIUpdate();
    }

    public void OKP1()
    {
        if (IndexCal == 1)
        {
            CS.Play();
            MainController.P1LP += Convert.ToInt32(Value);
            if (MainController.P1LP < 0)
            {
                MainController.P1LP = 0;
            }

            if (MainController.Log == null || MainController.Log == "")
            {
                MainController.Log = "Turn " + MainController.NumTurn + " (" + MainController.P1Name + "): " + P1CurLPInput.text + " + " + Value + " = " + MainController.P1LP;
            }
            else
            {
                MainController.Log += "\nTurn " + MainController.NumTurn + " (" + MainController.P1Name + "): " + P1CurLPInput.text + " + " + Value + " = " + MainController.P1LP;
            }

            DeleteValue();

            P1CalPanelClose();
        }
        else if (IndexCal == 2)
        {
            CS.Play();
            MainController.P1LP -= Convert.ToInt32(Value);
            if (MainController.P1LP < 0)
            {
                MainController.P1LP = 0;
            }

            if (MainController.Log == null || MainController.Log == "")
            {
                MainController.Log = "Turn " + MainController.NumTurn + " (" + MainController.P1Name + "): " + P1CurLPInput.text + " - " + Value + " = " + MainController.P1LP;
            }
            else
            {
                MainController.Log += "\nTurn " + MainController.NumTurn + " (" + MainController.P1Name + "): " + P1CurLPInput.text + " - " + Value + " = " + MainController.P1LP;
            }

            DeleteValue();

            P1CalPanelClose();
        }
        else if (IndexCal == 3)
        {
            CS.Play();
            MainController.P1LP /= Convert.ToInt32(Value);
            if (MainController.P1LP < 0)
            {
                MainController.P1LP = 0;
            }

            if (MainController.Log == null || MainController.Log == "")
            {
                MainController.Log = "Turn " + MainController.NumTurn + " (" + MainController.P1Name + "): " + P1CurLPInput.text + " : " + Value + " = " + MainController.P1LP;
            }
            else
            {
                MainController.Log += "\nTurn " + MainController.NumTurn + " (" + MainController.P1Name + "): " + P1CurLPInput.text + " : " + Value + " = " + MainController.P1LP;
            }

            DeleteValue();


            P1CalPanelClose();
        }
    }

    public void P1CalPanelClose()
    {
        NCS.Play();
        P1Panel.SetActive(false);
    }
}
