using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class TerminController : MonoBehaviour
{
    [Header("Background")]
    [SerializeField] private Image background;
    [SerializeField] private Sprite[] _background;

    [Header("Character")]
    [SerializeField] private Image character;
    [SerializeField] private Sprite[] _character;

    [Header("Button")]
    [SerializeField] private GameObject[] btnContainer;

    [Header("Text")]
    [SerializeField] private Text questionsText;
    [SerializeField] private Text popupSave;

    [Header("Panel")]
    // 0 : Panel Save ; 1 : panel Setting ; 2 = Panel Ask; 3 = panel title; 4 = panel 6;
    public GameObject[] panel;

    [Header("VO & Video")]
    [SerializeField] private VideoPlayer cucitangan;
    public AudioSource clipVO;
    public AudioClip[] _clipVO = new AudioClip[24];
    public VideoClip[] _cuciTangan = new VideoClip[6];

    public int countTermin5 = 0;
    public int countTermin6 = 0;
    public int countTermin7 = 0;

    ButtonAnswerManager btnAnswer;
    ButtonManager btn;
    TextManager txt;

    private void Awake()
    {
        GameObject _answerManager = GameObject.Find("BTN_GridSystem");
        btnAnswer = _answerManager.GetComponent<ButtonAnswerManager>();
        btn = this.gameObject.GetComponent<ButtonManager>();
        txt = this.gameObject.GetComponent<TextManager>();
    }

    private void Start()
    {
        CheckTermin();
        //SetTermin1();
    }

    private void Update()
    {
        CheckVO();
        Debug.Log(Save.GetCurrentLevel("Termin"));
        Debug.Log(Save.GetCurrentProgres("Termin1") + ": T1");
        Debug.Log(Save.GetCurrentProgres("Termin2") + ": T2");
        Debug.Log(Save.GetCurrentProgres("Termin3") + ": T3");
        Debug.Log(Save.GetCurrentProgres("Termin4") + ": T4");
        Debug.Log(Save.GetCurrentProgres("Termin5") + ": T5");
        Debug.Log(Save.GetCurrentProgres("Termin6") + ": T6");
        Debug.Log(Save.GetCurrentProgres("Termin7") + ": T7");
    }

    #region Setting Configuration
    public void OpenSetting()
    {
        panel[1].SetActive(true);
        btn.IsPlaying();
    }

    public void CloseSetting()
    {
        panel[1].SetActive(false);
        btn.IsStop();
    }

    public void OpenAsk()
    {
        panel[2].SetActive(true);
        btn.IsPlaying();
    }

    public void CloseAsk()
    {
        panel[2].SetActive(false);
        btn.IsStop();
    }

    #endregion

    #region Question and General Configuration
    public void SetTextQuestion(int value)
    {
        //Kalimat Pertanyaan
        string kata = txt._questionText[value];
        questionsText.text = kata;

        StartCoroutine(Typing(kata));
    }

    public void SetSprite(int value)
    {
        character.sprite = _character[value];
    }

    public void SetVO(int value)
    {
        clipVO.clip = _clipVO[value];
        clipVO.Play();
    }

    private void CheckVO()
    {
        if (clipVO.isPlaying)
            btn.IsPlaying();
        else if (!clipVO.isPlaying)
            btn.IsStop();
    }

    private void ResetButtonContainer()
    {
        btnContainer[0].SetActive(false);   
        btnContainer[1].SetActive(false);   
        btnContainer[2].SetActive(false);   
        btnContainer[3].SetActive(false);
    }

    private void ResetPanel()
    {
        panel[0].SetActive(false);
        panel[1].SetActive(false);
        panel[2].SetActive(false);
        panel[3].SetActive(true);
        panel[4].SetActive(false);
        panel[5].SetActive(false);
    }

    private void ResetData()
    {
        Save.SetCurrentProgres("Termin1", 0);
        Save.SetCurrentProgres("Termin2", 0);
        Save.SetCurrentProgres("Termin3", 0);
        Save.SetCurrentProgres("Termin4", 0);
        Save.SetCurrentProgres("Termin5", 0);
        Save.SetCurrentProgres("Termin6", 0);
        Save.SetCurrentProgres("Termin7", 0);
    }

    private void CheckTermin()
    {
        switch (Save.GetCurrentProgres("Termin"))
        {
            case 0:
                SetTermin1();
                break;

            case 1:
                SetTermin1();
                break;

            case 2:
                SetTermin2();
                break;

            case 3:
                SetTermin3();
                break;

            case 4:
                SetTermin4();
                break;

            case 5:
                SetTermin5();
                break;

            case 6:
                SetTermin6();
                break;

            case 7:
                SetTermin7();
                break;
        }
    }

    #endregion

    #region Termin Configuration

    public void SetTermin1()
    {
        Save.SetCurrentLevel("Termin", 1);
        ResetData();

        btn.GetValueButton(0).interactable = false;
        btn.GetValueButton(0).gameObject.SetActive(true);
        background.sprite = _background[0];
        ResetButtonContainer();
        btn.SetButtons();
        SetSprite(0);

        StartCoroutine(DelayTyping(2f, 0));
        StartCoroutine(DelayVO(2f, 0));
    }

    public void Termin1Progres()
    {
        switch (Save.GetCurrentProgres("Termin1"))
        {
            //Mencet 1
            case 0:
                Save.SetCurrentProgres("Termin1", Save.GetCurrentProgres("Termin1") + 1);
                SetVO(1);
                SetTextQuestion(1);
                SetSprite(4);
                break;

            //Mencet 2
            case 1:
                Save.SetCurrentProgres("Termin1", Save.GetCurrentProgres("Termin1") + 1);
                SetVO(2);
                SetTextQuestion(2);
                break;

            //Mencet 3
            case 2:
                SetTermin2();
                break;

            default:
                Debug.Log("Check Ur Key");
                break;
        }
    }

    public void SetTermin2()
    {
        Save.SetCurrentLevel("Termin", 2);
        ResetData();

        ResetButtonContainer();
        btnContainer[0].SetActive(true);
        background.sprite = _background[0];
        btn.GetValueButton(0).gameObject.SetActive(false);

        SetVO(3);
        SetSprite(3);
        SetTextQuestion(3);
    }

    public void Termin2Progres()
    {
        switch (Save.GetCurrentProgres("Termin2"))
        {
            //Mencet 1
            case 0:
                Save.SetCurrentProgres("Termin2", Save.GetCurrentProgres("Termin2") + 1);
                SetVO(4);
                SetTextQuestion(4);
                break;

            //Mencet 2
            case 1:
                Save.SetCurrentProgres("Termin2", Save.GetCurrentProgres("Termin2") + 1);
                SetVO(5);
                SetTextQuestion(5);
                break;

            //Mencet 3
            case 2:
                Save.SetCurrentProgres("Termin2", Save.GetCurrentProgres("Termin2") + 1);
                SetVO(6);
                SetTextQuestion(6);
                break;

            //Mencet 4
            case 3:
                SetTermin3();
                break;

            default:
                Debug.Log("Check Ur Key");
                break;
        }
    }

    public void Termin2Gagal()
    {
        StartCoroutine(PopupMassage(txt._notificationText[0],1));
        SetTermin1();
        Debug.Log("Gagal Termin 2");
    }

    public void SetTermin3()
    {
        Save.SetCurrentLevel("Termin", 3);
        ResetData();

        ResetButtonContainer();
        btnContainer[0].SetActive(true);
        background.sprite = _background[0];

        SetTextQuestion(7);
        SetSprite(2);
        SetVO(7);
    }

    public void Termin3Progres()
    {
        switch (Save.GetCurrentProgres("Termin3"))
        {
            //Mencet 1
            case 0:
                Save.SetCurrentProgres("Termin3", Save.GetCurrentProgres("Termin3") + 1);
                SetVO(8);
                SetSprite(3);
                SetTextQuestion(9);
                break;

            //Mencet 2
            case 1:
                SetTermin4();
                break;

            default:
                Debug.Log("Check Ur Key");
                break;
        }
    }

    public void Termin3Gagal()
    {
        SetVO(23);
        StartCoroutine(PopupMassage(txt._notificationText[0], 2));
        SetTermin2();
        Debug.Log("Back To Termin 2");
    }

    public void SetTermin4()
    {
        Save.SetCurrentLevel("Termin", 4);
        ResetData();

        ResetPanel();
        ResetButtonContainer();
        btnContainer[1].SetActive(true);
        background.sprite = _background[1];

        SetTextQuestion(10);
        SetSprite(3);
        SetVO(9);
    }

    public void Termin4Progres()
    {
        switch (Save.GetCurrentProgres("Termin4"))
        {
            //Mencet 1
            case 0:
                Save.SetCurrentProgres("Termin4", Save.GetCurrentProgres("Termin4") + 1);
                SetVO(9);
                SetSprite(3);
                SetTextQuestion(10);

                ResetButtonContainer();
                btnContainer[0].SetActive(true);
                break;

            //Mencet 2
            case 1:
                SetTermin5();
                break;

            default:
                Debug.Log("Check Ur Key");
                break;
        }
    }

    public void Termin4Gagal()
    {
        SetVO(23);
        StartCoroutine(PopupMassage(txt._notificationText[0], 2));

        SetTermin3();
        Debug.Log("Back To Termin 2");
    }

    public void SetTermin5()
    {
        Save.SetCurrentLevel("Termin", 5);
        ResetData();

        ResetButtonContainer();
        btnContainer[0].SetActive(true);
        background.sprite = _background[1];

        SetTextQuestion(11);
        SetSprite(1);
        SetVO(10);
    }

    public void Termin5Progres()
    {
        switch (Save.GetCurrentProgres("Termin5"))
        {
            //Mencet 1
            case 0:
                Save.SetCurrentProgres("Termin5", Save.GetCurrentProgres("Termin5") + 1);
                panel[3].SetActive(false); // title
                panel[4].SetActive(true);// panel Video 6
                SetVO(11);
                SetSprite(3);
                SetTextQuestion(12);

                ResetButtonContainer();
                btnContainer[2].SetActive(true);
                break;

            //Mencet 2
            case 1:
                switch (countTermin5)
                {
                    case 1:
                        cucitangan.clip = _cuciTangan[0];
                        cucitangan.Play();
                        SetVO(13);
                        break;

                    case 2:
                        cucitangan.clip = _cuciTangan[1];
                        cucitangan.Play();
                        SetVO(14);
                        break;

                    case 3:
                        cucitangan.clip = _cuciTangan[2];
                        cucitangan.Play();
                        SetVO(15);
                        break;

                    case 4:
                        cucitangan.clip = _cuciTangan[3];
                        cucitangan.Play();
                        SetVO(16);
                        break;

                    case 5:
                        cucitangan.clip = _cuciTangan[4];
                        cucitangan.Play();
                        SetVO(17);
                        break;

                    case 6:
                        cucitangan.clip = _cuciTangan[5];
                        cucitangan.Play();
                        SetVO(18);

                        StartCoroutine(DelayTermin(4,6));
                        break;
                }
                break;

            default:
                Debug.Log("Check Ur Key");
                break;
        }
    }

    public void Termin5Step(int value)
    {
        countTermin5 = value;
        Termin5Progres();
    }

    public void Termin5Gagal()
    {
        switch (Save.GetCurrentProgres("Termin5"))
        {
            case 0:
                SetVO(23);
                StartCoroutine(PopupMassage(txt._notificationText[0], 2));
                SetTermin4();
                break;

            case 1:
                SetVO(12);
                StartCoroutine(PopupMassage(txt._questionText[13], 2));
                break;
        }
    }

    public void SetTermin6()
    {
        Save.SetCurrentLevel("Termin", 6);
        ResetData();

        ResetButtonContainer();
        btn.SetButtons();
        background.sprite = _background[1];
        btn.GetValueButton(0).gameObject.SetActive(true);

        panel[3].SetActive(true); // title
        panel[4].SetActive(false);// panel Video 6

        SetTextQuestion(14);
        SetSprite(1);
        SetVO(19);
    }

    public void Termin6Progres()
    {
        switch (Save.GetCurrentProgres("Termin6"))
        {
            //Mencet 1
            case 0:
                Save.SetCurrentProgres("Termin6", Save.GetCurrentProgres("Termin6") + 1);
                btn.GetValueButton(0).gameObject.SetActive(false);
                btnContainer[3].SetActive(true);
                SetTextQuestion(15);
                SetSprite(4);
                SetVO(20);
                break;

            default:
                Debug.Log("Check Ur Key");
                break;
        }
    }

    public void Termin6Count(int value)
    {
        if(value >0 && value < 5)
        {
            countTermin6++;

        }
        else if (value == 0 || value == 5)
        {
            StartCoroutine(PopupMassage(txt._questionText[13], 2));
            SetVO(12);
        }
    }

    public void Termin6Disabble(int value)
    {
        btnAnswer.btn6[value].gameObject.SetActive(false);
    }

    public void SetTermin7()
    {
        Save.SetCurrentLevel("Termin", 7);
        ResetData();

        ResetButtonContainer();
        background.sprite = _background[2];
        btn.GetValueButton(0).gameObject.SetActive(true);

        SetTextQuestion(16);
        btn.SetButtons();
        SetSprite(4);
        SetVO(21);
    }

    public void Termin7Count(int value)
    {
        if (value == 0 )
        {
            StartCoroutine(PopupMassage(txt._questionText[18], 2));
        }
        else if (value > 0 || value <= 3)
        {
            countTermin7++;
            btnAnswer.btn4[value].GetComponent<Button>().interactable = false;
        }
    }

    public void Termin7Disabble(int value)
    {
        btnAnswer.btn4[value].gameObject.SetActive (false);
    }

    public void Termin7Progres()
    {
        switch (Save.GetCurrentProgres("Termin7"))
        {
            //Mencet 1
            case 0:
                Save.SetCurrentProgres("Termin7", Save.GetCurrentProgres("Termin7") + 1);
                btn.GetValueButton(0).gameObject.SetActive(false);
                btnContainer[4].SetActive(true);
                SetTextQuestion(17);
                SetSprite(4);
                SetVO(22);
                break;


            default:
                Debug.Log("Check Ur Key");
                break;
        }
    }

    public void Termin7Benar()
    {
        panel[5].SetActive(true);
    }
    #endregion

    #region IEnumerator configuration
    IEnumerator Typing(string Questions)
    {
        questionsText.text = "";
        foreach(char huruf in Questions.ToCharArray())
        {
            questionsText.text += huruf;
            yield return null;
        }
    }

    IEnumerator DelayTyping(float sec,int value)
    {
        questionsText.text = " ";
        yield return new WaitForSeconds(sec);
        SetTextQuestion(value);
    }

    IEnumerator DelayVO(float sec,int value)
    {
        yield return new WaitForSeconds(sec);
        SetVO(value);
    }

    public IEnumerator DelayTermin(float sec,int termin)
    {
        yield return new WaitForSeconds(sec);
        if (termin == 6)
            SetTermin6();
        else if (termin == 7)
            SetTermin7();
        else if(termin == 0)
        {
            SetVO(24);
            panel[5].SetActive(true);
        }
    }

    public IEnumerator PopupMassage(string massage, int delay)
    {
        panel[0].SetActive(true);
        popupSave.text = massage;
        yield return new WaitForSeconds(delay);
        panel[0].SetActive(false);
    }
    #endregion
}
