using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTN_Controller : MonoBehaviour
{
    [SerializeField] private Button taskBTN, settingBTN;
    [SerializeField] private GameObject panelTask, panelSetting;
    public Toggle toggleSound, toggleMusic;

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

    public void TaskGetOpen()
    {
        panelTask.SetActive(true);
        taskBTN.interactable = false;
        taskPanelIsActive = true;
        Debug.Log(taskPanelIsActive + "Task Pannel" );
    }

    public void TaskGetClosed()
    {
        taskPanelIsActive = false;
        panelTask.SetActive(false);
        taskBTN.interactable = true;
    }

    public void SettingGetOpen()
    {
        panelSetting.SetActive(true);
        settingBTN.interactable = false;
        settingPanelIsActive = true;
        Debug.Log(settingPanelIsActive + "Setting Pannel" );
    }

    public void SettingGetClosed()
    {
        settingPanelIsActive = false;
        panelSetting.SetActive(false);
        settingBTN.interactable = true;
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

}
