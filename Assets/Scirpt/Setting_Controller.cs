using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting_Controller : MonoBehaviour
{
    [SerializeField] private Text[] textSetting;
    private string[] setingText;

    private void Start()
    {
        ArrayText();
        SetText();
    }

    #region Text Configuration
    private void SetText()
    {
        for (int i = 0; i < textSetting.Length; i++)
        {
            textSetting[i].text = setingText[i];
        }
    }

    private void ArrayText()
    {
        setingText = new string[5];
        setingText[0] = "Pengaturan";
        setingText[1] = "Sound";
        setingText[2] = "Musik";
        setingText[3] = "Save";
        setingText[4] = "Tutup";
    }
    #endregion

    
}
