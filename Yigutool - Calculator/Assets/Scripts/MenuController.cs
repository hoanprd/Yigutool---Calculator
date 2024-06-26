using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Diagnostics;

public class MenuController : MonoBehaviour
{
    public GameObject DuelPanel;
    public GameObject DuelPanelConfirm;
    public GameObject HowToUsePanel;
    public GameObject SettingPanel;
    public GameObject LogA;
    public GameObject AboutUsPanel;
    public GameObject OnTimerButton, OffTimerButton;
    public GameObject[] DiceFace;
    public GameObject[] TutoI;
    public InputField P1NameInput, P2NameInput, LPInput, TurnTimerInput;
    public AudioSource NCS, CCS, CS;

    public static int P1R, P2R;
    public static float BaseTimeR;
    public static string P1Name, P2Name;
    public int DiceRand, TutoIIndex;

    public static int GoFirst = 1;

    // Start is called before the first frame update
    void Start()
    {
        TutoIIndex = 0;

        P1NameInput.text = "Player 1";
        P2NameInput.text = "Player 2";

        if (!PlayerPrefs.HasKey("SSettingLP"))
        {
            PlayerPrefs.SetInt("SSettingLP", 8000);
            LPInput.text = PlayerPrefs.GetInt("SSettingLP").ToString();
        }
        else
        {
            LPInput.text = PlayerPrefs.GetInt("SSettingLP").ToString();
        }

        if (!PlayerPrefs.HasKey("SSettingTurnTimer"))
        {
            PlayerPrefs.SetInt("SSettingTurnTimer", 5);
            TurnTimerInput.text = PlayerPrefs.GetInt("SSettingTurnTimer").ToString();
        }
        else
        {
            TurnTimerInput.text = PlayerPrefs.GetInt("SSettingTurnTimer").ToString();
        }

        if (!PlayerPrefs.HasKey("SOnOffTimer"))
        {
            PlayerPrefs.SetInt("SOnOffTimer", 1);
        }

        P1R = Convert.ToInt32(LPInput.text);
        P2R = Convert.ToInt32(LPInput.text);

        BaseTimeR = 60 * float.Parse(TurnTimerInput.text);

        if (PlayerPrefs.GetInt("SOnOffTimer") == 1)
        {
            OnTimerButton.SetActive(true);
            OffTimerButton.SetActive(false);
        }
        else
        {
            OnTimerButton.SetActive(false);
            OffTimerButton.SetActive(true);
        }    
    }

    public void OpenDuelPanel()
    {
        NCS.Play();
        DuelPanel.SetActive(true);
    }

    public void CloseDuelPanel()
    {
        NCS.Play();
        DuelPanel.SetActive(false);
    }

    public void GoDuel()
    {
        NCS.Play();
        DuelPanelConfirm.SetActive(true);
    }

    public void CloseConfirmPanel()
    {
        NCS.Play();
        DuelPanelConfirm.SetActive(false);
    }

    public void P1GoFirst()
    {
        NCS.Play();
        GoFirst = 1;
        MainController.P1Name = P1NameInput.text;
        MainController.P2Name = P2NameInput.text;
        MainController.NumTurn = 1;
        MainController.StatePhase = 1;
        MainController.P1LP = Convert.ToInt32(LPInput.text);
        MainController.P2LP = Convert.ToInt32(LPInput.text);
        MainController.BaseTotalTurnTimer = 60 * float.Parse(TurnTimerInput.text);
        MainController.TotalTurnTimerP1 = MainController.BaseTotalTurnTimer;
        MainController.TotalTurnTimerP2 = MainController.BaseTotalTurnTimer;
        MainController.Log = null;
        P1R = Convert.ToInt32(LPInput.text);
        P2R = Convert.ToInt32(LPInput.text);
        BaseTimeR = 60 * float.Parse(TurnTimerInput.text);
        SceneManager.LoadScene("Main");
    }

    public void P2GoFirst()
    {
        NCS.Play();
        GoFirst = 2;
        MainController.P1Name = P1NameInput.text;
        MainController.P2Name = P2NameInput.text;
        MainController.NumTurn = 1;
        MainController.StatePhase = 1;
        MainController.P1LP = Convert.ToInt32(LPInput.text);
        MainController.P2LP = Convert.ToInt32(LPInput.text);
        MainController.BaseTotalTurnTimer = 60 * float.Parse(TurnTimerInput.text);
        MainController.TotalTurnTimerP1 = MainController.BaseTotalTurnTimer;
        MainController.TotalTurnTimerP2 = MainController.BaseTotalTurnTimer;
        MainController.Log = null;
        P1R = Convert.ToInt32(LPInput.text);
        P2R = Convert.ToInt32(LPInput.text);
        BaseTimeR = 60 * float.Parse(TurnTimerInput.text);
        SceneManager.LoadScene("Main");
    }

    public void RollDice()
    {
        NCS.Play();
        StartCoroutine(DelayDice());
    }

    public void LoadDuel()
    {
        NCS.Play();
        if (PlayerPrefs.GetInt("SSave") == 1)
        {
            MainController.NumTurn = PlayerPrefs.GetInt("STurn");
            MainController.StatePhase = PlayerPrefs.GetInt("SStatePhase");
            MainController.P1LP = PlayerPrefs.GetInt("SP1LP");
            MainController.P2LP = PlayerPrefs.GetInt("SP2LP");
            MainController.P1Name = PlayerPrefs.GetString("SP1Name");
            MainController.P2Name = PlayerPrefs.GetString("SP2Name");
            MainController.BaseTotalTurnTimer = PlayerPrefs.GetFloat("STotalTurnTimer");
            MainController.TotalTurnTimerP1 = PlayerPrefs.GetFloat("STotalTurnTimerP1");
            MainController.TotalTurnTimerP2 = PlayerPrefs.GetFloat("STotalTurnTimerP2");
            MainController.Log = PlayerPrefs.GetString("SLog");
            SceneManager.LoadScene("Main");
        }
        else
        {
            StartCoroutine(LoadLogA());
        }
    }

    public void OpenHowToUsePanel()
    {
        NCS.Play();
        TutoIIndex = 0;
        HowToUsePanel.SetActive(true);

        for (int i = 0; i < TutoI.Length; i++)
        {
            if (TutoIIndex == i)
            {
                TutoI[i].SetActive(true);
            }
            else
            {
                TutoI[i].SetActive(false);
            }
        }
    }

    public void OpenSettingPanel()
    {
        NCS.Play();
        SettingPanel.SetActive(true);    
    }

    public void OnTimer()
    {
        NCS.Play();
        OnTimerButton.SetActive(true);
        OffTimerButton.SetActive(false);
        PlayerPrefs.SetInt("SOnOffTimer", 1);
    }

    public void OffTimer()
    {
        NCS.Play();
        OnTimerButton.SetActive(false);
        OffTimerButton.SetActive(true);
        PlayerPrefs.SetInt("SOnOffTimer", 0);
    }

    public void DeleteLoadDuel()
    {
        NCS.Play();
        PlayerPrefs.SetInt("SSave", 0);
    }

    public void ExitApp()
    {
        NCS.Play();
        Application.Quit();
    }

    public void CloseHowToUsePanel()
    {
        NCS.Play();
        TutoIIndex = 0;
        HowToUsePanel.SetActive(false);
    }

    public void NextButton()
    {
        if (TutoIIndex < 3)
        {
            NCS.Play();
            TutoIIndex++;
        }

        for (int i = 0; i < TutoI.Length; i++)
        {
            if (TutoIIndex == i)
            {
                TutoI[i].SetActive(true);
            }
            else
            {
                TutoI[i].SetActive(false);
            }
        }
    }    

    public void CloseSettingPanel()
    {
        NCS.Play();
        PlayerPrefs.SetInt("SSettingLP", Convert.ToInt32(LPInput.text));
        PlayerPrefs.SetInt("SSettingTurnTimer", Convert.ToInt32(TurnTimerInput.text));
        SettingPanel.SetActive(false);
    }

    public void OpenAboutUsPanel()
    {
        NCS.Play();
        AboutUsPanel.SetActive(true);
    }

    public void CloseAboutUsPanel()
    {
        NCS.Play();
        AboutUsPanel.SetActive(false);
    }

    IEnumerator LoadLogA()
    {
        LogA.SetActive(true);
        yield return new WaitForSeconds(2f);

        LogA.SetActive(false);
    }

    IEnumerator DelayDice()
    {
        DiceRand = UnityEngine.Random.Range(0, 6);

        for (int i = 0; i < DiceFace.Length; i++)
        {
            DiceFace[i].SetActive(false);
        }

        for (int i = 0; i < DiceFace.Length; i++)
        {
            DiceFace[i].SetActive(true);
            if (i >= 1)
            {
                DiceFace[i - 1].SetActive(false);
            }
            yield return new WaitForSeconds(0.1f);
        }

        for (int i = 0; i < DiceFace.Length; i++)
        {
            if (DiceRand == i)
                DiceFace[i].SetActive(true);
            else
                DiceFace[i].SetActive(false);
        }
    }
}
