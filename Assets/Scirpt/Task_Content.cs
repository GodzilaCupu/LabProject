using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Task_Content : MonoBehaviour
{

    [SerializeField] private Text[] tasks;
    public string[] taskTexts { get; private set; }

    private void Start()
    {
        ArrayTugas();
        SetText();
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
            if (1 <= Save.GetCurrentProgres("Stage3"))
                tasks[0].color = Color.grey;
            if (2 <= Save.GetCurrentProgres("Stage3"))
                tasks[1].color = Color.grey;
            if (3 <= Save.GetCurrentProgres("Stage3"))
                tasks[2].color = Color.grey;
            if (4 <= Save.GetCurrentProgres("Stage3"))
                tasks[3].color = Color.grey;

        }

    }
}
