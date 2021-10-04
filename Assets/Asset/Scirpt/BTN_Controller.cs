using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BTN_Controller : MonoBehaviour
{
    [Header("Button")]
    // 0 = taskBTN ; 1 = settingBTN ; 2 = GeseerCameraKiri ; 3 = GeserCameraKanan ; 4 = closeTaskBTN
    // 5 = ToggleSound ; 6 = ToggleMusic ; 7 = SavedBTN ; 8 = CloseSettingBTN ; 9 = BackToMainMenuBTN  
    // 10 = NextLevelBTN;
    [SerializeField] private GameObject[] uiBTN;

    [Header("Panel")]
    // 0 = PANEL_Task ; 1 = PANEL_Setting ; 2 = PANEL_PopUpSaved ; 3 = PANEL_Congrats ;
    [SerializeField] private GameObject[] uiPanel;
    [SerializeField] private Text popupSaveText;

    [Header("Setting Configuration")]
    // 0 = Pengaturan ( Title ); 1 = Sound ; 2 = Musik ; 3 = Save ; 4 = Tutup;
    [SerializeField] private Text[] settingTXT;
    private string[] _settingTXT;

    [Header("Movement Configuration")]
    public Transform cameraTransform;

    public bool isPanelON = false;

    public bool isMute { get; private set; }
    public bool taskPanelIsActive { get; private set; }
    public bool settingPanelIsActive { get; private set; }


    int countPos = 0;
    TutorialControlerStage1 tutor;
    StoryControllerStage1 stage1;
    AudioSource sound;

    private void Awake()
    {
        SetPanelUI();
        SetButtonUI();

        ValueTextSetting();
        SetTextSetting();
    }

    private void Start()
    {
        GameObject _gameManager = GameObject.Find("GameManager");
        tutor = _gameManager.GetComponent<TutorialControlerStage1>();
        stage1 = _gameManager.GetComponent<StoryControllerStage1>();
        sound = _gameManager.GetComponent<AudioSource>();

        taskPanelIsActive = false;
        settingPanelIsActive = false;
        isMute = false;
        ResetUI();
        SetSoundValue();

    }

    private void Update()
    {
        CheckToCongrats();
        CheckLevelandProgress();
        CheckPosition();
    }

    #region Panel Configuration
    public void TaskGetOpen()
    {
        uiPanel[0].SetActive(true);
        taskPanelIsActive = true;
        PanelUIActive();

        if (Save.GetCurrentLevel("Level") == 1)
        {
            tutor.AskPanelGetOpen();
            taskPanelIsActive = true;
            PanelUIActive();
            uiPanel[0].SetActive(false);
        }

        Debug.Log(taskPanelIsActive + "Task Pannel");
    }

    public void TaskGetClosed()
    {
        uiPanel[0].SetActive(false);
        taskPanelIsActive = false;
        PanelUINonActive();

        if (Save.GetCurrentLevel("Level") == 1)
        {
            tutor.AskPanelGetClose();
            taskPanelIsActive = false;
            PanelUINonActive();
        }
    }

    public void SettingGetOpen()
    {
        uiPanel[1].SetActive(true);
        settingPanelIsActive = true;
        PanelUIActive();
    }

    public void SettingGetClosed()
    {
        uiPanel[1].SetActive(false);
        settingPanelIsActive = false;
        PanelUINonActive();
    }

    public void CongratsGetOpen()
    {
        uiPanel[0].SetActive(false);
        uiPanel[1].SetActive(false);
        uiPanel[3].SetActive(true);
        settingPanelIsActive = false;
        PanelUIActive();
    }

    public void PanelUIActive()
    {
        isPanelON = true;
        uiBTN[0].GetComponent<Button>().interactable = false;
        uiBTN[1].GetComponent<Button>().interactable = false;
        uiBTN[2].GetComponent<Button>().interactable = false;
        uiBTN[3].GetComponent<Button>().interactable = false;
    }

    public void PanelUINonActive()
    {
        isPanelON = false;
        uiBTN[0].GetComponent<Button>().interactable = true;
        uiBTN[1].GetComponent<Button>().interactable = true;
        uiBTN[2].GetComponent<Button>().interactable = true;
        uiBTN[3].GetComponent<Button>().interactable = true;
    }
    #endregion

    #region Setting BTN
    public void SaveLevel()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene == SceneManager.GetSceneByName("Gameplay_1"))
            Save.SetCurrentLevel("Level", 1);
        if (scene == SceneManager.GetSceneByName("Gameplay_2"))
            Save.SetCurrentLevel("Level", 2);
        if (scene == SceneManager.GetSceneByName("Gameplay_3"))
            Save.SetCurrentLevel("Level", 3);
        if (scene == SceneManager.GetSceneByName("Gameplay_4"))
            Save.SetCurrentLevel("Level", 4);
        if (scene == SceneManager.GetSceneByName("Gameplay_5"))
            Save.SetCurrentLevel("Level", 5);

        Save.SetSound("BGM", Save.GetSound("BGM"));

        StartCoroutine(PopupMassage("Tersimpan !!", 1));

    }

    private void SetTextSetting()
    {
        for (int i = 0; i < settingTXT.Length; i++)
        {
            settingTXT[i].text = _settingTXT[i];
        }
    }

    private void ValueTextSetting()
    {
        _settingTXT = new string[2];
        _settingTXT[0] = "Pengaturan";
        _settingTXT[1] = "Sound";
    }

    //ditaro di method update
    private void SetSoundValue()
    {
        if (Save.GetSound("BGM") == 0)
        {
            uiBTN[5].GetComponent<Toggle>().isOn = false;
            sound.mute = false;
            isMute = false;
        }
        else if (Save.GetSound("BGM") == 1)
        {
            uiBTN[5].GetComponent<Toggle>().isOn = true;
            sound.mute = true;
            isMute = true;
        }
    }

    private void CheckSoundToggle(bool value)
    {
        if (value == false)
        {
            uiBTN[5].GetComponent<Toggle>().isOn = false;
            Save.SetSound("BGM", 0);
            sound.mute = false;
            isMute = false;
        }
        else if (value == true)
        {
            uiBTN[5].GetComponent<Toggle>().isOn = true;
            Save.SetSound("BGM", 1);
            sound.mute = true;
            isMute = true;
        }
    }

    #endregion

    #region Movement Configuration
    public void GeserKanan()
    {
        countPos++;
        cameraTransform.transform.Translate(Vector3.right , Camera.main.transform);
    }

    public void GeserKiri()
    {
        countPos--;
        cameraTransform.transform.Translate(Vector3.left, Camera.main.transform);
    }
    #endregion

    #region Congrats BTN
    private void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void NextLevel()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene == SceneManager.GetSceneByName("Gameplay_1"))
        {
            Save.DelateKey("Stage1");
            SceneManager.LoadScene("Gameplay_2");
        }

        if (scene == SceneManager.GetSceneByName("Gameplay_2"))
        {
            Save.DelateKey("Stage2");
            SceneManager.LoadScene("Gameplay_3");
        }

        if (scene == SceneManager.GetSceneByName("Gameplay_3"))
        {
            Save.DelateKey("Stage3");
            SceneManager.LoadScene("Gameplay_4");
        }

        if (scene == SceneManager.GetSceneByName("Gameplay_4"))
        {
            Save.DelateKey("Stage4");
            SceneManager.LoadScene("Gameplay_5");
        }

        if (scene == SceneManager.GetSceneByName("Gameplay_5"))
        {
            Save.DelateKey("Stage5");
            SceneManager.LoadScene("Quiz");
        }
    }

    #endregion

    #region General Configuration 

    private void CheckToCongrats()
    {
        switch (Save.GetCurrentLevel("Level"))
        {
            case 1:
                if (Save.GetCurrentProgres("Stage1") == 8)
                    stage1.CongratsGetOpenStage1();
                break;

            case 2:
                if (Save.GetCurrentProgres("Stage2") == 5)
                    CongratsGetOpen();
                break;
            case 3:
                if (Save.GetCurrentProgres("Stage3") == 4)
                    CongratsGetOpen();
                break;
            case 4:
                if (Save.GetCurrentProgres("Stage4") == 4)
                    CongratsGetOpen();
                break;
            case 5:
                if (Save.GetCurrentProgres("Stage5") == 5)
                    CongratsGetOpen();
                break;
            default:
                Debug.LogWarning("Check Ur Key");
                break;
        }
    }

    private void CheckLevelandProgress()
    {
        switch (Save.GetCurrentLevel("Level"))
        {
            case 1:
                Debug.Log(Save.GetCurrentProgres("Stage1"));
                break;

            case 2:
                Debug.Log(Save.GetCurrentProgres("Stage2"));
                break;
            case 3:
                Debug.Log(Save.GetCurrentProgres("Stage3"));
                break;
            case 4:
                Debug.Log(Save.GetCurrentProgres("Stage4"));
                break;
            case 5:
                Debug.Log(Save.GetCurrentProgres("Stage5"));
                break;
            default:
                Debug.LogWarning("Check Ur Key");
                break;
        }
    }

    private void CheckPosition()
    {
        if(Save.GetCurrentLevel("Level") > 1)
        {
            if (countPos <= 0)
                uiBTN[2].GetComponent<Button>().interactable = false;
            else if (countPos < 2 && countPos > 0 && isPanelON == false)
            {
                uiBTN[2].GetComponent<Button>().interactable = true;
                uiBTN[3].GetComponent<Button>().interactable = true;
            }
            else if (countPos == 2)
                uiBTN[3].GetComponent<Button>().interactable = false;
        } else if (Save.GetCurrentLevel("Level") == 1)
        {
            uiBTN[2].SetActive(false);
            uiBTN[3].SetActive(false);
            uiBTN[0].SetActive(false);
        }
    }

    private void SetButtonUI()
    {
        for (int i = 0; i < uiBTN.Length; i++)
        {
            switch (i)
            {
                #region Gameplay BTN
                // 0 = taskBTN ; 1 = settingBTN ; 2 = GeseerCameraKiri ; 3 = GeserCameraKanan
                case 0:
                    uiBTN[0].GetComponent<Button>().onClick.AddListener(TaskGetOpen);
                    break;
                case 1:
                    uiBTN[1] = GameObject.Find("BTN_Setting");
                    uiBTN[1].GetComponent<Button>().onClick.AddListener(SettingGetOpen);
                    break;

                case 2:
                    uiBTN[2] = GameObject.Find("BTN_GeserKiri");
                    uiBTN[2].GetComponent<Button>().onClick.AddListener(GeserKiri); 
                    break;

                case 3:
                    uiBTN[3] = GameObject.Find("BTN_GeserKanan");
                    uiBTN[3].GetComponent<Button>().onClick.AddListener(GeserKanan);
                    break;
                #endregion

                #region Panel Task BTN
                // 4 = closeTaskBTN
                case 4:
                    uiBTN[4] = GameObject.Find("BTN_Close");
                    uiBTN[4].GetComponent<Button>().onClick.AddListener(TaskGetClosed);
                    break;
                #endregion

                #region Panel Setting BTN
                // 5 = ToggleSound  ; 6 = ToggleMusic ; 7 = SavedBTN ; 8 = CloseSettingBTN;
                case 5:
                    uiBTN[5] = GameObject.Find("Sound_Toggle");
                    uiBTN[5].GetComponent<Toggle>().onValueChanged.AddListener(CheckSoundToggle);
                    break;

                case 6:
                    uiBTN[6] = GameObject.Find("BTN_BacktoMainMenu");
                    uiBTN[6].GetComponent<Button>().onClick.AddListener(BackToMainMenu);
                    break;

                case 7:
                    uiBTN[7] = GameObject.Find("BTN_Save");
                    uiBTN[7].GetComponent<Button>().onClick.AddListener(SaveLevel);
                    break;

                case 8:
                    uiBTN[8] = GameObject.Find("BTN_CloseSetting");
                    uiBTN[8].GetComponent<Button>().onClick.AddListener(SettingGetClosed);
                    break;
                #endregion

                #region Panel Congrats BTN
                // 9 = BackToMainMenuBTN; 10 = NextLevelBTN;
                case 9:
                    uiBTN[9] = GameObject.Find("BTN_BackToMainMenu");
                    uiBTN[9].GetComponent<Button>().onClick.AddListener(BackToMainMenu);
                    break;

                case 10:
                    uiBTN[10] = GameObject.Find("BTN_NextLevel");
                    uiBTN[10].GetComponent<Button>().onClick.AddListener(NextLevel);
                    break;
                #endregion

                default:
                    Debug.LogWarning("Check Ur Key");
                    break;
            }
        }
    }

    private void SetPanelUI()
    {
        for(int i = 0; i<uiPanel.Length; i++)
        {
            switch (i)
            {
                case 0:
                    uiPanel[0] = GameObject.Find("PANEL_Task");
                    break;

                case 1:
                    uiPanel[1] = GameObject.Find("PANEL_Setting");
                    break;

                case 2:
                    uiPanel[2] = GameObject.Find("PANEL_PopUpSaved");
                    break;

                case 3:
                    uiPanel[3] = GameObject.Find("PANEL_Congrats");
                    break;

                default:
                    Debug.LogWarning("Check ur Key");
                    break;

            }
        }
    }

    private void ResetUI()
    {
        uiPanel[0].SetActive(false);
        uiPanel[1].SetActive(false);
        uiPanel[2].SetActive(false);
        uiPanel[3].SetActive(false);
        isPanelON = false;
    }

    #endregion
    IEnumerator PopupMassage(string massage, int delay)
    {
        uiPanel[2].SetActive(true);
        popupSaveText.text = massage;
        yield return new WaitForSeconds(delay);
        uiPanel[2].SetActive(false);
    }
}
