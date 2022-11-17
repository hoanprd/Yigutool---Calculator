using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainController : MonoBehaviour
{
    MenuController menuc;
    P1Calculator p1c;
    P2Calculator p2c;

    public GameObject P1Panel, P2Panel;
    public GameObject ResetPanel, SettingPanel, ToolPanel, DicePanel, CoinPanel, ConfirmRestartPanel, ConfirmToMenuPanel;
    public GameObject P1ShowTurn, P2ShowTurn, PauseTimerP1, PauseTimerP2, SaveA;
    public GameObject[] DiceFace;
    public GameObject[] CoinFace;
    public Button DP, SP, MP1, BP, MP2, EP;
    public Animator AniReset, AniSetting, AniTool;
    public InputField FindCardInput;
    public Text P1NameTag, P2NameTag, P1LPText, P2LPText, P1TurnTimerText, P2TurnTimerText;
    public Text NumTurnText;
    public AudioSource NCS, CCS, CS;

    public int PGo, DiceRand, CoinRand, MinTurnTimerP1, SecTurnTimerP1, MinTurnTimerP2, SecTurnTimerP2, PauseTimerIndexP1, PauseTimerIndexP2;
    public bool P1PauseTimer, P2PauseTimer;
    public static int NumTurn, StatePhase, P1LP, P2LP, StatePlayerTurn;
    public static float BaseTotalTurnTimer, TotalTurnTimerP1, TotalTurnTimerP2;
    public static string P1Name, P2Name, Log;
    private int ResetIndex, SettingIndex, ToolIndex;

    // Start is called before the first frame update
    void Start()
    {
        SettingIndex = ToolIndex = 0;
        PauseTimerIndexP1 = PauseTimerIndexP2 = 0;

        if (MenuController.GoFirst == 1)
        {
            P1ShowTurn.SetActive(true);
            PGo = 1;
        }
        else if (MenuController.GoFirst == 2)
        {
            P2ShowTurn.SetActive(true);
            PGo = 2;
        }

        P1NameTag.text = P1Name;
        P2NameTag.text = P2Name;

        UpdateUI();

        menuc = FindObjectOfType<MenuController>();
        p1c = FindObjectOfType<P1Calculator>();
        p2c = FindObjectOfType<P2Calculator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        NumTurnText.text = "Turn\n" + NumTurn;
        P1LPText.text = "" + P1LP;
        P2LPText.text = "" + P2LP;

        if (NumTurn % 2 != 0 && PGo == 1)
        {
            StatePlayerTurn = 1;
            P1ShowTurn.SetActive(true);
            P2ShowTurn.SetActive(false);
            PauseTimerP1.SetActive(true);
            PauseTimerP2.SetActive(false);
        }
        else if (NumTurn % 2 != 0 && PGo == 2)
        {
            StatePlayerTurn = 2;
            P1ShowTurn.SetActive(false);
            P2ShowTurn.SetActive(true);
            PauseTimerP1.SetActive(false);
            PauseTimerP2.SetActive(true);
        }
        else if (NumTurn % 2 == 0 && PGo == 1)
        {
            StatePlayerTurn = 2;
            P1ShowTurn.SetActive(false);
            P2ShowTurn.SetActive(true);
            PauseTimerP1.SetActive(false);
            PauseTimerP2.SetActive(true);
        }
        else if (NumTurn % 2 == 0 && PGo == 2)
        {
            StatePlayerTurn = 1;
            P1ShowTurn.SetActive(true);
            P2ShowTurn.SetActive(false);
            PauseTimerP1.SetActive(true);
            PauseTimerP2.SetActive(false);
        }

        if (StatePhase == 1)
            DPButton();
        else if (StatePhase == 2)
            SPButton();
        else if (StatePhase == 3)
            MP1Button();
        else if (StatePhase == 4)
            BPButton();
        else if (StatePhase == 5)
            MP2Button();
        else if (StatePhase == 6)
            EPButton();

        MinTurnTimerP1 = (int)(TotalTurnTimerP1 % 3600 / 60);
        SecTurnTimerP1 = (int)(TotalTurnTimerP1 % 3600 % 60);
        P1TurnTimerText.text = MinTurnTimerP1 + ":" + SecTurnTimerP1;

        MinTurnTimerP2 = (int)(TotalTurnTimerP2 % 3600 / 60);
        SecTurnTimerP2 = (int)(TotalTurnTimerP2 % 3600 % 60);
        P2TurnTimerText.text = MinTurnTimerP2 + ":" + SecTurnTimerP2;

        if (TotalTurnTimerP1 > 0 && StatePlayerTurn == 1 && P1PauseTimer == false)
        {
            TotalTurnTimerP1 -= 1 * Time.deltaTime;
        }
        else if (TotalTurnTimerP1 > 0 && StatePlayerTurn == 1 && P1PauseTimer == true)
        {
            TotalTurnTimerP2 -= 1 * Time.deltaTime;
        }
        else if (TotalTurnTimerP1 <= 0)
        {
            TotalTurnTimerP1 = BaseTotalTurnTimer;
            ChangeTurn();
            DPButton();
        }

        if (TotalTurnTimerP2 > 0 && StatePlayerTurn == 2 && P2PauseTimer == false)
        {
            TotalTurnTimerP2 -= 1 * Time.deltaTime;
        }
        else if (TotalTurnTimerP2 > 0 && StatePlayerTurn == 2 && P2PauseTimer == true)
        {
            TotalTurnTimerP1 -= 1 * Time.deltaTime;
        }
        else if (TotalTurnTimerP2 <= 0)
        {
            TotalTurnTimerP2 = BaseTotalTurnTimer;
            ChangeTurn();
            DPButton();
        }
    }

    //Turn
    public void ChangeTurn()
    {
        NCS.Play();
        NumTurn++;
        NumTurnText.text = "Turn\n" + NumTurn;
        TotalTurnTimerP1 = BaseTotalTurnTimer;
        TotalTurnTimerP2 = BaseTotalTurnTimer;
        DPButton();
    }

    //Timer
    public void P1PauseButton()
    {
        NCS.Play();
        PauseTimerIndexP1++;
        if (PauseTimerIndexP1 % 2 != 0)
            P1PauseTimer = true;
        else if (PauseTimerIndexP1 % 2 == 0)
            P1PauseTimer = false;
    }

    public void P2PauseButton()
    {
        NCS.Play();
        PauseTimerIndexP2++;
        if (PauseTimerIndexP2 % 2 != 0)
            P2PauseTimer = true;
        else if (PauseTimerIndexP2 % 2 == 0)
            P2PauseTimer = false;
    }

    //Phase
    public void DPButton()
    {
        StatePhase = 1;
        DP.image.color = Color.green;
        SP.image.color = Color.white;
        MP1.image.color = Color.white;
        BP.image.color = Color.white;
        MP2.image.color = Color.white;
        EP.image.color = Color.white;
    }

    public void SPButton()
    {
        StatePhase = 2;
        DP.image.color = Color.white;
        SP.image.color = Color.green;
        MP1.image.color = Color.white;
        BP.image.color = Color.white;
        MP2.image.color = Color.white;
        EP.image.color = Color.white;
    }

    public void MP1Button()
    {
        StatePhase = 3;
        DP.image.color = Color.white;
        SP.image.color = Color.white;
        MP1.image.color = Color.green;
        BP.image.color = Color.white;
        MP2.image.color = Color.white;
        EP.image.color = Color.white;
    }

    public void BPButton()
    {
        StatePhase = 4;
        DP.image.color = Color.white;
        SP.image.color = Color.white;
        MP1.image.color = Color.white;
        BP.image.color = Color.green;
        MP2.image.color = Color.white;
        EP.image.color = Color.white;
    }

    public void MP2Button()
    {
        StatePhase = 5;
        DP.image.color = Color.white;
        SP.image.color = Color.white;
        MP1.image.color = Color.white;
        BP.image.color = Color.white;
        MP2.image.color = Color.green;
        EP.image.color = Color.white;
    }

    public void EPButton()
    {
        StatePhase = 6;
        DP.image.color = Color.white;
        SP.image.color = Color.white;
        MP1.image.color = Color.white;
        BP.image.color = Color.white;
        MP2.image.color = Color.white;
        EP.image.color = Color.green;
    }

    //Open/Close Panel
    public void P1CalPanelOpen()
    {
        NCS.Play();
        P1Panel.SetActive(true);
        p1c.UIUpdate();
    }

    public void P2CalPanelOpen()
    {
        NCS.Play();
        P2Panel.SetActive(true);
        p2c.UIUpdate();
    }

    public void FindCard()
    {
        Application.OpenURL("https://yugipedia.com/wiki/" + FindCardInput.text);
    }

    public void ResetPanelOpen()
    {
        NCS.Play();
        ResetIndex++;
        if (ResetIndex % 2 != 0)
        {
            ResetPanel.GetComponent<Animator>().enabled = true;
            AniReset.SetTrigger("OpenReset");
        }
        else if (ResetIndex % 2 == 0)
        {
            AniReset.SetTrigger("CloseReset");
        }
    }

    public void BackwardTurn()
    {
        NCS.Play();
        if (NumTurn > 1)
        {
            NumTurn--;
            NumTurnText.text = "Turn\n" + NumTurn;
            TotalTurnTimerP1 = BaseTotalTurnTimer;
            TotalTurnTimerP2 = BaseTotalTurnTimer;
        }
    }

    public void OpenRestartGamePanel()
    {
        ConfirmRestartPanel.SetActive(true);
    }

    public void CloseRestartGamePanel()
    {
        ConfirmRestartPanel.SetActive(false);
    }

    public void RestartP1GoFirst()
    {
        NCS.Play();
        MenuController.GoFirst = 1;
        NumTurn = 1;
        StatePhase = 1;
        P1LP = MenuController.P1R;
        P2LP = MenuController.P2R;
        BaseTotalTurnTimer = MenuController.BaseTimeR;
        TotalTurnTimerP1 = BaseTotalTurnTimer;
        TotalTurnTimerP2 = BaseTotalTurnTimer;
        Log = null;
        SceneManager.LoadScene("Main");
    }

    public void RestartP2GoFirst()
    {
        NCS.Play();
        MenuController.GoFirst = 2;
        NumTurn = 1;
        StatePhase = 1;
        P1LP = MenuController.P1R;
        P2LP = MenuController.P2R;
        BaseTotalTurnTimer = MenuController.BaseTimeR;
        TotalTurnTimerP1 = BaseTotalTurnTimer;
        TotalTurnTimerP2 = BaseTotalTurnTimer;
        Log = null;
        SceneManager.LoadScene("Main");
    }

    public void SettingPanelOpen()
    {
        NCS.Play();
        SettingIndex++;

        if (SettingIndex % 2 != 0)
        {
            SettingPanel.GetComponent<Animator>().enabled = true;
            AniSetting.SetTrigger("OpenSetting");
        }
        else if (SettingIndex % 2 == 0)
        {
            AniSetting.SetTrigger("CloseSetting");
        }
    }

    public void GoBackToMenu()
    {
        NCS.Play();
        ConfirmToMenuPanel.SetActive(true);
    }

    public void YesToMenu()
    {
        NCS.Play();
        SceneManager.LoadScene("Menu");
    }

    public void NoToMenu()
    {
        NCS.Play();
        ConfirmToMenuPanel.SetActive(false);
    }

    public void ToolPanelOpen()
    {
        NCS.Play();
        ToolIndex++;

        if (ToolIndex % 2 != 0)
        {
            ToolPanel.GetComponent<Animator>().enabled = true;
            AniTool.SetTrigger("OpenTool");
        }
        else if (ToolIndex % 2 == 0)
        {
            AniTool.SetTrigger("CloseTool");
        }
    }

    public void DicePanelOpen()
    {
        NCS.Play();
        DicePanel.SetActive(true);
    }

    public void CoinPanelOpen()
    {
        NCS.Play();
        CoinPanel.SetActive(true);
    }

    public void DicePanelClose()
    {
        NCS.Play();
        DicePanel.SetActive(false);
    }

    public void CoinPanelClose()
    {
        NCS.Play();
        CoinPanel.SetActive(false);
    }

    //Save duel function
    public void SaveDuel()
    {
        NCS.Play();
        PlayerPrefs.SetInt("STurn", NumTurn);
        PlayerPrefs.SetInt("SStatePhase", StatePhase);
        PlayerPrefs.SetInt("SP1LP", P1LP);
        PlayerPrefs.SetInt("SP2LP", P2LP);
        PlayerPrefs.SetFloat("STotalTurnTimer", BaseTotalTurnTimer);
        PlayerPrefs.SetFloat("STotalTurnTimerP1", TotalTurnTimerP1);
        PlayerPrefs.SetFloat("STotalTurnTimerP2", TotalTurnTimerP2);
        PlayerPrefs.SetString("SP1Name", P1Name);
        PlayerPrefs.SetString("SP2Name", P2Name);
        PlayerPrefs.SetString("SLog", Log);
        PlayerPrefs.SetInt("SSave", 1);
        SaveA.SetActive(true);
        StartCoroutine(DisplaySaveA());
    }

    //Dice function
    public void RollDice()
    {
        NCS.Play();
        StartCoroutine(DelayDice());
    }

    //Coin function
    public void FlipCoin()
    {
        NCS.Play();
        StartCoroutine(DelayCoin());
    }

    //Delay
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

    IEnumerator DelayCoin()
    {
        CoinRand = UnityEngine.Random.Range(0, 2);

        for (int i = 0; i < CoinFace.Length; i++)
        {
            CoinFace[i].SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }

        for (int i = 0; i < CoinFace.Length; i++)
        {
            if (CoinRand == i)
                CoinFace[i].SetActive(true);
            else
                CoinFace[i].SetActive(false);
        }
    }

    IEnumerator DisplaySaveA()
    {
        yield return new WaitForSeconds(2f);

        SaveA.SetActive(false);
    }
}
