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
            taskTexts = new string[3];
            taskTexts[0] = "Mencoba sebuah text yang \n sangat panjang bener adalah ada disini ";
            taskTexts[1] = "Mencoba sebuah text yang \n sangat panjang bener adalah ada disini ";
            taskTexts[2] = "Mencoba sebuah text yang \n sangat panjang bener adalah ada disini ";
        }

    }

}
