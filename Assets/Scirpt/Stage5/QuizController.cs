using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizController : MonoBehaviour
{
    [Header("Soal dan Jawaban")]
    // 0 = Soal ; 1 = Pilihan A ; 2 = Pilihan B ; 3 = Pilihan C ; 4 = Pilihan D ; 5 = Pilihan E ;
    [SerializeField] private Text[] quizTXT;
    [SerializeField] private Button[] quizBTN;
    private string[] _kunciJawabanTexts, _soalTexts;
    private int countQuiz;

    [Header("Congrats System")]
    [SerializeField] private Text[] congratsQuizTXT;
    [SerializeField] private Button[] congratsQuizBTN;
    private string[] _congratsQuizTexts;

    private void QuizControl()
    {
        // ngatur quiz keberapa
    }

    #region Button Configuration

    private void SetButton()
    {
        
    }
    
    private void ResetPertanyaan()
    {
        //fungsi untuk ngulang pertanyaan
    }

    private void MoveToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    #endregion

    #region Text Configuration
    private void SetQuizText()
    {
        for (int i = 0; i < quizTXT.Length; i++)
        {
            quizTXT[0].text = _soalTexts[0];

        }
    }

    private void ValueQuizText()
    {
        _congratsQuizTexts = new string[2];
        // 0 = ucapan selamat ; 1 = btn di quiz
        _congratsQuizTexts[0] = "Selamat Anda telah mene";

        _soalTexts = new string[5];
        _soalTexts[0] = "Manakah dari alat berikut yang berfungsi mensetralisasi alat dan bahan ?";
        _soalTexts[1] = "Indikator dari apakah keberadaan Coliform dalam produk makanan ?";
        _soalTexts[2] = "Apakah Fungsi Pengenceran dalam Deteksi Coliform ?";
        _soalTexts[3] = "Apakah Fungsi Dari Tabung Durham dalam deteksi Coliform ?";
        _soalTexts[5] = "Apakah nama medium yang digunakan dalam praktikum ini ?";

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
