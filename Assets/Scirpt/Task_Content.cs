using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Task_Content : MonoBehaviour
{

    [SerializeField] private Text[] tasks;
    public int progres;

    public string[] taskTexts { get; private set; }

    private void Start()
    {
        ArrayTugas();
        SetText();
        progres = -1;
    }

    private void Update()
    {
        ChangeColor();
    }

    private void SetText()
    {
        for(int i = 0; i < tasks.Length; i++)
        {
            tasks[i].text = taskTexts[i];
        }
    }

    private void ArrayTugas()
    {
        Scene scene = SceneManager.GetActiveScene();

        if(scene == SceneManager.GetSceneByName("Gameplay_3"))
        {
            taskTexts = new string[4];
            taskTexts[0] = "Pilih Lah Sample yang akan di uji ";
            taskTexts[1] = "Masukan sample yang telah di uji ke dalam  tabung reaksi ";
            taskTexts[2] = "Ukurlah Aquades menggunakan Tabung Ukur sebanyak 9 ml ";
            taskTexts[3] = "Masukan Aquades yang telah di ukur, kedalam tabung reaksi";
        }

    }

    private void ChangeColor()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene == SceneManager.GetSceneByName("Gameplay_3"))
        {
            if (progres == Save.GetCurrentProgres("Stage3"))
            { 
                tasks[progres].color = Color.gray;
                Debug.LogWarning(progres);
            }

        }

    }
}
