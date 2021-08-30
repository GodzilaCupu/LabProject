using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    private string[] tutorialTexts,uiTexts;

    [SerializeField] private Text[] contentTXT, uiTXT;
    [SerializeField] private Button[] uiBTN;
    [SerializeField] private GameObject[] tutorial;

    int countTutorial = 0;

    BTN_Controller btn;
    // Start is called before the first frame update
    void Start()
    {
        GameObject _gameManager = GameObject.Find("GameManager");

        btn = _gameManager.GetComponent<BTN_Controller>();

        ValueText();
        SetText();
        ResetValue();
    }

    private void Update()
    {
        if (countTutorial <= 0)
        {
            tutorial[5].SetActive(false);
            tutorial[1].SetActive(true);
            uiBTN[1].interactable = false;

        }
        else if (countTutorial > 0 && countTutorial < 4)
        {
            uiBTN[0].interactable = true;
            uiBTN[1].interactable = true;
            tutorial[5].SetActive(false);
            tutorial[1].SetActive(true);

        }
        else if (countTutorial >= 4)
        {
            tutorial[1].SetActive(false);
            tutorial[5].SetActive(true);

        }

        if ( countTutorial == 2)
            tutorial[0].SetActive(true);
        else
            tutorial[0].SetActive(false);
    }

    private void ResetValue()
    {
        Save.SetCurrentLevel("Level", 1);
        Save.SetCurrentTutorial("Stage1", 0);
    }

    private void ValueText()
    {
        tutorialTexts = new string[5];
        tutorialTexts[0] = "Hi, Selamat datang !!! \nPada Mini Games ini Kamu akan melakukan experimnet bagaimana caranya \nmendeteksi Coilliform pada sebuah Sample. ";
        tutorialTexts[1] = "Untuk Langkah Pertama, Kamu harus mengambil bahan bahan \nyang di perlukan untuk melakukan Experiment";
        tutorialTexts[2] = "Kamu dapat mengetahui bahan dan alat melalui tombol tutorial ini";
        tutorialTexts[3] = "Setelah mengetahuinya, kamu cukup mengetuk bahan yang di perlukan \ntidak perlu mengambil semua bahan dan alat";
        tutorialTexts[4] = "Selamat melakukan Experiment Kawan :)";

        uiTexts = new string[3];
        uiTexts[0] = "Selanjutnya";
        uiTexts[1] = "Sebelumnya";
        uiTexts[2] = "Selesai";
    }

    private void SetText()
    {
        for(int i = 0; i < uiTXT.Length; i++)
            uiTXT[i].text = uiTexts[i];

        contentTXT[0].text = tutorialTexts[0];
    }

    public void NextTutorial()
    {
        countTutorial++;
        contentTXT[0].text = tutorialTexts[countTutorial];
    }

    public void PrevTutorial()
    {
        countTutorial--;
        contentTXT[0].text = tutorialTexts[countTutorial];
    }

    public void SelesaiTutorial()
    {
        tutorial[1].SetActive(false);
        tutorial[2].SetActive(false);
        tutorial[3].SetActive(false);
        tutorial[5].SetActive(false);

        tutorial[4].SetActive(true);
    }
}
