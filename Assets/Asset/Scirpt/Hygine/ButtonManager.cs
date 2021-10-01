using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button[] _buttonSetting;
    public Button[] _buttonAnswer;
    public Button[] _buttonUI;

    private void Start()
    {
        SetButtons();
    }

    private void SetButtons()
    {
        //Button Questions;
        for(int i = 0; i<= _buttonAnswer.Length; i++)
        {
            switch (i)
            {
                //Termin 2
                case 0:
                    //Ya
                    break;

                case 1:
                    //Tidak
                    break;

                //Termin 3
                case 2:
                    //Mandi
                    break;

                case 3:
                    //LangsungKerja
                    break;

                case 4:
                    //Dandan Secantik
                    break;

                case 5:
                    //Dandan Biasa aja
                    break;

                //Termin4
                case 6:

                    break;

            }
        }
    }
}
