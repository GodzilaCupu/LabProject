using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BTN_Controller : MonoBehaviour
{
    [SerializeField] private Button taskBTN, settingBTN,kiriBTN,kananBTN;
    [SerializeField] private GameObject panelTask, panelSetting,popupSave, panelCongrats;
    [SerializeField] private Text popupSaveText;
    public Toggle toggleSound, toggleMusic;

    public Transform cameraTransform;

    private int countPos = 0;

    public bool isMute { get; private set; }

    [SerializeField] private AudioManager audioSetting;

    public bool taskPanelIsActive { get; private set; }
    public bool settingPanelIsActive { get; private set; }

    private void Start()
    {
        taskPanelIsActive = false;
        settingPanelIsActive = false;
        isMute = false;
    }


    private void Update()
    {
        CheckToCongrats();

        if (countPos <= 0)
            kiriBTN.interactable = false;
        else if (countPos < 3 && countPos > 0)
        {
            kiriBTN.interactable = true;
            kananBTN.interactable = true;
        }
        else if (countPos >= 3)
            kananBTN.interactable = false;
    }

    #region Panel Configuration
    public void TaskGetOpen()
    {
        panelTask.SetActive(true);
        taskBTN.interactable = false;
        taskPanelIsActive = true;

        kananBTN.interactable = false;
        kananBTN.interactable = false;
        settingBTN.interactable = false;
        Debug.Log(taskPanelIsActive + "Task Pannel");
    }

    public void TaskGetClosed()
    {
        taskPanelIsActive = false;
        panelTask.SetActive(false);
        taskBTN.interactable = true;

        kananBTN.interactable = true;
        kananBTN.interactable = true;
        settingBTN.interactable = true;

    }

    public void SettingGetOpen()
    {
        panelSetting.SetActive(true);
        settingBTN.interactable = false;
        settingPanelIsActive = true;

        kananBTN.interactable = false;
        kananBTN.interactable = false;
        taskBTN.interactable = false;
        Debug.Log(settingPanelIsActive + "Setting Pannel");
    }

    public void SettingGetClosed()
    {
        settingPanelIsActive = false;
        panelSetting.SetActive(false);
        settingBTN.interactable = true;

        kananBTN.interactable = true;
        kananBTN.interactable = true;
        taskBTN.interactable = true;

    }

    public void CongratsGetOpen()
    {
        panelCongrats.SetActive(true);
        settingBTN.interactable = false;
        settingPanelIsActive = false;

        kananBTN.interactable = false;
        kananBTN.interactable = false;
        taskBTN.interactable = false;

    }
    #endregion

    #region Setting BTN
    public void SaveLevel()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene == SceneManager.GetSceneByName("Gameplay_1"))
            Save.SetCurrentLevel("Level",1);

        if (scene == SceneManager.GetSceneByName("Gameplay_2"))
            Save.SetCurrentLevel("Level",2);

        if (scene == SceneManager.GetSceneByName("Gameplay_3"))
            Save.SetCurrentLevel("Level",3);

        if (scene == SceneManager.GetSceneByName("Gameplay_4"))
            Save.SetCurrentLevel("Level",4);

        StartCoroutine(PopupMassage("Tersimpan !!", 2));

    }
    public void SoundToggle()
    {
        if (toggleSound.isOn) 
        { 
            PlayerPrefs.SetInt("Sound", 1);
            audioSetting.PlaySound("Sound"); // jika ada asset sfx lainnya, di tuliskan lagi
            isMute = false;

            Debug.Log(isMute);
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
            audioSetting.MuteSound("Sound"); // jika ada asset sfx lainnya, di tuliskan lagi
            isMute = true;
           
            Debug.Log(isMute);

        }
    }
    #endregion

    #region UI BTN
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
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
        Save.SetCurrentLevel("Level", 3);
    }

    public void NextLevel()
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
            SceneManager.LoadScene("MainMenu");
        }

    }

    #endregion

    private void CheckToCongrats()
    {
        switch (Save.GetCurrentLevel("Level"))
        {
            case 1:
                if (Save.GetCurrentProgres("Stage3") == 4)
                    CongratsGetOpen();
                break;

            case 2:
                if (Save.GetCurrentProgres("Stage4") == 4)
                    CongratsGetOpen();
                break;

        }

    }
    IEnumerator PopupMassage(string massage, int delay)
    {
        popupSave.SetActive(true);
        popupSaveText.text = massage;
        yield return new WaitForSeconds(delay);
        popupSave.SetActive(false);


    }
}
