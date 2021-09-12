using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    private string[] tutorialTexts,uiTexts;

    [SerializeField] private Text[] uiTXT;
    [SerializeField] private GameObject[] tutorial;
    [SerializeField] private VideoPlayer tutorialVideo;
    [SerializeField] private Animator panahAnim;

    public int countTutorial { get; private set;}
    bool isAskOpen = false;

    BTN_Controller btn;

    private void Awake()
    {
        ValueText();
        SetText();
        SetButton();
    }

    // Start is called before the first frame update
    void Start()
    {
        btn = gameObject.GetComponent<BTN_Controller>();

        ResetPanel();
        ResetValue();
    }

    private void Update()
    {
        CheckValue();
        PlayAnimPanah();
        Debug.Log(countTutorial + "count ");
    }

    #region Value Controller
    private void ResetValue()
    {
        Save.SetCurrentLevel("Level", 1);
        Save.SetCurrentTutorial("Stage1", 0);
        countTutorial = 0;
    }

    private void CheckValue()
    {
        if (countTutorial <= 0)
        {

            tutorial[1].GetComponent<Button>().interactable = false;
            tutorial[5].GetComponent<Button>().interactable = false;

            tutorial[1].SetActive(true);
            tutorial[2].SetActive(true);

            tutorial[3].SetActive(false);
            tutorial[7].SetActive(false);
            btn.PanelUIActive();
        }
        else if (countTutorial > 0 && countTutorial < 4)
        {
            tutorial[1].GetComponent<Button>().interactable = true;
            tutorial[2].GetComponent<Button>().interactable = true;
            btn.PanelUIActive();
        }
        else if (countTutorial == 4)
        {
            tutorial[2].SetActive(false);   
            tutorial[3].SetActive(true);
            btn.PanelUIActive();
        }
        else if (countTutorial > 4)
        {
            tutorial[1].SetActive(false);
            tutorial[2].SetActive(false);
            tutorial[3].SetActive(false);

            tutorial[5].GetComponent<Button>().interactable = true;
            tutorial[7].SetActive(true);
            btn.PanelUINonActive();
        }
    }

    private void PlayAnimPanah()
    {
        if (countTutorial == 2)
        {
            tutorial[0].SetActive(true);
            panahAnim.SetBool("Play", true);
        }
        else if ( countTutorial < 2 || countTutorial > 2)
        {
            tutorial[0].SetActive(false);
            panahAnim.SetBool("Play", false);
        }
    }

    private void ValueText()
    {
        tutorialTexts = new string[5];
        tutorialTexts[0] = "Hi, Selamat datang !!! \nPada Mini Games ini Kamu akan melakukan eksperimen \nbagaimana caranya mendeteksi Coliform pada sebuah Sample.";
        tutorialTexts[1] = "Untuk Langkah Pertama, Kamu harus mengambil \nbahan bahan yang di perlukan untuk melakukan eksperimen";
        tutorialTexts[2] = "Kamu dapat mengetahui bahan dan alat melalui tombol(?) tutorial ini";
        tutorialTexts[3] = "Setelah mengetahuinya, kamu cukup memilih bahan \nyang di perlukan tidak perlu mengambil semua bahan dan alat";
        tutorialTexts[4] = "Selamat melakukan eksperimen Kawan :)";

        uiTexts = new string[3];
        uiTexts[0] = "Selanjutnya";
        uiTexts[1] = "Sebelumnya";
        uiTexts[2] = "Selesai";
    }

    private void SetText()
    {
        for(int i = 0; i < uiTexts.Length; i++)
            uiTXT[i].text = uiTexts[i];

        tutorial[4].GetComponent<Text>().text = tutorialTexts[0];
    }

    public void SelesaiTutorial()
    {
        countTutorial++;
        tutorial[1].SetActive(false);
        tutorial[2].SetActive(false);
        tutorial[3].SetActive(false);
        tutorial[4].SetActive(false);

        tutorial[7].SetActive(true);
    }
    #endregion

    #region BTN Controller

    private void SetButton()
    {
        for(int i = 0; i <= 7; i++)
        {
            switch (i)
            {
                case 0:
                    tutorial[2] = GameObject.Find("BTN_Next");
                    tutorial[2].GetComponent<Button>().onClick.AddListener(NextTutorial);
                    break;

                case 1:
                    tutorial[1] = GameObject.Find("BTN_Prev");
                    tutorial[1].GetComponent<Button>().onClick.AddListener(PrevTutorial);
                    break;

                case 2:
                    tutorial[3] = GameObject.Find("BTN_Selesai");
                    tutorial[3].GetComponent<Button>().onClick.AddListener(SelesaiTutorial);
                    break;

                case 3:
                    tutorial[5] = GameObject.Find("BTN_Ask");
                    break;

                case 4:
                    tutorial[6] = GameObject.Find("BTN_CloseAskPanel");
                    break;

                case 5:
                    tutorial[8] = GameObject.Find("BTN_Play");
                    tutorial[8].GetComponent<Button>().onClick.AddListener(PlayVideo);
                    break;

                case 6:
                    tutorial[9] = GameObject.Find("BTN_Pause");
                    tutorial[9].GetComponent<Button>().onClick.AddListener(PauseVideo);
                    break;

                case 7:
                    tutorial[10] = GameObject.Find("BTN_Rewind");
                    tutorial[10].GetComponent<Button>().onClick.AddListener(RewindVideo);
                    break;
            }
        }
    }

    private void NextTutorial()
    {
        countTutorial++;
        tutorial[4].GetComponent<Text>().text = tutorialTexts[countTutorial];
    }

    private void PrevTutorial()
    {
        countTutorial--;
        tutorial[4].GetComponent<Text>().text = tutorialTexts[countTutorial];
    }

    public void AskPanelGetOpen()
    {
        tutorial[8].GetComponent<Button>().interactable = true;
        tutorial[9].GetComponent<Button>().interactable = true;
        tutorial[10].GetComponent<Button>().interactable = true;
        tutorial[11].SetActive(true);
    }

    public void AskPanelGetClose()
    {
        isAskOpen = false;
        tutorialVideo.Stop();
        tutorial[11].SetActive(false);
    }

    private void PlayVideo()
    {
        tutorialVideo.Play();
        tutorial[8].GetComponent<Button>().interactable = false;
        tutorial[9].GetComponent<Button>().interactable = true;
    }

    private void PauseVideo()
    {
        tutorialVideo.Pause();
        tutorial[8].GetComponent<Button>().interactable = true;
        tutorial[9].GetComponent<Button>().interactable = false;
    }

    private void RewindVideo()
    {
        tutorial[8].GetComponent<Button>().interactable = true;
        tutorial[9].GetComponent<Button>().interactable = true;

        tutorialVideo.Stop();
        tutorialVideo.Play();
    }

    private void ResetPanel()
    {
        tutorial[11].SetActive(false);
        tutorial[3].SetActive(false);
    }
    #endregion
}
