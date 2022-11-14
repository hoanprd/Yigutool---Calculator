using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject DuelPanel;
    public GameObject DuelPanelConfirm;

    public static int GoFirst = 1;

    // Start is called before the first frame update
    void Start()
    {
        
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
        SceneManager.LoadScene("Main");
    }

    public void P2GoFirst()
    {
        GoFirst = 2;
        SceneManager.LoadScene("Main");
    }
}
