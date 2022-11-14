using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public GameObject P1Panel, P2Panel;
    public GameObject SettingPanel, ToolPanel;
    public GameObject P1ShowTurn, P2ShowTurn;
    public Animator AniSetting, AniTool;
    public Text P1LPText, P2LPText;
    public Text NumTurnText;

    public int NumTurn, PGo;
    public static int P1LP, P2LP;
    private int SettingIndex, ToolIndex;

    // Start is called before the first frame update
    void Start()
    {
        SettingIndex = ToolIndex = 0;
        NumTurn = 1;

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

        P1LP = 8000;
        P2LP = 8000;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
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
    }

    //Turn
    public void ChangeTurn()
    {
        NumTurn++;
        NumTurnText.text = "Turn\n" + NumTurn;
    }

    //Open/Close Panel
    public void P1CalPanelOpen()
    {
        P1Panel.SetActive(true);
    }

    public void P2CalPanelOpen()
    {
        P2Panel.SetActive(true);
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
}
