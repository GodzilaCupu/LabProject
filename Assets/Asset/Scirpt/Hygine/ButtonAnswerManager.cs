using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnswerManager : MonoBehaviour
{
    [Header("2 Button")]
    public GameObject[] btn2 = new GameObject[2];
    public GameObject[] txt2 = new GameObject[2];

    [Header("3 Button")]
    public GameObject[] btn3 = new GameObject[3];
    public GameObject[] txt3 = new GameObject[3];

    [Header("4 Button")]
    public GameObject[] btn4 = new GameObject[4];
    public GameObject[] txt4 = new GameObject[4];

    [Header("Termin 5")]
    public GameObject[] btn5 = new GameObject[6];
    public GameObject[] txt5 = new GameObject[6];

    [Header("Termin 6")]
    public GameObject[] btn6 = new GameObject[6];

    TerminController controller;
    TextManager txtData;

    private void Start()
    {
        GameObject _gameManager = GameObject.Find("GameManager");
        controller = _gameManager.GetComponent<TerminController>();
        txtData = _gameManager.GetComponent<TextManager>();
        Set6();
        Set7();
    }

    private void Update()
    {
        SetConfig();
    }

    public void SetConfig()
    {
        switch (Save.GetCurrentLevel("Termin"))
        {
            case 2:
                btn2[0].GetComponent<Button>().onClick.RemoveAllListeners();
                btn2[1].GetComponent<Button>().onClick.RemoveAllListeners();

                btn2[0].GetComponent<Button>().onClick.AddListener(controller.Termin2Gagal);
                txt2[0].GetComponent<Text>().text = txtData._answerText[0];

                btn2[1].GetComponent<Button>().onClick.AddListener(controller.Termin2Progres);
                txt2[1].GetComponent<Text>().text = txtData._answerText[1];
                break;

            case 3:
                btn2[0].GetComponent<Button>().onClick.RemoveAllListeners();
                btn2[1].GetComponent<Button>().onClick.RemoveAllListeners();
                //Pilihan Pertmaa
                if (Save.GetCurrentProgres("Termin3") == 0)
                {
                    btn2[0].GetComponent<Button>().onClick.AddListener(controller.Termin3Progres);
                    txt2[0].GetComponent<Text>().text = txtData._answerText[2];

                    btn2[1].GetComponent<Button>().onClick.AddListener(controller.Termin3Gagal);
                    txt2[1].GetComponent<Text>().text = txtData._answerText[3];
                }
                //Pilihan 2
                else if (Save.GetCurrentProgres("Termin3") == 1)
                {
                    btn2[0].GetComponent<Button>().onClick.AddListener(controller.Termin3Gagal);
                    txt2[0].GetComponent<Text>().text = txtData._answerText[4];

                    btn2[1].GetComponent<Button>().onClick.AddListener(controller.Termin3Progres);
                    txt2[1].GetComponent<Text>().text = txtData._answerText[5];
                }
                break;

            case 4:
                //pilihan Pertama
                if (Save.GetCurrentProgres("Termin4") == 0)
                {
                    btn3[0].GetComponent<Button>().onClick.RemoveAllListeners();
                    btn3[1].GetComponent<Button>().onClick.RemoveAllListeners();
                    btn3[2].GetComponent<Button>().onClick.RemoveAllListeners();

                    btn3[0].GetComponent<Button>().onClick.AddListener(controller.Termin4Gagal);
                    txt3[0].GetComponent<Text>().text = txtData._answerText[6];

                    btn3[1].GetComponent<Button>().onClick.AddListener(controller.Termin4Progres);
                    txt3[1].GetComponent<Text>().text = txtData._answerText[7];

                    btn3[2].GetComponent<Button>().onClick.AddListener(controller.Termin4Progres);
                    txt3[2].GetComponent<Text>().text = txtData._answerText[8];
                }
                //Pilihan 2
                else if (Save.GetCurrentProgres("Termin4") == 1)
                {
                    btn2[0].GetComponent<Button>().onClick.RemoveAllListeners();
                    btn2[1].GetComponent<Button>().onClick.RemoveAllListeners();

                    btn2[0].GetComponent<Button>().onClick.AddListener(controller.Termin4Progres);
                    txt2[0].GetComponent<Text>().text = txtData._answerText[9];

                    btn2[1].GetComponent<Button>().onClick.AddListener(controller.Termin4Gagal);
                    txt2[1].GetComponent<Text>().text = txtData._answerText[6];
                }
                break;

            case 5:
                //pilihan pertama
                if(Save.GetCurrentProgres("Termin5") == 0)
                {
                    btn2[0].GetComponent<Button>().onClick.RemoveAllListeners();
                    btn2[1].GetComponent<Button>().onClick.RemoveAllListeners();

                    btn2[0].GetComponent<Button>().onClick.AddListener(controller.Termin5Progres);
                    txt2[0].GetComponent<Text>().text = txtData._answerText[11];

                    btn2[1].GetComponent<Button>().onClick.AddListener(controller.Termin5Gagal);
                    txt2[1].GetComponent<Text>().text = txtData._answerText[10];
                }
                else if (Save.GetCurrentProgres("Termin5") == 1)
                {
                    txt5[0].GetComponent<Text>().text = txtData._answerText[14];
                    txt5[1].GetComponent<Text>().text = txtData._answerText[12];
                    txt5[2].GetComponent<Text>().text = txtData._answerText[16];
                    txt5[3].GetComponent<Text>().text = txtData._answerText[15];
                    txt5[4].GetComponent<Text>().text = txtData._answerText[17];
                    txt5[5].GetComponent<Text>().text = txtData._answerText[13];

                    switch (controller.countTermin5)
                    {
                        case 0:
                            btn5[0].GetComponent<Button>().onClick.AddListener(controller.Termin5Gagal);
                            btn5[1].GetComponent<Button>().onClick.AddListener(delegate  { controller.Termin5Step(1); });
                            btn5[2].GetComponent<Button>().onClick.AddListener(controller.Termin5Gagal);
                            btn5[3].GetComponent<Button>().onClick.AddListener(controller.Termin5Gagal);
                            btn5[4].GetComponent<Button>().onClick.AddListener(controller.Termin5Gagal);
                            btn5[5].GetComponent<Button>().onClick.AddListener(controller.Termin5Gagal);
                            break;

                        case 1:
                            btn5[1].GetComponent<Button>().interactable = false;
                            btn5[5].GetComponent<Button>().onClick.RemoveAllListeners();
                            btn5[0].GetComponent<Button>().onClick.AddListener(controller.Termin5Gagal);
                            btn5[2].GetComponent<Button>().onClick.AddListener(controller.Termin5Gagal);
                            btn5[3].GetComponent<Button>().onClick.AddListener(controller.Termin5Gagal);
                            btn5[4].GetComponent<Button>().onClick.AddListener(controller.Termin5Gagal);
                            btn5[5].GetComponent<Button>().onClick.AddListener(delegate {controller.Termin5Step(2);});
                            break;

                        case 2:
                            btn5[1].GetComponent<Button>().interactable = false;
                            btn5[5].GetComponent<Button>().interactable = false;
                            btn5[0].GetComponent<Button>().onClick.RemoveAllListeners();
                            btn5[0].GetComponent<Button>().onClick.AddListener(delegate {controller.Termin5Step(3);});
                            btn5[2].GetComponent<Button>().onClick.AddListener(controller.Termin5Gagal);
                            btn5[3].GetComponent<Button>().onClick.AddListener(controller.Termin5Gagal);
                            btn5[4].GetComponent<Button>().onClick.AddListener(controller.Termin5Gagal);
                            break;

                        case 3:
                            btn5[0].GetComponent<Button>().interactable = false; 
                            btn5[1].GetComponent<Button>().interactable = false;
                            btn5[5].GetComponent<Button>().interactable = false;
                            btn5[3].GetComponent<Button>().onClick.RemoveAllListeners();
                            btn5[2].GetComponent<Button>().onClick.AddListener(controller.Termin5Gagal);
                            btn5[3].GetComponent<Button>().onClick.AddListener(delegate {controller.Termin5Step(4);});
                            btn5[4].GetComponent<Button>().onClick.AddListener(controller.Termin5Gagal);
                            break;

                        case 4:
                            btn5[3].GetComponent<Button>().interactable = false; 
                            btn5[0].GetComponent<Button>().interactable = false;
                            btn5[1].GetComponent<Button>().interactable = false;
                            btn5[5].GetComponent<Button>().interactable = false;
                            btn5[2].GetComponent<Button>().onClick.RemoveAllListeners();
                            btn5[2].GetComponent<Button>().onClick.AddListener(delegate {controller.Termin5Step(5);});
                            btn5[4].GetComponent<Button>().onClick.AddListener(controller.Termin5Gagal);
                            break;

                        case 5:
                            btn5[2].GetComponent<Button>().interactable = false; 
                            btn5[3].GetComponent<Button>().interactable = false;
                            btn5[0].GetComponent<Button>().interactable = false;
                            btn5[1].GetComponent<Button>().interactable = false;
                            btn5[5].GetComponent<Button>().interactable = false;
                            btn5[4].GetComponent<Button>().onClick.RemoveAllListeners();
                            btn5[4].GetComponent<Button>().onClick.AddListener(delegate {controller.Termin5Step(6);});
                            break;

                        case 6:
                            btn5[2].GetComponent<Button>().interactable = false;
                            btn5[3].GetComponent<Button>().interactable = false;
                            btn5[0].GetComponent<Button>().interactable = false;
                            btn5[1].GetComponent<Button>().interactable = false;
                            btn5[5].GetComponent<Button>().interactable = false; 
                            btn5[4].GetComponent<Button>().interactable = false;
                            break;

                        default:
                            Debug.Log("Salah");
                            break;
                    }
                }
                break;

            case 6:

                btn6[1].GetComponent<Button>().onClick.AddListener(delegate { controller.Termin6Disabble(1); });
                btn6[2].GetComponent<Button>().onClick.AddListener(delegate { controller.Termin6Disabble(2); });
                btn6[3].GetComponent<Button>().onClick.AddListener(delegate { controller.Termin6Disabble(3); });
                btn6[4].GetComponent<Button>().onClick.AddListener(delegate { controller.Termin6Disabble(4); });
                if (controller.countTermin6 == 4)
                {
                    controller.countTermin6 = 0;
                    controller.countTermin7 = 0;
                    StartCoroutine(controller.DelayTermin(2,7));
                }
                break;

            case 7:
                btn4[1].GetComponent<Button>().onClick.AddListener(delegate { controller.Termin7Disabble(1); });
                btn4[2].GetComponent<Button>().onClick.AddListener(delegate { controller.Termin7Disabble(2); });
                btn4[3].GetComponent<Button>().onClick.AddListener(delegate { controller.Termin7Disabble(3); });

                if (controller.countTermin7 == 3)
                {
                    controller.countTermin7 = 0;
                    StartCoroutine(controller.DelayTermin(3, 0));
                }
                break;

        }
    }

    private void Set6()
    {
        btn6[0].GetComponent<Button>().onClick.AddListener(delegate { controller.Termin6Count(0); });
        btn6[1].GetComponent<Button>().onClick.AddListener(delegate { controller.Termin6Count(1); });
        btn6[2].GetComponent<Button>().onClick.AddListener(delegate { controller.Termin6Count(2); });
        btn6[3].GetComponent<Button>().onClick.AddListener(delegate { controller.Termin6Count(3); });
        btn6[4].GetComponent<Button>().onClick.AddListener(delegate { controller.Termin6Count(4); });
        btn6[5].GetComponent<Button>().onClick.AddListener(delegate { controller.Termin6Count(5); });
    }

    private void Set7()
    {
        btn4[0].GetComponent<Button>().onClick.AddListener(delegate { controller.Termin7Count(0); });
        btn4[1].GetComponent<Button>().onClick.AddListener(delegate { controller.Termin7Count(1); });
        btn4[2].GetComponent<Button>().onClick.AddListener(delegate { controller.Termin7Count(2); });
        btn4[3].GetComponent<Button>().onClick.AddListener(delegate { controller.Termin7Count(3); });

        txt4[0].GetComponent<Text>().text = txtData._answerText[21];
        txt4[1].GetComponent<Text>().text = txtData._answerText[19];
        txt4[2].GetComponent<Text>().text = txtData._answerText[20];
        txt4[3].GetComponent<Text>().text = txtData._answerText[18];
    }

    private void TestBisa()
    {
        Debug.Log("Bisa");
    }
    private void TidakBisa()
    {
        Debug.Log("Tidak");
    }
}
