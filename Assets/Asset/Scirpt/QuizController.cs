using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizController : MonoBehaviour
{
    [Header("Soal dan Jawaban")]
    [SerializeField] private Text[] quizTXT;
    // 0 = welcomePanel ; 1 = quiz container; 2 = congratspanel ; 3 = soal 1 ; 4 = soal 2 ; 5 = soal 3 ; 6 = soal 4 ; 7 = soal 5
    [SerializeField] private GameObject[] quiz;
    private string[] _kunciJawabanTexts, _soalTexts, _contentText;

    AudioSource sound;

    private void Awake()
    {
        ValueQuizText();
        SetText();
    }   

    private void Start()
    {
        ResetPertanyaan();

        GameObject _gameManageer = GameObject.Find("GameManager");
        sound = _gameManageer.GetComponent<AudioSource>();

        Save.SetCurrentLevel("Quiz", 0);
    }
    private void Update()
    {
        UpdateScore();
    }

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
        _soalTexts[0] = "Manakah dari alat berikut yang berfungsi mensterilisasi alat dan bahan ?";
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

    private void SetText()
    {
        for(int i = 0; i < quizTXT.Length; i++)
        {
            switch (i)
            {
                //WelcomePanel
                // 0 = titleText; 1 = content ; 2 = nextQuestion
                case 0:
                    quizTXT[0].text = _contentText[4];
                    break;

                case 1:
                    quizTXT[1].text = _contentText[0];
                    break;

                case 2:
                    quizTXT[2].text = _contentText[3];
                    break;

                //Congrats Panel
                // 3 = titleText; 4 = content ; 
                case 3:
                    quizTXT[3].text = _contentText[4];
                    break;

                case 4:
                    if(Save.GetCurrentLevel("Level") <= 1)
                        quizTXT[4].text = _contentText[1];
                    else
                    if(Save.GetCurrentLevel("Level") == 5)
                        quizTXT[4].text = _contentText[2];
                    break;

                // score
                // 5 = score
                case 5:
                    quizTXT[5].text = "Score : 0";
                    break;

                //QuizContainer
                // 6 = soal pertama; 7 = soal kedua; 8 = soal ketiga; 9 = soal keempat; 10 = soal kelima;
                case 6:
                    quizTXT[6].text = _soalTexts[0];
                    break;

                case 7:
                    quizTXT[7].text = _soalTexts[1];
                    break;

                case 8:
                    quizTXT[8].text = _soalTexts[2];
                    break;

                case 9:
                    quizTXT[9].text = _soalTexts[3];
                    break;

                case 10:
                    quizTXT[10].text = _soalTexts[4];
                    break;

                // ABCD soal 1;
                case 11:
                    quizTXT[11].text = _kunciJawabanTexts[0];
                    break;

                case 12:
                    quizTXT[12].text = _kunciJawabanTexts[1];
                    break;

                case 13:
                    quizTXT[13].text = _kunciJawabanTexts[2];
                    break;

                case 14:
                    quizTXT[14].text = _kunciJawabanTexts[3];
                    break;

                case 15:
                    quizTXT[15].text = _kunciJawabanTexts[4];
                    break;

                //ABCD soal 2
                case 16:
                    quizTXT[16].text = _kunciJawabanTexts[5];
                    break;

                case 17:
                    quizTXT[17].text = _kunciJawabanTexts[6];
                    break;

                case 18:
                    quizTXT[18].text = _kunciJawabanTexts[7];
                    break;

                case 19:
                    quizTXT[19].text = _kunciJawabanTexts[8];
                    break;

                case 20:
                    quizTXT[20].text = _kunciJawabanTexts[9];
                    break;

                //ABCD soal 3
                case 21:
                    quizTXT[21].text = _kunciJawabanTexts[10];
                    break;

                case 22:
                    quizTXT[22].text = _kunciJawabanTexts[11];
                    break;

                case 23:
                    quizTXT[23].text = _kunciJawabanTexts[12];
                    break;

                case 24:
                    quizTXT[24].text = _kunciJawabanTexts[13];
                    break;

                case 25:
                    quizTXT[25].text = _kunciJawabanTexts[14];
                    break;

                //ABCD soal 4
                case 26:
                    quizTXT[26].text = _kunciJawabanTexts[15];
                    break;

                case 27:
                    quizTXT[27].text = _kunciJawabanTexts[16];
                    break;

                case 28:
                    quizTXT[28].text = _kunciJawabanTexts[17];
                    break;

                case 29:
                    quizTXT[29].text = _kunciJawabanTexts[18];
                    break;

                case 30:
                    quizTXT[30].text = _kunciJawabanTexts[19];
                    break;

                //ABCD soal 5
                case 31:
                    quizTXT[31].text = _kunciJawabanTexts[20];
                    break;

                case 32:
                    quizTXT[32].text = _kunciJawabanTexts[21];
                    break;

                case 33:
                    quizTXT[33].text = _kunciJawabanTexts[22];
                    break;

                case 34:
                    quizTXT[34].text = _kunciJawabanTexts[23];
                    break;

                case 35:
                    quizTXT[35].text = _kunciJawabanTexts[24];
                    break;

                    //backto mainmenu
                case 36:
                    if (Save.GetCurrentLevel("Level") <= 1)
                        quizTXT[36].text = _contentText[3];
                    else if (Save.GetCurrentLevel("Level") == 5)
                        quizTXT[36].text = _contentText[5];
                    break;
            }
        }
    }
    #endregion

    private void UpdateScore()
    {
        if (Save.GetCurrentLevel("Level") <= 1 || Save.GetCurrentLevel("Level") == 0)
            quizTXT[5].text = "Score : " + Save.GetCurrentProgres("Quiz");
        else
        if (Save.GetCurrentLevel("Level") == 5 || Save.GetCurrentLevel("Level") > 0)
            quizTXT[5].text = "Score : " + Save.GetCurrentProgres("Quiz5");
    }
    #region Button Configuration

    public void Benar()
    {
        if (Save.GetCurrentLevel("Level") <= 1)
        {
            int benar = Save.GetCurrentProgres("Quiz") + 20;
            Save.SetCurrentProgres("Quiz", benar);
        }
        else
        if (Save.GetCurrentLevel("Level") == 5)
        {
            int benar = Save.GetCurrentProgres("Quiz5") + 20;
            Save.SetCurrentProgres("Quiz5", benar);
        }
    }

    public void Salah()
    {
        if (Save.GetCurrentLevel("Level") <= 1)
        {
            int salah = Save.GetCurrentProgres("Quiz") + 0;
            Save.SetCurrentProgres("Quiz", salah);
        }
        else
        if (Save.GetCurrentLevel("Level") == 5)
        {
            int salah = Save.GetCurrentProgres("Quiz5") + 0;
            Save.SetCurrentProgres("Quiz5", salah);
        }

    }

    public void Congrats()
    {
        quiz[0].SetActive(false);
        quiz[2].SetActive(true);

        quiz[1].SetActive(false);
    }

    public void Pertanyaan1()
    {
        quiz[0].SetActive(false);
        quiz[2].SetActive(false);

        quiz[1].SetActive(true);
        quiz[3].SetActive(true);
        quiz[4].SetActive(false);
        quiz[5].SetActive(false);
        quiz[6].SetActive(false);
        quiz[7].SetActive(false);

    }

    public void Pertanyaan2()
    {
        quiz[3].SetActive(false);
        quiz[4].SetActive(true);
        quiz[5].SetActive(false);
        quiz[6].SetActive(false);
        quiz[7].SetActive(false);

    }

    public void Pertanyaan3()
    {
        quiz[3].SetActive(false);
        quiz[4].SetActive(false);
        quiz[5].SetActive(true);
        quiz[6].SetActive(false);
        quiz[7].SetActive(false);

    }

    public void Pertanyaan4()
    {
        quiz[3].SetActive(false);
        quiz[4].SetActive(false);
        quiz[5].SetActive(false);
        quiz[6].SetActive(true);
        quiz[7].SetActive(false);

    }

    public void Pertanyaan5()
    {
        quiz[3].SetActive(false);
        quiz[4].SetActive(false);
        quiz[5].SetActive(false);
        quiz[6].SetActive(false);
        quiz[7].SetActive(true);

    }

    private void ResetPertanyaan()
    {
        quiz[0].SetActive(true);
        quiz[1].SetActive(false);
        quiz[2].SetActive(false);

        Save.SetCurrentProgres("Quiz", 0);
        Save.SetCurrentProgres("Quiz5", 0);

        if (Save.GetSound("BGM") == 0)
            sound.mute = true;
        else if (Save.GetSound("BGM") == 1)
            sound.mute = false;
    }

    public void NextGame()
    {
        if (Save.GetCurrentLevel("Level") <= 1)
        {
            SceneManager.LoadScene("Gameplay_1");
            Save.SetCurrentLevel("Quiz", 1);
        }
        else 
        if (Save.GetCurrentLevel("Level") == 5)
        {
            SceneManager.LoadScene("Menu");
        }
    }
    #endregion

}
