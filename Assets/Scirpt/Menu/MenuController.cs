using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject[] menu;

    [Header("Main Menu")]
    [SerializeField] private GameObject descPanelMainMenu;
    [SerializeField] private Text[] textMainMenu;
    [SerializeField] private GameObject[] btnMainMenu;
    private string[] _textMainMenu;

    [Header("Mini Game Level")]
    [SerializeField] private Text[] textMiniGame;
    [SerializeField] private GameObject[] btnMiniGame;
    private string[] _textMiniGame;

    [Header("Level Menu")]
    [SerializeField] private GameObject descPanelLevelMenu;
    [SerializeField] private Text[] textLevelMenu;
    [SerializeField] private GameObject[] btnLevelMenu;
    private string[] _textLevelMenu;

    bool mainMenuisActive, miniGameMenuisActive, levelMenuisActive;

    private void Awake()
    {
        ValueTextMainMenu();
        SetTextMainMenu();
        SetButtonMainMenu();

        ValueTextMiniGameMenu();
        SetTextMiniGameMenu();
        SetButtonMiniGameMenu();
    }

    void Start()
    {
        RestartMenu();
        CheckMenu();
    }

    #region General configuration
    private void CheckMenu()
    {
        if (miniGameMenuisActive == false && mainMenuisActive == true && levelMenuisActive == false)
        {
            menu[0].SetActive(true);
            menu[1].SetActive(false);
            menu[2].SetActive(false);
            menu[3].SetActive(false);

            InfoPanelGetClose();
        }
        else if (miniGameMenuisActive == true && mainMenuisActive == false && levelMenuisActive == false)
        {
            menu[0].SetActive(false);
            menu[1].SetActive(true);
            menu[2].SetActive(false);
            menu[3].SetActive(false);

        }
        else if (miniGameMenuisActive == false && mainMenuisActive == false && levelMenuisActive == true)
        {
            menu[0].SetActive(false);
            menu[1].SetActive(false);
            menu[2].SetActive(true);
            menu[3].SetActive(false);

            InfoPanelGetClose();
        }
    }

    private void RestartMenu()
    {
        mainMenuisActive = true;
        miniGameMenuisActive = false;
        levelMenuisActive = false;
    }

    private void InfoPanelGetOpen()
    {
        if (mainMenuisActive == true && levelMenuisActive == false)
            descPanelMainMenu.SetActive(true);
        else if (mainMenuisActive == false && levelMenuisActive == true)
            descPanelLevelMenu.SetActive(true);
    }

    private void InfoPanelGetClose()
    {
        if (mainMenuisActive == true && levelMenuisActive == false)
            descPanelMainMenu.SetActive(false);
        else if (mainMenuisActive == false && levelMenuisActive == true)
            descPanelLevelMenu.SetActive(false);
    }

    #endregion

    #region Main Menu

    private void ValueTextMainMenu()
    {
        _textMainMenu = new string[3];
        _textMainMenu[0] = "Play" ;
        _textMainMenu[1] = "Exit" ;
        _textMainMenu[2] = "Virtual Laboratorium - Kamanan Pangan merupakan sebuah permainan edukasi mengenai keamanan pangan yang bertujuan agar pemain mengetahuikondisi dan upaya yang diperlukan untuk mencegah pangan dari kemungkinan tiga cemaran, yaitu cemaran biologis, kimia, dan benda lain yang dapat mengganggu, merugikan, dan membahayakan kesehatan";
    }

    private void SetTextMainMenu()
    {
        for (int i = 0; i < textMainMenu.Length; i++)
            textMainMenu[i].text = _textMainMenu[i];
    }

    private void SetButtonMainMenu()
    {
        for (int i = 0; i < btnMainMenu.Length; i++)
        {
            switch (i)
            {
                case 0:
                    btnMainMenu[0] = GameObject.Find("BTN_Info");
                    btnMainMenu[0].GetComponent<Button>().onClick.AddListener(InfoPanelGetOpen);
                    break;
                case 1:
                    btnMainMenu[1] = GameObject.Find("BTN_MiniGameMenu");
                    btnMainMenu[1].GetComponent<Button>().onClick.AddListener(PlayMainMenu);
                    break;

                case 2:
                    btnMainMenu[2] = GameObject.Find("BTN_ExitGame");
                    btnMainMenu[2].GetComponent<Button>().onClick.AddListener(ExitGame);
                    break;

                case 3:
                    btnMainMenu[3] = GameObject.Find("BTN_CLose");
                    btnMainMenu[3].GetComponent<Button>().onClick.AddListener(InfoPanelGetClose);
                    break;

                default:
                    Debug.LogWarning("Check Ur Key");
                    break;
            }
        }

            
    }

    private void PlayMainMenu()
    {
        miniGameMenuisActive = true;
        mainMenuisActive = false;
        levelMenuisActive = false;

        CheckMenu();
    }

    private void ExitGame()
    {
        Application.Quit();
        Debug.Log("IsQiet");
    }

    #endregion

    #region Mini Game Menu

    private void ValueTextMiniGameMenu()
    {
        _textMiniGame = new string[2];

        _textMiniGame[0] = "Deteksi Coliform";
        _textMiniGame[1] = "Hygene";
    }

    private void SetTextMiniGameMenu()
    {
        for (int i = 0; i < textMiniGame.Length; i++)
            textMiniGame[i].text = _textMiniGame[i];
    }

    private void SetButtonMiniGameMenu()
    {
        for (int i = 0; i < btnMiniGame.Length; i++)
        {
            switch (i)
            {
                case 0:
                    btnMiniGame[0] = GameObject.Find("BTN_Back");
                    btnMiniGame[0].GetComponent<Button>().onClick.AddListener(BackToMainMenu);
                    break;

                case 1:
                    btnMiniGame[1] = GameObject.Find("DeteksiColiform");
                    btnMiniGame[1].GetComponent<Button>().onClick.AddListener(PlayDeteksiColiformMenu);
                    break;

                case 2:
                    btnMiniGame[2] = GameObject.Find("Hygene");
                    btnMiniGame[2].GetComponent<Button>().onClick.AddListener(PlayHygine);
                    break;

                default:
                    Debug.LogWarning("Check ur Key");
                    break;
            }
        }
    }

    private void PlayDeteksiColiformMenu()
    {
        mainMenuisActive = false;
        miniGameMenuisActive = false;
        levelMenuisActive = true;

        CheckMenu();
    }

    private void PlayHygine()
    {
        menu[3].SetActive(true);
        StartCoroutine(LevelErorJeda(2));
    }

    private void BackToMainMenu()
    {
        mainMenuisActive = true;
        miniGameMenuisActive = false;
        levelMenuisActive = false;

        CheckMenu();
    }
    #endregion

    #region Deteksi Coliform Menu


    #endregion

    IEnumerator LevelErorJeda(int sec)
    {
        yield return new WaitForSeconds(sec);
        menu[3].SetActive(false);
    }
}
