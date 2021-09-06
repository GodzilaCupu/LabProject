using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizController : MonoBehaviour
{
    [Header("Soal dan Jawaban")]
    // 0 = Soal ; 1 = Pilihan A ; 2 = Pilihan B ; 3 = Pilihan C ; 4 = Pilihan D ; 5 = Pilihan E ; 6 = Content ; 7 = Btn Selanjutnya ;
    [SerializeField] private Text[] quizTXT;
    [SerializeField] private GameObject[] quizBTN;
    private string[] _kunciJawabanTexts, _soalTexts, _contentText;
    private int countQuiz;

    private void Awake()
    {
        SetButton();
        ValueQuizText();
    }

    private void Start()
    {
        ResetPertanyaan();
        Save.SetCurrentLevel("Level", 5);
        countQuiz = 0;
    }
    private void Update()
    {
        UpdateScore();
        Debug.Log("Level" + Save.GetCurrentLevel("Level"));
        Debug.Log("Soal" + countQuiz);
        Debug.Log("Score" + Save.GetCurrentProgres("Quiz"));
    }

    private void UpdateScore()
    {
        if (Save.GetCurrentLevel("Level") == 1)
            quizTXT[8].text = "Score : " + Save.GetCurrentProgres("Quiz1");
        if (Save.GetCurrentLevel("Level") == 5)
            quizTXT[8].text = "Score : " + Save.GetCurrentProgres("Quiz5");
    }
    #region Button Configuration

    private void SetButton()
    {
        for(int i = 0; i<quizBTN.Length;i++)
        {
            switch (i)
            {
                case 0:
                    quizBTN[0] = GameObject.Find("BTN_A");
                    break;

                case 1:
                    quizBTN[1] = GameObject.Find("BTN_B");
                    break;

                case 2:
                    quizBTN[2] = GameObject.Find("BTN_C");
                    break;

                case 3:
                    quizBTN[3] = GameObject.Find("BTN_D");
                    break;

                case 4:
                    quizBTN[4] = GameObject.Find("BTN_E");
                    break;

                case 5:
                    quizBTN[5] = GameObject.Find("BTN_SelesaiQuiz");
                    break;
            }
        }
    }

    private void PertanyaanPertama()
    {
        quizBTN[5].SetActive(false);
        quizBTN[6].SetActive(false);

        quizBTN[7].SetActive(true);

        countQuiz = 1;
        quizTXT[0].text = _soalTexts[0];
        quizTXT[1].text = _kunciJawabanTexts[0];
        quizTXT[2].text = _kunciJawabanTexts[1];
        quizTXT[3].text = _kunciJawabanTexts[2];
        quizTXT[4].text = _kunciJawabanTexts[3];
        quizTXT[5].text = _kunciJawabanTexts[4];

        if(Save.GetCurrentLevel("Level") == 0)
        {
            quizBTN[0].GetComponent<Button>().onClick.AddListener(Salah1);
            quizBTN[1].GetComponent<Button>().onClick.AddListener(Salah1);
            quizBTN[2].GetComponent<Button>().onClick.AddListener(Salah1);
            quizBTN[3].GetComponent<Button>().onClick.AddListener(Benar1);
            quizBTN[4].GetComponent<Button>().onClick.AddListener(Salah1);
        } else
        if(Save.GetCurrentLevel("Level") == 5)
        {
            quizBTN[0].GetComponent<Button>().onClick.AddListener(Salah5);
            quizBTN[1].GetComponent<Button>().onClick.AddListener(Salah5);
            quizBTN[2].GetComponent<Button>().onClick.AddListener(Salah5);
            quizBTN[3].GetComponent<Button>().onClick.AddListener(Benar5);
            quizBTN[4].GetComponent<Button>().onClick.AddListener(Salah5);
        }
    }

    private void PertanyaanKeduaa()
    {
        countQuiz = 2;
        quizTXT[0].text = _soalTexts[1];
        quizTXT[1].text = _kunciJawabanTexts[5];
        quizTXT[2].text = _kunciJawabanTexts[6];
        quizTXT[3].text = _kunciJawabanTexts[7];
        quizTXT[4].text = _kunciJawabanTexts[8];
        quizTXT[5].text = _kunciJawabanTexts[9];

        if (Save.GetCurrentLevel("Level") == 0)
        {
            quizBTN[0].GetComponent<Button>().onClick.AddListener(Salah1);
            quizBTN[1].GetComponent<Button>().onClick.AddListener(Salah1);
            quizBTN[2].GetComponent<Button>().onClick.AddListener(Salah1);
            quizBTN[3].GetComponent<Button>().onClick.AddListener(Salah1);
            quizBTN[4].GetComponent<Button>().onClick.AddListener(Benar1);
        }
        else
        if (Save.GetCurrentLevel("Level") == 5)
        {
            quizBTN[0].GetComponent<Button>().onClick.AddListener(Salah5);
            quizBTN[1].GetComponent<Button>().onClick.AddListener(Salah5);
            quizBTN[2].GetComponent<Button>().onClick.AddListener(Salah5);
            quizBTN[3].GetComponent<Button>().onClick.AddListener(Salah5);
            quizBTN[4].GetComponent<Button>().onClick.AddListener(Benar5);
        }

    }

    private void PertanyaanKetiga()
    {
        countQuiz = 3;
        quizTXT[0].text = _soalTexts[2];
        quizTXT[1].text = _kunciJawabanTexts[10];
        quizTXT[2].text = _kunciJawabanTexts[11];
        quizTXT[3].text = _kunciJawabanTexts[12];
        quizTXT[4].text = _kunciJawabanTexts[13];
        quizTXT[5].text = _kunciJawabanTexts[14];

        if (Save.GetCurrentLevel("Level") == 0)
        {
            quizBTN[0].GetComponent<Button>().onClick.AddListener(Salah1);
            quizBTN[1].GetComponent<Button>().onClick.AddListener(Benar1);
            quizBTN[2].GetComponent<Button>().onClick.AddListener(Salah1);
            quizBTN[3].GetComponent<Button>().onClick.AddListener(Salah1);
            quizBTN[4].GetComponent<Button>().onClick.AddListener(Salah1);
        }
        else
        if (Save.GetCurrentLevel("Level") == 5)
        {
            quizBTN[0].GetComponent<Button>().onClick.AddListener(Salah5);
            quizBTN[1].GetComponent<Button>().onClick.AddListener(Benar5);
            quizBTN[2].GetComponent<Button>().onClick.AddListener(Salah5);
            quizBTN[3].GetComponent<Button>().onClick.AddListener(Salah5);
            quizBTN[4].GetComponent<Button>().onClick.AddListener(Salah5);
        }

    }

    private void PertanyaanKeempat()
    {
        countQuiz = 4;
        quizTXT[0].text = _soalTexts[3];
        quizTXT[1].text = _kunciJawabanTexts[15];
        quizTXT[2].text = _kunciJawabanTexts[16];
        quizTXT[3].text = _kunciJawabanTexts[17];
        quizTXT[4].text = _kunciJawabanTexts[18];
        quizTXT[5].text = _kunciJawabanTexts[19];

        if (Save.GetCurrentLevel("Level") == 0)
        {
            quizBTN[0].GetComponent<Button>().onClick.AddListener(Benar1);
            quizBTN[1].GetComponent<Button>().onClick.AddListener(Salah1);
            quizBTN[2].GetComponent<Button>().onClick.AddListener(Salah1);
            quizBTN[3].GetComponent<Button>().onClick.AddListener(Salah1);
            quizBTN[4].GetComponent<Button>().onClick.AddListener(Salah1);
        }
        else
        if (Save.GetCurrentLevel("Level") == 5)
        {
            quizBTN[0].GetComponent<Button>().onClick.AddListener(Benar5);
            quizBTN[1].GetComponent<Button>().onClick.AddListener(Salah5);
            quizBTN[2].GetComponent<Button>().onClick.AddListener(Salah5);
            quizBTN[3].GetComponent<Button>().onClick.AddListener(Salah5);
            quizBTN[4].GetComponent<Button>().onClick.AddListener(Salah5);
        }
    }

    private void PertanyaanKelima()
    {
        countQuiz = 5;
        quizTXT[0].text = _soalTexts[4];
        quizTXT[1].text = _kunciJawabanTexts[20];
        quizTXT[2].text = _kunciJawabanTexts[21];
        quizTXT[3].text = _kunciJawabanTexts[22];
        quizTXT[4].text = _kunciJawabanTexts[23];
        quizTXT[5].text = _kunciJawabanTexts[24];

        if (Save.GetCurrentLevel("Level") == 0)
        {
            quizBTN[0].GetComponent<Button>().onClick.AddListener(Salah1);
            quizBTN[1].GetComponent<Button>().onClick.AddListener(Salah1);
            quizBTN[2].GetComponent<Button>().onClick.AddListener(Benar1);
            quizBTN[3].GetComponent<Button>().onClick.AddListener(Salah1);
            quizBTN[4].GetComponent<Button>().onClick.AddListener(Salah1);
        }
        else
        if (Save.GetCurrentLevel("Level") == 5)
        {
            quizBTN[0].GetComponent<Button>().onClick.AddListener(Salah5);
            quizBTN[1].GetComponent<Button>().onClick.AddListener(Salah5);
            quizBTN[2].GetComponent<Button>().onClick.AddListener(Benar5);
            quizBTN[3].GetComponent<Button>().onClick.AddListener(Salah5);
            quizBTN[4].GetComponent<Button>().onClick.AddListener(Salah5);
        }
    }


    private void Benar1()
    {
        int salah = Save.GetCurrentProgres("Quiz") + 1;
        Save.SetCurrentProgres("Quiz", salah);
        CheckedSoal();
    }

    private void Salah1()
    {
        int salah = Save.GetCurrentProgres("Quiz") + 0;
        Save.SetCurrentProgres("Quiz", salah);
        CheckedSoal();
    }

    private void Benar5()
    {
        int salah = Save.GetCurrentProgres("Quiz5") + 1;
        Save.SetCurrentProgres("Quiz5", salah);
        CheckedSoal();
    }

    private void Salah5()
    {
        int salah = Save.GetCurrentProgres("Quiz5") + 0;
       Save.SetCurrentProgres("Quiz5", salah);
        CheckedSoal();
    }

    private void ResetPertanyaan()
    {
        quizTXT[0].text = _contentText[4];
        quizTXT[6].text = _contentText[0];
        quizTXT[7].text = _contentText[3];


        quizBTN[5].SetActive(true);
        quizBTN[6].SetActive(true);
        quizBTN[7].SetActive(false);

        Save.SetCurrentProgres("Quiz", 0);
        Save.SetCurrentProgres("Quiz5", 0);

        quizBTN[5].GetComponent<Button>().onClick.AddListener(PertanyaanPertama);
    }

    private void CheckedSoal()
    {
        switch (countQuiz)
        {
            case 1:
                PertanyaanKeduaa();
                break;

            case 2:
                PertanyaanKetiga();
                break;

            case 3:
                PertanyaanKeempat();
                break;

            case 4:
                PertanyaanKelima();
                break;

            case 5:
                if(Save.GetCurrentLevel("Level") == 0)
                {
                    quizBTN[5].SetActive(true);
                    quizBTN[6].SetActive(true);

                    quizBTN[7].SetActive(false);

                    quizTXT[0].text = _contentText[4];
                    quizTXT[6].text = _contentText[1];
                    quizTXT[7].text = _contentText[3];

                    quizBTN[5].GetComponent<Button>().onClick.AddListener(MoveToLevel1);
                }

                if (Save.GetCurrentLevel("Level") == 5)
                {
                    quizBTN[5].SetActive(true);
                    quizBTN[6].SetActive(true);

                    quizBTN[7].SetActive(false);

                    quizTXT[0].text = _contentText[4];
                    quizTXT[6].text = _contentText[2];
                    quizTXT[7].text = _contentText[5];

                    quizBTN[5].GetComponent<Button>().onClick.AddListener(MoveToMainMenu);
                }
                break;
        }

    }
    
    private void MoveToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void MoveToLevel1()
    {
        SceneManager.LoadScene("Gameplay_1");
    }
    #endregion

    #region Text Configuration

    private void ValueQuizText()
    {
        _contentText = new string[6];
        _contentText[0] = "Sebelum kamu dapat melanjutkan game, terdapat Lima pertanyaan yang akan menguji kamu ketika di awal dan diakhir game deteksi coliform \nlakukan sebaik mungkin dan selamat mengerjakan <3";
        _contentText[1] = "Terimakasih kamu telah menjawab lima pertanyaan yang ada, ketuk tombol selanjutnya untuk melanjutkan kedalam permainan";
        _contentText[2] = "Terimakasih kamu telah menjawab lima pertanyaan yang ada, ketuk tombol selanjutnya untuk kembali ke menu";
        _contentText[3] = "Selanjutnya";
        _contentText[4] = "Quiz";
        _contentText[5] = "Main Menu";

        _soalTexts = new string[5];
        _soalTexts[0] = "Manakah dari alat berikut yang berfungsi mensetralisasi alat dan bahan ?";
        _soalTexts[1] = "Indikator dari apakah keberadaan Coliform dalam produk makanan ?";
        _soalTexts[2] = "Apakah Fungsi Pengenceran dalam Deteksi Coliform ?";
        _soalTexts[3] = "Apakah Fungsi Dari Tabung Durham dalam deteksi Coliform ?";
        _soalTexts[4] = "Apakah nama medium yang digunakan dalam praktikum ini ?";

        _kunciJawabanTexts = new string[25];
        //Soal 1 = [3]autoklaf
        _kunciJawabanTexts[0] = "Kompor";
        _kunciJawabanTexts[1] = "Kulkas";
        _kunciJawabanTexts[2] = "Tabung Reaksi";
        _kunciJawabanTexts[3] = "Autoklaf";
        _kunciJawabanTexts[4] = "Pipet Ukur";

        //Soal 2 = [9]Kontaminasi faekal (kotoran) dalam makanan
        _kunciJawabanTexts[5] = "Kontaminasi tanah dalam makanan";
        _kunciJawabanTexts[6] = "Kontaminasi virus dalam makanan";
        _kunciJawabanTexts[7] = "Kontaminasi Senyawa beracun dalam makanan";
        _kunciJawabanTexts[8] = "Kontaminasi jamur (Kapang) dalam makanan";
        _kunciJawabanTexts[9] = "Kontaminasi fekal (Kotoran) dalam makanan";

        //Soal 3 = [11]Memastikan mikrobia yang diambil dari sampel tidak terlalu banyak
        _kunciJawabanTexts[10] = "Memastikan alat dan bahan yang digunakan tepat dan akurat";
        _kunciJawabanTexts[11] = "Memastikan mikrobia yang diambil dari sampel tidak terlalu banyak";
        _kunciJawabanTexts[12] = "Memastikan kontamminasi mikrobia dari luar";
        _kunciJawabanTexts[13] = "Memastikan sample tidak mengantung mikrobia pathogen";
        _kunciJawabanTexts[14] = "Memastikan lingkungan kerja produksi makanan steril";

        //Soal 4 = [15]Mendeteksi produksi gas yang dipoduksi mikrobia
        _kunciJawabanTexts[15] = "Mendeteksi produksi gas yang dipoduksi mikrobia";
        _kunciJawabanTexts[16] = "Mendeteksi produksi asam yang dipoduksi mikrobia";
        _kunciJawabanTexts[17] = "Mendeteksi produksi alkohol yang dipoduksi mikrobia";
        _kunciJawabanTexts[18] = "Mendeteksi produksi racun yang dipoduksi mikrobia";
        _kunciJawabanTexts[19] = "Mendeteksi produksi gula yang dipoduksi mikrobia";

        //Soal 5 = [22]Medium Lactose Broth Agar
        _kunciJawabanTexts[20] = "Medium Triple Sugar Iron Agar";
        _kunciJawabanTexts[21] = "Medium Salmonela & Sigela Agar";
        _kunciJawabanTexts[22] = "Medium Lactose Broth Agar";
        _kunciJawabanTexts[23] = "Medium Alkali Pepton Agar";
        _kunciJawabanTexts[24] = "Medium Stuart";
    }
    #endregion
}
