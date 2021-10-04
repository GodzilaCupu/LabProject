using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource bgm;

    [Header("Button & Tooggle")]
    [SerializeField] private Button[] btnUI;
    [SerializeField] private Toggle soundToggle;

    [Header("Text")]
    [SerializeField] private Text[] txtUI;

    [SerializeField] private ButtonAnswerManager btnAnswer;
    TerminController controller;
    TextManager txt;
    private void Awake()
    {
        controller = this.gameObject.GetComponent<TerminController>();
        txt = this.gameObject.GetComponent<TextManager>();
        SetSoundValue();
        SetText();
        SetButtons();

    }

    #region General Function
    public void IsPlaying()
    {
        //BtnUI
        btnUI[0].interactable = false;
        btnUI[1].interactable = false;
        btnUI[2].interactable = false;
        btnUI[3].interactable = false;
        btnUI[4].interactable = false;
        btnUI[5].interactable = false;
        btnUI[6].interactable = false;

        for (int i = 0; i <= 1; i++)
            btnAnswer.btn2[i].GetComponent<Button>().interactable = false;

        for (int i = 0; i <= 3; i++)
            btnAnswer.btn4[i].GetComponent<Button>().interactable = false;

        for (int i = 0; i <= 2; i++)
            btnAnswer.btn3[i].GetComponent<Button>().interactable = false;

        for (int i = 0; i <= 5; i++)
        {
            btnAnswer.btn5[i].GetComponent<Button>().interactable = false;
            btnAnswer.btn6[i].GetComponent<Button>().interactable = false;
        }
    
    }

    public void IsStop()
    {
        btnUI[0].interactable = true;
        btnUI[1].interactable = true;
        btnUI[2].interactable = true;
        btnUI[3].interactable = true;
        btnUI[4].interactable = true;
        btnUI[5].interactable = true;
        btnUI[6].interactable = true;

        for (int i = 0; i <= 1; i++)
            btnAnswer.btn2[i].GetComponent<Button>().interactable = true;

        for (int i = 0; i <= 3; i++)
            btnAnswer.btn4[i].GetComponent<Button>().interactable = true;

        for (int i = 0; i <= 2; i++)
            btnAnswer.btn3[i].GetComponent<Button>().interactable = false;

        for (int i = 0; i <= 5; i++)
        {
            btnAnswer.btn5[i].GetComponent<Button>().interactable = true;
            btnAnswer.btn6[i].GetComponent<Button>().interactable = true;
        }
    }
    #endregion

    #region Setting Function
    private void SaveLevel()
    {
        int _termin = Save.GetCurrentLevel("Termin");
        Save.SetCurrentLevel("Termin", _termin);
        Save.SetSound("BGM", Save.GetSound("BGM"));
        StartCoroutine(controller.PopupMassage("Tersimpan !!", 1));
    }

    private void SetSoundValue()
    {
        if (Save.GetSound("BGM") == 0)
        {
            soundToggle.GetComponent<Toggle>().isOn = false;
            bgm.mute = false;

        }
        else if (Save.GetSound("BGM") == 1)
        {
            soundToggle.GetComponent<Toggle>().isOn = true;
            bgm.mute = true;

        }
    }

    private void CheckSoundToggle(bool value)
    {
        Debug.Log("BGM1 " + Save.GetSound("BGM"));
        if (value == false)
        {
            soundToggle.GetComponent<Toggle>().isOn = false;
            Save.SetSound("BGM", 0);
            bgm.mute = false;
        }
        else if (value == true)
        {
            soundToggle.GetComponent<Toggle>().isOn = true;
            Save.SetSound("BGM",1);
            bgm.mute = true;
        }
    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    #endregion

    public void SetButtons()
    {
        soundToggle.onValueChanged.AddListener(CheckSoundToggle);
        for (int i = 0; i <= btnUI.Length; i++)
        {
            switch (i)
            {
                case 0:
                    if (Save.GetCurrentLevel("Termin") == 1)
                        btnUI[0].onClick.AddListener(controller.Termin1Progres);
                    else if (Save.GetCurrentLevel("Termin") == 6)
                    {
                        btnUI[0].onClick.RemoveAllListeners();
                        btnUI[0].onClick.AddListener(controller.Termin6Progres);
                    }
                    else if (Save.GetCurrentLevel("Termin") == 7)
                    {
                        btnUI[0].onClick.RemoveAllListeners();
                        btnUI[0].onClick.AddListener(controller.Termin7Progres);
                    }
                    break;

                //UI
                case 1:
                    btnUI[1].onClick.AddListener(controller.OpenSetting);
                    break;

                case 2:
                    btnUI[2].onClick.AddListener(controller.OpenAsk);
                    break;

                case 3:
                    btnUI[3].onClick.AddListener(controller.CloseSetting);
                    break;

                case 4:
                    btnUI[4].onClick.AddListener(controller.CloseAsk);
                    break;

                //BTN Settings
                case 5:
                    btnUI[5].onClick.AddListener(SaveLevel);
                    break;

                case 6:
                    btnUI[6].onClick.AddListener(BackToMainMenu);
                    break;

                case 7:
                    btnUI[7].onClick.AddListener(BackToMainMenu);
                    break;

                default:
                    Debug.Log("Check ur Key");
                    break;
            }
        }
    }

    private void SetText()
    {
        txtUI[0].text = "Pengaturan";
        txtUI[1].text = "Suara";
        txtUI[2].text = "Sanitasi dan Personal Hygiene ";
        txtUI[3].text = txt._questionText[0] + txt._questionText[1] + txt._questionText[2];
    }

    public Button GetValueButton(int value)
    {
        return btnUI[value];
    }

}
