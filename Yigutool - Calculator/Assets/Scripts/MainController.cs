using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    P1Calculator p1c;
    P2Calculator p2c;

    public GameObject P1Panel, P2Panel;
    public GameObject SettingPanel, ToolPanel, DicePanel, CoinPanel, ConfirmToMenuPanel;
    public GameObject P1ShowTurn, P2ShowTurn;
    public GameObject[] DiceFace;
    public GameObject[] CoinFace;
    public Button DP, SP, MP1, BP, MP2, EP;
    public Animator AniSetting, AniTool;
    public Text P1NameTag, P2NameTag, P1LPText, P2LPText;
    public Text NumTurnText;

    public int PGo, DiceRand, CoinRand;
    public static int NumTurn, StatePhase, P1LP, P2LP;
    public static string P1Name, P2Name, Log;
    private int SettingIndex, ToolIndex;

    // Start is called before the first frame update
    void Start()
    {
        SettingIndex = ToolIndex = 0;

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
            P1ShowTurn.SetActive(true);
            P2ShowTurn.SetActive(false);
        }
        else if (NumTurn % 2 != 0 && PGo == 2)
        {
            P1ShowTurn.SetActive(false);
            P2ShowTurn.SetActive(true);
        }
        else if (NumTurn % 2 == 0 && PGo == 1)
        {
            P1ShowTurn.SetActive(false);
            P2ShowTurn.SetActive(true);
        }
        else if (NumTurn % 2 == 0 && PGo == 2)
        {
            P1ShowTurn.SetActive(true);
            P2ShowTurn.SetActive(false);
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
    }

    //Turn
    public void ChangeTurn()
    {
        NumTurn++;
        NumTurnText.text = "Turn\n" + NumTurn;
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
        P1Panel.SetActive(true);
        p1c.UIUpdate();
    }

    public void P2CalPanelOpen()
    {
        P2Panel.SetActive(true);
        p2c.UIUpdate();
    }

    public void SettingPanelOpen()
    {
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
        ConfirmToMenuPanel.SetActive(true);
    }

    public void YesToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void NoToMenu()
    {
        ConfirmToMenuPanel.SetActive(false);
    }

    public void ToolPanelOpen()
    {
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
        DicePanel.SetActive(true);
    }

    public void CoinPanelOpen()
    {
        CoinPanel.SetActive(true);
    }

    public void DicePanelClose()
    {
        DicePanel.SetActive(false);
    }

    public void CoinPanelClose()
    {
        CoinPanel.SetActive(false);
    }

    //Save duel function
    public void SaveDuel()
    {
        PlayerPrefs.SetInt("STurn", NumTurn);
        PlayerPrefs.SetInt("SStatePhase", StatePhase);
        PlayerPrefs.SetInt("SP1LP", P1LP);
        PlayerPrefs.SetInt("SP2LP", P2LP);
        PlayerPrefs.SetString("SP1Name", P1Name);
        PlayerPrefs.SetString("SP2Name", P2Name);
        PlayerPrefs.SetString("SLog", Log);
    }

    //Dice function
    public void RollDice()
    {
        StartCoroutine(DelayDice());
    }

    //Coin function
    public void FlipCoin()
    {
        StartCoroutine(DelayCoin());
    }

    //Delay
    IEnumerator DelayDice()
    {
        DiceRand = Random.Range(0, 6);

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
        CoinRand = Random.Range(0, 2);

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
}
