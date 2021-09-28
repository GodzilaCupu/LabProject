using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    private string[] _tutorialText;

    [Header ("Panel Configuration")]
    [SerializeField] private GameObject[] panel,button;
    [SerializeField] private Text[] tutorialText;

    [Header("Support Configuration")]
    [SerializeField] private GameObject targetAnim;
    private Animator anim;

    private int countTutorial;
    BTN_Controller btnController;
    private void Start()
    {
        GameObject _gameManager = GameObject.Find("GameManager");
        btnController = _gameManager.GetComponent<BTN_Controller>();

        anim = targetAnim.GetComponent<Animator>();
        SetText();
        SetButton();
        InfoOpen();

        countTutorial = 0;
    }

    private void Update()
    {
        CheckTutor();
        Debug.Log(countTutorial + " tutorial");
    }

    private void SetText()
    {
        _tutorialText = new string[16];

        // Story Stage
        _tutorialText[0] = "Setiap alat dalam laboratorium memiliki fungsi spesifik. Pemilihan alat yang tidak tepat, dapat mempengaruhi ketepatan hasil suatu deteksi ataupun pengujian. Demikian juga dengan bahan. Mengenal alat dan bahan yang tepat dalam pengujian ini merupakan langkah penting yang harus dikuasai guna memastikan tercapainya tujuan dari praktikum ini.";
        _tutorialText[1] = "Sampel pengujian perlu dipersiapkan agar layak untuk diuji di dalam laboratorium. Alat yang digunakan dalam pengujian laboratorium memiliki tingkat sensitifitas dan kapasitas tertentu. Sampel harus dipersiapkan menyesuaikan dengan tingkat sensitifitas dan kapasitas alat agar hasil yang diperoleh akurat dan tepat.";
        _tutorialText[2] = "Medium tumbuh merupakan substrat yang menyediakan nutrisi bagi pertumbuhan mikrobia tertentu. Kontaminasi mikrobia diluar mikrobia yang akan kita deteksi dapat mengganggu hasil suatu pengujian. Pembuatan medium yang baik dan steril wajib dikuasai agar hasil suatu pengujian mikrobia dapat tepat dan akurat.";
        _tutorialText[3] = "Ketika diambil dari lapangan, jumlah mikrobia di dalam sampel bisa jadi sangat banyak. Akibatnya, mikrobia akan sangat sulit dianalisis terutama ketika kita akan melakukan uji kuantitatif. Karenanya, pengenceran sampel sangat penting dalam pengujian mikrobia.";
        _tutorialText[4] = "Uji pathogen pada sampel makanan biasanya mahal dan rumit. Untuk mempermudah pengujian, biasanya diambil suatu mikrobia indicator untuk menunjukkan tingkat keamanan suatu produk makanan. Coliform menunjukkan kelompok mikrobia yang secara persisten ditemui dalam jalur pencernaan binatang dan manusia.";

        // Title Stage
        _tutorialText[5] = "Pengambilan Alat dan Bahan";
        _tutorialText[6] = "Persiapan Sample";
        _tutorialText[7] = "Pembuatan Medium";
        _tutorialText[8] = "Pengenceran Sample";
        _tutorialText[9] = "Hasil Pengujian";

        // Tutorial
        _tutorialText[10] = "Cara Bermaian";
        _tutorialText[11] = "Hai, Pada Stage Kali, Kamu akan mempersiapkan sampel untuk di uji, lakukan sesuai tugas yang diberikan, kamu dapat melihatnya dengan cara mengetuk tombol tugas sepeti contoh di samping";
        _tutorialText[12] = "Kamu dapat mengesser ke kanan atau ke kiri dengan menggunakan tampilan layar dengan menekan tombol ini seperti contoh di samping";
        _tutorialText[13] = "Setelah Mengetahui tugas yang harus dilakukan, kamu dapat menggerakan alat / bahan yang diperlukan dengan cara mengetuk dan menggeser benda tersebut sehingga kamu dapat menyelesaikan tugas yang di berikan";
        _tutorialText[14] = "Tutorial ini dapat di putar kembali, kamu cukup menekan tombol seperti contoh di samping ";
        _tutorialText[15] = "Selamat Bermain <3";
    }

    private void TutorialNext()
    {
        countTutorial++;
        tutorialText[3].text = _tutorialText[countTutorial + 10];
        anim.SetInteger("Tutorial", countTutorial);
    }

    private void TutorialPrev()
    {
        countTutorial--;
        tutorialText[3].text = _tutorialText[countTutorial + 10];
        anim.SetInteger("Tutorial", countTutorial);
    }

    private void CheckTutor()
    {
        if (countTutorial == 1)
        {
            button[2].GetComponent<Button>().interactable = false;
            button[3].GetComponent<Button>().interactable = true;
        }
        else if (countTutorial >= 2 && countTutorial <= 4)
        {
            button[2].GetComponent<Button>().interactable = true;
            button[3].GetComponent<Button>().interactable = true;
        }
        else if (countTutorial == 5)
            button[3].GetComponent<Button>().interactable = false;
    }

    private void SetButton()
    {
        //Info Panel
        button[0].GetComponent<Button>().onClick.AddListener(InfoClose);
        button[1].GetComponent<Button>().onClick.AddListener(TutorialOpen);

        //Tutorial Panel
        button[2].GetComponent<Button>().onClick.AddListener(TutorialPrev);
        button[3].GetComponent<Button>().onClick.AddListener(TutorialNext);
        button[4].GetComponent<Button>().onClick.AddListener(TutorialClose);

        button[5].GetComponent<Button>().onClick.AddListener(TutorialOpen);
    }

    private void InfoOpen()
    {
        panel[0].SetActive(true);
        panel[1].SetActive(false);
        btnController.PanelUIActive();

        //setting Text
        switch (Save.GetCurrentLevel("Level"))
        {
            case 1:
                tutorialText[0].text = _tutorialText[5];
                tutorialText[1].text = _tutorialText[0];
                break;

            case 2:
                tutorialText[0].text = _tutorialText[6];
                tutorialText[1].text = _tutorialText[1];
                break;

            case 3:
                tutorialText[0].text = _tutorialText[7];
                tutorialText[1].text = _tutorialText[2];
                break;

            case 4:
                tutorialText[0].text = _tutorialText[8];
                tutorialText[1].text = _tutorialText[3];
                break;

            case 5:
                tutorialText[0].text = _tutorialText[9];
                tutorialText[1].text = _tutorialText[4];
                break;

            default:
                Debug.Log(" Check ur Key Please");
                break;
        }  
    }

    private void InfoClose()
    {
        panel[0].SetActive(false);
        btnController.PanelUINonActive();
    }

    private void TutorialOpen()
    {
        panel[0].SetActive(false);
        panel[1].SetActive(true);
        tutorialText[2].text = _tutorialText[10];
        tutorialText[3].text = _tutorialText[11];
        countTutorial = 1;
        anim.SetInteger("Tutorial", countTutorial);
    }

    private void TutorialClose()
    {
        panel[0].SetActive(false);
        panel[1].SetActive(false);
        btnController.PanelUINonActive();
        countTutorial = 0;
    }
}
