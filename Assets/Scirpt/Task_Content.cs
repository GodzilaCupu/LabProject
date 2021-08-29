using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Task_Content : MonoBehaviour
{

    [SerializeField] private Text[] tasks, congrats;

    public string[] taskTexts { get; private set; }
    public string[] CongratsText { get; private set; }

    private void Start()
    {
        ArrayTugas();
        SetText();
    }

    private void SetText()
    {
        for(int i = 0; i < tasks.Length; i++)
            tasks[i].text = taskTexts[i];


        for (int j = 0; j < congrats.Length; j++)
            congrats[j].text = CongratsText[j];
    }

    private void ArrayTugas()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene == SceneManager.GetSceneByName("Gameplay_3"))
        {
            taskTexts = new string[4];
            taskTexts[0] = "Pilih Lah Sample yang akan di uji ";
            taskTexts[1] = "Masukan sample yang telah di uji ke dalam tabung ukur";
            taskTexts[2] = "Ukurlah Aquades menggunakan Tabung Ukur sebanyak 9 ml ";
            taskTexts[3] = "Masukan Aquades yang telah di ukur, kedalam tabungUkurTrigger reaksi";

            CongratsText = new string[4];
            CongratsText[0] = "Selamat !!!";
            CongratsText[1] = "Selamat Anda telah berhasil \n menyelesaikan tahapan persiapan sample \n Sample telah siap untuk digunakan \n Ayo Lanjut ke tahapan selanjutnya";
            CongratsText[2] = "Main Menu";
            CongratsText[3] = "Lanjut";
        }

        if (scene == SceneManager.GetSceneByName("Gameplay_4"))
        {
            taskTexts = new string[3];
            taskTexts[0] = "Tuang Akuades kedalam tabung ukur Sebanyak 27 ML";
            taskTexts[1] = "Tuang Akudaes kedalam masing masing tabung reaksi sebanyak 9 ML";
            taskTexts[2] = "Ambil Sample yang sudah dipersaipkan menggunakan pipet masing masing sebanyak 1 ML";

            CongratsText = new string[4];
            CongratsText[0] = "Selamat !!!";
            CongratsText[1] = "Selamat Anda telah berhasil \n menyelesaikan tahapan pengenceran sample \n Sample telah siap untuk digunakan \n Ayo Lanjut ke tahapan selanjutnya";
            CongratsText[2] = "Main Menu";
            CongratsText[3] = "Lanjut";
        }
    }

    public void ChangeColor()
    {
        Scene scene = SceneManager.GetActiveScene();

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

    }
}
