using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject DuelPanel;
    public GameObject DuelPanelConfirm;
    public GameObject HowToUsePanel;
    public GameObject SettingPanel;
    public GameObject[] DiceFace;
    public InputField P1NameInput, P2NameInput;

    public static string P1Name, P2Name;
    public int DiceRand;

    public static int GoFirst = 1;

    // Start is called before the first frame update
    void Start()
    {
        P1NameInput.text = "Player 1";
        P2NameInput.text = "Player 2";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDuelPanel()
    {
        DuelPanel.SetActive(true);
    }

    public void CloseDuelPanel()
    {
        DuelPanel.SetActive(false);
    }

    public void GoDuel()
    {
        DuelPanelConfirm.SetActive(true);
    }

    public void CloseConfirmPanel()
    {
        DuelPanelConfirm.SetActive(false);
    }

    public void P1GoFirst()
    {
        GoFirst = 1;
        MainController.P1Name = P1NameInput.text;
        MainController.P2Name = P2NameInput.text;
        MainController.NumTurn = 1;
        MainController.StatePhase = 1;
        MainController.P1LP = 8000;
        MainController.P2LP = 8000;
        MainController.Log = null;
        SceneManager.LoadScene("Main");
    }

    public void P2GoFirst()
    {
        GoFirst = 2;
        MainController.P1Name = P1NameInput.text;
        MainController.P2Name = P2NameInput.text;
        MainController.NumTurn = 1;
        MainController.StatePhase = 1;
        MainController.P1LP = 8000;
        MainController.P2LP = 8000;
        MainController.Log = null;
        SceneManager.LoadScene("Main");
    }

    public void RollDice()
    {
        StartCoroutine(DelayDice());
    }

    public void LoadDuel()
    {
        MainController.NumTurn = PlayerPrefs.GetInt("STurn");
        MainController.StatePhase = PlayerPrefs.GetInt("SStatePhase");
        MainController.P1LP = PlayerPrefs.GetInt("SP1LP");
        MainController.P2LP = PlayerPrefs.GetInt("SP2LP");
        MainController.P1Name = PlayerPrefs.GetString("SP1Name");
        MainController.P2Name = PlayerPrefs.GetString("SP2Name");
        MainController.Log = PlayerPrefs.GetString("SLog");
        SceneManager.LoadScene("Main");
    }

    public void OpenHowToUsePanel()
    {
        HowToUsePanel.SetActive(true);
    }

    public void OpenSettingPanel()
    {
        SettingPanel.SetActive(true);
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void CloseHowToUsePanel()
    {
        HowToUsePanel.SetActive(false);
    }

    public void CloseSettingPanel()
    {
        SettingPanel.SetActive(false);
    }

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
}
