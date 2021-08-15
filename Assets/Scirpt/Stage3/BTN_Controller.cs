using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTN_Controller : MonoBehaviour
{
    [SerializeField] private Button taskBTN, settingBTN,kiriBTN,kananBTN;
    [SerializeField] private GameObject panelTask, panelSetting;
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
    #endregion


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

}
