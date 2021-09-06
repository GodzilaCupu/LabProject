using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject[] menu;

    [Header("Main Menu")]
    [SerializeField] private GameObject descPanelMainMenu;
    [SerializeField] private Text[] textMainMenu;
    [SerializeField] private GameObject[] btnMainMenu;
    private string[] _textMainMenu;

    [Header("Mini Game Level")]
    [SerializeField] private Text[] textMiniGame;
    [SerializeField] private GameObject[] btnMiniGame;
    private string[] _textMiniGame;

    [Header("Level Menu")]
    [SerializeField] private GameObject descPanelLevelMenu;
    [SerializeField] private Text[] textLevelMenu;
    [SerializeField] private GameObject[] btnLevelMenu;
    private string[] _textUIDeteksiColiform, _textContentDeteksiColiform, _textTitleDeteksiColiform;

    int countDownInfo;

    bool mainMenuisActive, miniGameMenuisActive, levelMenuisActive;

    private void Awake()
    {
        ValueTextMainMenu();
        SetTextMainMenu();
        SetButtonMainMenu();

        ValueTextMiniGameMenu();
        SetTextMiniGameMenu();
        SetButtonMiniGameMenu();

        ValueTextDeteksiColiform();
        SetTextDeteksiColiform();
        SetButtonDeteksiColiform();
    }

    void Start()
    {
        RestartMenu();
        CheckMenu();
    }

    private void Update()
    {
        CheckInfoContent();
        CheckStage();
    }

    #region General configuration
    private void CheckMenu()
    {
        if (miniGameMenuisActive == false && mainMenuisActive == true && levelMenuisActive == false)
        {
            menu[0].SetActive(true);
            menu[1].SetActive(false);
            menu[2].SetActive(false);
            menu[3].SetActive(false);

            InfoPanelGetClose();
        }
        else if (miniGameMenuisActive == true && mainMenuisActive == false && levelMenuisActive == false)
        {
            menu[0].SetActive(false);
            menu[1].SetActive(true);
            menu[2].SetActive(false);
            menu[3].SetActive(false);

        }
        else if (miniGameMenuisActive == false && mainMenuisActive == false && levelMenuisActive == true)
        {
            menu[0].SetActive(false);
            menu[1].SetActive(false);
            menu[2].SetActive(true);
            menu[3].SetActive(false);

            InfoPanelGetClose();
        }
    }

    private void RestartMenu()
    { 
        mainMenuisActive = true;
        miniGameMenuisActive = false;
        levelMenuisActive = false;

        countDownInfo = 0;
    }

    #endregion

    #region Main Menu

    private void ValueTextMainMenu()
    {
        _textMainMenu = new string[4];
        _textMainMenu[0] = "Play";
        _textMainMenu[1] = "Exit";
        _textMainMenu[2] = "Virtual Laboratorium - Kamanan Pangan merupakan sebuah permainan edukasi mengenai keamanan pangan yang bertujuan agar pemain mengetahuikondisi dan upaya yang diperlukan untuk mencegah pangan dari kemungkinan tiga cemaran, yaitu cemaran biologis, kimia, dan benda lain yang dapat mengganggu, merugikan, dan membahayakan kesehatan";
        _textMainMenu[3] = "Continue";
    }

    private void SetTextMainMenu()
    {
        for (int i = 0; i < textMainMenu.Length; i++)
            textMainMenu[i].text = _textMainMenu[i];
    }

    private void SetButtonMainMenu()
    {
        for (int i = 0; i < btnMainMenu.Length; i++)
        {
            switch (i)
            {
                case 0:
                    btnMainMenu[0] = GameObject.Find("BTN_Info");
                    btnMainMenu[0].GetComponent<Button>().onClick.AddListener(InfoPanelGetOpen);
                    break;
                case 1:
                    btnMainMenu[1] = GameObject.Find("BTN_NewGame");
                    btnMainMenu[1].GetComponent<Button>().onClick.AddListener(PlayMainMenu);
                    break;

                case 2:
                    btnMainMenu[2] = GameObject.Find("BTN_ExitGame");
                    btnMainMenu[2].GetComponent<Button>().onClick.AddListener(ExitGame);
                    break;

                case 3:
                    btnMainMenu[3] = GameObject.Find("BTN_CLose");
                    btnMainMenu[3].GetComponent<Button>().onClick.AddListener(InfoPanelGetClose);
                    break;

                case 4:
                    btnMainMenu[4] = GameObject.Find("BTN_Continue");
                    btnMainMenu[4].GetComponent<Button>().onClick.AddListener(ContinueMainMenu);
                    break;

                default:
                    Debug.LogWarning("Check Ur Key");
                    break;
            }
        }
    }

    private void InfoPanelGetOpen()
    {
        if (mainMenuisActive == true && levelMenuisActive == false)
            descPanelMainMenu.SetActive(true);
        else if (mainMenuisActive == false && levelMenuisActive == true)
            descPanelLevelMenu.SetActive(true);
    }

    private void InfoPanelGetClose()
    {
        if (mainMenuisActive == true && levelMenuisActive == false)
            descPanelMainMenu.SetActive(false);
        else if (mainMenuisActive == false && levelMenuisActive == true)
            descPanelLevelMenu.SetActive(false);
    }

    private void PlayMainMenu()
    {
        miniGameMenuisActive = true;
        mainMenuisActive = false;
        levelMenuisActive = false;

        CheckMenu();
        Save.SetCurrentLevel("Level", 0);
    }

    private void ContinueMainMenu()
    {
        miniGameMenuisActive = true;
        mainMenuisActive = false;
        levelMenuisActive = false;

        CheckMenu();
        Save.SetCurrentLevel("Level", Save.GetCurrentLevel("Level"));
    }

    private void ExitGame()
    {
        Application.Quit();
        Debug.Log("IsQiet");
    }

    #endregion

    #region Mini Game Menu

    private void ValueTextMiniGameMenu()
    {
        _textMiniGame = new string[2];

        _textMiniGame[0] = "Deteksi Coliform";
        _textMiniGame[1] = "Hygiene";
    }

    private void SetTextMiniGameMenu()
    {
        for (int i = 0; i < textMiniGame.Length; i++)
            textMiniGame[i].text = _textMiniGame[i];
    }

    private void SetButtonMiniGameMenu()
    {
        for (int i = 0; i < btnMiniGame.Length; i++)
        {
            switch (i)
            {
                case 0:
                    btnMiniGame[0] = GameObject.Find("BTN_Back");
                    btnMiniGame[0].GetComponent<Button>().onClick.AddListener(BackToMainMenu);
                    break;

                case 1:
                    btnMiniGame[1] = GameObject.Find("DeteksiColiform");
                    btnMiniGame[1].GetComponent<Button>().onClick.AddListener(PlayDeteksiColiformMenu);
                    break;

                case 2:
                    btnMiniGame[2] = GameObject.Find("Hygiene");
                    btnMiniGame[2].GetComponent<Button>().onClick.AddListener(PlayHygine);
                    break;

                default:
                    Debug.LogWarning("Check ur Key");
                    break;
            }
        }
    }

    private void PlayDeteksiColiformMenu()
    {
        mainMenuisActive = false;
        miniGameMenuisActive = false;
        levelMenuisActive = true;

        CheckMenu();
    }

    private void PlayHygine()
    {
        menu[3].SetActive(true);
        StartCoroutine(LevelErorJeda(2));
    }

    private void BackToMainMenu()
    {
        mainMenuisActive = true;
        miniGameMenuisActive = false;
        levelMenuisActive = false;

        CheckMenu();
    }
    #endregion

    #region Deteksi Coliform Menu

    private void ValueTextDeteksiColiform()
    {
        _textUIDeteksiColiform = new string[8];
        _textUIDeteksiColiform[0] = "Deteksi ColiForm";
        _textUIDeteksiColiform[1] = "Stage 1";
        _textUIDeteksiColiform[2] = "Stage 2";
        _textUIDeteksiColiform[3] = "Stage 3";
        _textUIDeteksiColiform[4] = "Stage 4";
        _textUIDeteksiColiform[5] = "Stage 5";
        _textUIDeteksiColiform[6] = "Deteksi ColiForm";
        _textUIDeteksiColiform[7] = "ColiForm merupakan indicator adanya fecal contamination / kontaminasi kotoran. Karenanya deteksinya penting sebagai indicator kebersihan dan higienitas penanganan pangan olahan. Pada beberapa uji keamanan pangan, jika deteksi Coli Form menunjukkan hasil positif maka produk makanan olahan tersebut sudah dinyatakan tidak layak edar.";

        _textTitleDeteksiColiform = new string[5];
        //Opsi 1
        _textTitleDeteksiColiform[0] = "Pengambilan Alat dan Bahan";
        _textTitleDeteksiColiform[1] = "Persiapan Sample";
        _textTitleDeteksiColiform[2] = "Pembuatan Medium";
        _textTitleDeteksiColiform[3] = "Pengenceran Sample";
        _textTitleDeteksiColiform[4] = "Hasil Pengujian";

        ////Opsi 2
        //_textTitleDeteksiColiform[0] = "Stage 1";
        //_textTitleDeteksiColiform[1] = "Stage 2";
        //_textTitleDeteksiColiform[2] = "Stage 3";
        //_textTitleDeteksiColiform[3] = "Stage 4";
        //_textTitleDeteksiColiform[4] = "Stage 5";

        _textContentDeteksiColiform = new string[5];
        _textContentDeteksiColiform[0] = "Setiap alat dalam laboratorium memiliki fungsi spesifik. Pemilihan alat yang tidak tepat, dapat mempengaruhi ketepatan hasil suatu deteksi ataupun pengujian. Demikian juga dengan bahan. Mengenal alat dan bahan yang tepat dalam pengujian ini merupakan langkah penting yang harus dikuasai guna memastikan tercapainya tujuan dari praktikum ini.";
        _textContentDeteksiColiform[1] = "Sampel pengujian perlu dipersiapkan agar layak untuk diuji di dalam laboratorium. Alat yang digunakan dalam pengujian laboratorium memiliki tingkat sensitifitas dan kapasitas tertentu. Sampel harus dipersiapkan menyesuaikan dengan tingkat sensitifitas dan kapasitas alat agar hasil yang diperoleh akurat dan tepat.";
        _textContentDeteksiColiform[2] = "Medium tumbuh merupakan substrat yang menyediakan nutrisi bagi pertumbuhan mikrobia tertentu. Kontaminasi mikrobia diluar mikrobia yang akan kita deteksi dapat mengganggu hasil suatu pengujian. Pembuatan medium yang baik dan steril wajib dikuasai agar hasil suatu pengujian mikrobia dapat tepat dan akurat.";
        _textContentDeteksiColiform[3] = "Ketika diambil dari lapangan, jumlah mikrobia di dalam sampel bisa jadi sangat banyak. Akibatnya, mikrobia akan sangat sulit dianalisis terutama ketika kita akan melakukan uji kuantitatif. Karenanya, pengenceran sampel sangat penting dalam pengujian mikrobia.";
        _textContentDeteksiColiform[4] = "Uji pathogen pada sampel makanan biasanya mahal dan rumit. Untuk mempermudah pengujian, biasanya diambil suatu mikrobia indicator untuk menunjukkan tingkat keamanan suatu produk makanan. Coliform menunjukkan kelompok mikrobia yang secara persisten ditemui dalam jalur pencernaan binatang dan manusia.";
    }

    private void SetTextDeteksiColiform()
    {
        for (int i = 0; i < textLevelMenu.Length; i++)
            textLevelMenu[i].text = _textUIDeteksiColiform[i];
    }

    private void SetTextInfoDeteksiColiform()
    {
        switch (countDownInfo)
        {
            case 0:
                textLevelMenu[6].text = _textUIDeteksiColiform[6];
                textLevelMenu[7].text = _textUIDeteksiColiform[7];
                break;

            case 1:
                textLevelMenu[6].text = _textTitleDeteksiColiform[0];
                textLevelMenu[7].text = _textContentDeteksiColiform[0];
                break;

            case 2:
                textLevelMenu[6].text = _textTitleDeteksiColiform[1];
                textLevelMenu[7].text = _textContentDeteksiColiform[1];
                break;

            case 3:
                textLevelMenu[6].text = _textTitleDeteksiColiform[2];
                textLevelMenu[7].text = _textContentDeteksiColiform[2];
                break;

            case 4:
                textLevelMenu[6].text = _textTitleDeteksiColiform[3];
                textLevelMenu[7].text = _textContentDeteksiColiform[3];
                break;

            case 5:
                textLevelMenu[6].text = _textTitleDeteksiColiform[4];
                textLevelMenu[7].text = _textContentDeteksiColiform[4];
                break;

            default:
                Debug.LogWarning("Check ur key");
                break;
        }
    }

    private void SetButtonDeteksiColiform()
    {
        for (int i = 0; i < btnLevelMenu.Length; i++)
        {
            switch (i)
            {
                case 0:
                    btnLevelMenu[0] = GameObject.Find("BTN_BackDeteksiColiform");
                    btnLevelMenu[0].GetComponent<Button>().onClick.AddListener(BackToMiniGameMenu);
                    break;

                case 1:
                    btnLevelMenu[1] = GameObject.Find("PengambilanAlatdanBahan");
                    btnLevelMenu[1].GetComponent<Button>().onClick.AddListener(Stage1);
                    break;

                case 2:
                    btnLevelMenu[2] = GameObject.Find("PersiapanSample");
                    btnLevelMenu[2].GetComponent<Button>().onClick.AddListener(Stage2);
                    break;

                case 3:
                    btnLevelMenu[3] = GameObject.Find("PembuatanMedium");
                    btnLevelMenu[3].GetComponent<Button>().onClick.AddListener(Stage3);
                    break;

                case 4:
                    btnLevelMenu[4] = GameObject.Find("PengenceranSample");
                    btnLevelMenu[4].GetComponent<Button>().onClick.AddListener(Stage4);
                    break;

                case 5:
                    btnLevelMenu[5] = GameObject.Find("DeteksiColiformStage");
                    btnLevelMenu[5].GetComponent<Button>().onClick.AddListener(Stage5);
                    break;

                case 6:
                    btnLevelMenu[6] = GameObject.Find("BTN_InfoStage");
                    btnLevelMenu[6].GetComponent<Button>().onClick.AddListener(InfoPanelGetOpen);
                    break;

                case 7:
                    btnLevelMenu[7] = GameObject.Find("BTN_Left");
                    btnLevelMenu[7].GetComponent<Button>().onClick.AddListener(GeserKiriInfo);
                    break;

                case 8:
                    btnLevelMenu[8] = GameObject.Find("BTN_Right");
                    btnLevelMenu[8].GetComponent<Button>().onClick.AddListener(GeserKananInfo);
                    break;

                case 9:
                    btnLevelMenu[9] = GameObject.Find("BTN_CLoseDeteksiColiform");
                    btnLevelMenu[9].GetComponent<Button>().onClick.AddListener(InfoPanelGetClose);
                    break;

                default:
                    Debug.LogWarning("Check ur Key");
                    break;


            }
        }
    }

    private void CheckInfoContent()
    {
        if (countDownInfo <= 0)
            btnLevelMenu[7].GetComponent<Button>().interactable = false;
        else if (countDownInfo < 5 && countDownInfo > 0)
        {
            btnLevelMenu[7].GetComponent<Button>().interactable = true;
            btnLevelMenu[8].GetComponent<Button>().interactable = true;
        }
        else if (countDownInfo == 5)
            btnLevelMenu[8].GetComponent<Button>().interactable = false;
    }

    private void GeserKiriInfo()
    {
        countDownInfo--;
        SetTextInfoDeteksiColiform();
    }

    private void GeserKananInfo()
    {
        countDownInfo++;
        SetTextInfoDeteksiColiform();
    }

    private void BackToMiniGameMenu()
    {
        mainMenuisActive = false;
        miniGameMenuisActive = true;
        levelMenuisActive = false;

        CheckMenu();
    }

    private void CheckStage()
    {
        switch (Save.GetCurrentLevel("Level"))
        {
            case 0:
                btnLevelMenu[1].GetComponent<Button>().interactable = true;
                btnLevelMenu[2].GetComponent<Button>().interactable = false;
                btnLevelMenu[3].GetComponent<Button>().interactable = false;
                btnLevelMenu[4].GetComponent<Button>().interactable = false;
                btnLevelMenu[5].GetComponent<Button>().interactable = false;
                break;

            case 1:
                btnLevelMenu[1].GetComponent<Button>().interactable = true;
                btnLevelMenu[2].GetComponent<Button>().interactable = false;
                btnLevelMenu[3].GetComponent<Button>().interactable = false;
                btnLevelMenu[4].GetComponent<Button>().interactable = false;
                btnLevelMenu[5].GetComponent<Button>().interactable = false;
                break;

            case 2:
                btnLevelMenu[1].GetComponent<Button>().interactable = true;
                btnLevelMenu[2].GetComponent<Button>().interactable = true;
                btnLevelMenu[3].GetComponent<Button>().interactable = false;
                btnLevelMenu[4].GetComponent<Button>().interactable = false;
                btnLevelMenu[5].GetComponent<Button>().interactable = false;
                break;

            case 3:
                btnLevelMenu[1].GetComponent<Button>().interactable = true;
                btnLevelMenu[2].GetComponent<Button>().interactable = true;
                btnLevelMenu[3].GetComponent<Button>().interactable = true;
                btnLevelMenu[4].GetComponent<Button>().interactable = false;
                btnLevelMenu[5].GetComponent<Button>().interactable = false;
                break;

            case 4:
                btnLevelMenu[1].GetComponent<Button>().interactable = true;
                btnLevelMenu[2].GetComponent<Button>().interactable = true;
                btnLevelMenu[3].GetComponent<Button>().interactable = true;
                btnLevelMenu[4].GetComponent<Button>().interactable = true;
                btnLevelMenu[5].GetComponent<Button>().interactable = false;
                break;

            case 5:
                btnLevelMenu[1].GetComponent<Button>().interactable = true;
                btnLevelMenu[2].GetComponent<Button>().interactable = true;
                btnLevelMenu[3].GetComponent<Button>().interactable = true;
                btnLevelMenu[4].GetComponent<Button>().interactable = true;
                btnLevelMenu[5].GetComponent<Button>().interactable = true;
                break;

            default:
                Debug.LogWarning("Check ur Key");
                break;

        }
    }
    #endregion

    #region Stage
    private void Stage1()
    {
        SceneManager.LoadScene("Quiz");
    }
    private void Stage2()
    {
        SceneManager.LoadScene("Gameplay_2");
    }
    private void Stage3()
    {
        SceneManager.LoadScene("Gameplay_3");
    }

    private void Stage4()
    {
        SceneManager.LoadScene("Gameplay_4");
    }
    private void Stage5()
    {
        SceneManager.LoadScene("Gameplay_5");
    }

    #endregion

    IEnumerator LevelErorJeda(int sec)
    {
        yield return new WaitForSeconds(sec);
        menu[3].SetActive(false);
    }
}
