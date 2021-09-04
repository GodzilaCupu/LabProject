using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryControllerStage1 : MonoBehaviour
{
    [Header("Object Benar")]
    public GameObject[] objBenar;

    [Header("Object Salah")]
    public GameObject[] objSalah;

    [Header("UI")]
    [SerializeField] private Toggle[] taskToggle;
    [SerializeField] private Text[] taskText;
    [SerializeField] private Text popupText;
    [SerializeField] private GameObject[] task;

    [Header("Content Pop Up Menang")]
    private string popupString;
    private string[] taskString;

    int progress;
    TutorialController tutor;
    BTN_Controller btn;

    private void Start()
    {
        GameObject _gameManager = GameObject.Find("GameManager");

        btn= _gameManager.GetComponent<BTN_Controller>();
        tutor = _gameManager.GetComponent<TutorialController>();

        Save.SetCurrentLevel("Level", 1);
        ResetProgres();
        ValueText();
        SetText();
    }
    #region Value Configuration
    private void ValueText()
    {
        taskString = new string[8];
        taskString[0] = "Aqudes";
        taskString[1] = "Latose Broth";
        taskString[2] = "Arloji Glass";
        taskString[3] = "Erlenmeyer 250 ML";
        taskString[4] = "Spatula";
        taskString[5] = "Pipet Ukur";
        taskString[6] = "Tabung Ukur 50";
        taskString[7] = "12 Tabung Reaksi dan Tabung Durham";

        popupString = "Oh tidak, kamu mengambil barang yang salah";
    }

    private void SetText()
    {
        for (int i = 0; i < taskString.Length; i++)
            taskText[i].text = taskString[i];

        popupText.text = popupString;
    }

    private void ResetProgres()
    {
        for (int i = 0; i < taskToggle.Length; i++)
            taskToggle[i].isOn = false;

        progress = 0;
        Save.SetCurrentProgres("Stage1", progress);
    }

    #endregion

    public void Benar(int i)
    {
        objBenar[i].SetActive(false);
        taskText[i].color = Color.grey;
        taskToggle[i].isOn = true;
        progress++;
        Save.SetCurrentProgres("Stage1",progress);

        Debug.Log("progress" + progress + Save.GetCurrentProgres("Stage1"));
    }

    public void Salah()
    {
        task[0].SetActive(true);
        btn.PanelUIActive();
        StartCoroutine(SalahJeda(2));
    }

    public void CongratsGetOpenStage1()
    {
        btn.CongratsGetOpen();
        task[1].SetActive(false);
    }

    IEnumerator SalahJeda(int jeda)
    {
        yield return new WaitForSeconds(jeda);
        task[0].SetActive(false);
        btn.PanelUINonActive();
    }

}
