using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Task_Congrats_Content : MonoBehaviour
{

    [SerializeField] private Text[] tasks, congrats, infoStage;

    public string[] taskTexts { get; private set; }
    public string[] CongratsText { get; private set; }

    private void Start()
    {
        ValueText();
        SetText();
    }

    private void SetText()
    {
        for(int i = 0; i < tasks.Length; i++)
            tasks[i].text = taskTexts[i];


        for (int j = 0; j < congrats.Length; j++)
            congrats[j].text = CongratsText[j];
    }

    private void ValueText()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene == SceneManager.GetSceneByName("Gameplay_1"))
        {
            CongratsText = new string[2];
            CongratsText[0] = "Selamat !!!";
            CongratsText[1] = "Selamat Anda telah berhasil \nMengambil Alat dan Bahan yang dibutuhkan \nAlat dan Bahan siap untuk digunakan \nAyo Lanjut ke tahapan selanjutnya";
        }

        if (scene == SceneManager.GetSceneByName("Gameplay_2"))
        {
            taskTexts = new string[6];
            taskTexts[0] = "1. Masukan 3 gram medium lactose broth kedalam erlenmayer";
            taskTexts[1] = "2. Tuang  50 ml Aquades di dalam tabung ukur, kemudian campurkan bersama medium lactose broth di dalam erlenmayer";
            taskTexts[2] = "3. Gunakan Spatula untuk mengaduk lactose broth dengan aquades supaya homogen";
            taskTexts[3] = "4. Masukan medium yang sudah homogen kedalam autoclave untuk di sterilisasi selama 45 menit";
            taskTexts[4] = "5. simpan medium kedalam kulkas, untuk digunakan pada tahapan selanjutnya";
            taskTexts[5] = "Petunjuk";


            CongratsText = new string[2];
            CongratsText[0] = "Selamat !!!";
            CongratsText[1] = "Selamat Anda telah berhasil \nMengambil Alat dan Bahan yang dibutuhkan \nAlat dan Bahan siap untuk digunakan \nAyo Lanjut ke tahapan selanjutnya";
        }

        if (scene == SceneManager.GetSceneByName("Gameplay_3"))
        {
            taskTexts = new string[5];
            taskTexts[0] = "1. Pilih Lah Sample yang akan di uji ";
            taskTexts[1] = "2. Masukan sample yang telah di uji ke dalam tabung ukur";
            taskTexts[2] = "3. Ukurlah Aquades menggunakan Tabung Ukur sebanyak 9 ml ";
            taskTexts[3] = "4. Masukan Aquades yang telah di ukur, kedalam tabung reaksi";
            taskTexts[4] = "Petunjuk";

            CongratsText = new string[2];
            CongratsText[0] = "Selamat !!!";
            CongratsText[1] = "Selamat Anda telah berhasil \n menyelesaikan tahapan persiapan sample \n Sample telah siap untuk digunakan \n Ayo Lanjut ke tahapan selanjutnya";
        }

        if (scene == SceneManager.GetSceneByName("Gameplay_4"))
        {
            taskTexts = new string[5];
            taskTexts[0] = "1. Tuang Akuades kedalam tabung ukur Sebanyak 27 ML";
            taskTexts[1] = "2. Tuang Akudaes kedalam masing masing tabung reaksi sebanyak 9 ML";
            taskTexts[2] = "3. Ambil Sample yang sudah di persiapkan sebelumnya menggunakan pipet sebanayk 1 ML";
            taskTexts[3] = "4. Ambil Sample yang sudah dipersaipkan menggunakan pipet masing masing sebanyak 1 ML";
            taskTexts[4] = "Petunjuk";

            CongratsText = new string[2];
            CongratsText[0] = "Selamat !!!";
            CongratsText[1] = "Selamat Anda telah berhasil \n menyelesaikan tahapan pengenceran sample \n Sample telah siap untuk digunakan \n Ayo Lanjut ke tahapan selanjutnya";
        }

        if (scene == SceneManager.GetSceneByName("Gameplay_5"))
        {
            taskTexts = new string[5];
            taskTexts[0] = "1. Panaskan Medium yang telah diolah sebelumnya";
            taskTexts[1] = "2. Tambahkan Medium kedalam masing masing Sample sebanyak 10 ML";
            taskTexts[2] = "3. Masukkan Tabung Durham kedalam masing masing Sample";
            taskTexts[3] = "4. Masukan Sample yang sudah siap Kedalam Inkkubator dan tunggu 24 Jam";
            taskTexts[4] = "Petunjuk";

            CongratsText = new string[2];
            CongratsText[0] = "Selamat !!!";
            CongratsText[1] = "Selamat Anda telah berhasil \n Menguji Colliform pada \n Sample yang telah disediakan";
        }
    }

    public void ChangeColor() 
    {
        if (Save.GetCurrentLevel("Level") == 2)
        {
            switch (Save.GetCurrentProgres("Stage2"))
            {
                case 1:
                    tasks[0].color = Color.grey;
                    break;

                case 2:
                    tasks[1].color = Color.grey;
                    break;

                case 3:
                    tasks[2].color = Color.grey;
                    break;

                case 4:
                    tasks[3].color = Color.grey;
                    break;

                case 5:
                    tasks[4].color = Color.grey;
                    break;

                default:
                    Debug.LogWarning("Check Ur Key");
                    break;

            }
        }

        if (Save.GetCurrentLevel("Level") == 3)
        {
            switch (Save.GetCurrentProgres("Stage3"))
            {
                case 1:
                    tasks[0].color = Color.grey;
                    break;

                case 2:
                    tasks[1].color = Color.grey;
                    break;

                case 3:
                    tasks[2].color = Color.grey;
                    break;

                case 4:
                    tasks[3].color = Color.grey;
                    break;

                default:
                    Debug.LogWarning("Check Ur Key");
                    break;

            }
        }

        if (Save.GetCurrentLevel("Level") == 4)
        {
            switch (Save.GetCurrentProgres("Stage4"))
            {
                case 1:
                    tasks[0].color = Color.grey;
                    break;

                case 2:
                    tasks[1].color = Color.grey;
                    break;

                case 3:
                    tasks[2].color = Color.grey;
                    break;

                default:
                    Debug.LogWarning("Check Ur Key");
                    break;

            }

        }

        if (Save.GetCurrentLevel("Level") == 5)
        {
            switch (Save.GetCurrentProgres("Stage5"))
            {
                case 1:
                    tasks[0].color = Color.grey;
                    break;

                case 2:
                    tasks[1].color = Color.grey;
                    break;

                case 3:
                    tasks[2].color = Color.grey;
                    break;

                case 4:
                    tasks[3].color = Color.grey;
                    break;

                default:
                    Debug.LogWarning("Check Ur Key");
                    break;

            }

        }

    }
}
