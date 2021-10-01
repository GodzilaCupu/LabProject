using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class TerminController : MonoBehaviour
{
    [Header("Character")]
    [SerializeField] private SpriteRenderer character;
    [SerializeField] private Sprite[] _character;

    [Header("Button")]
    [SerializeField] private GameObject[] buttonSetting;
    [SerializeField] private GameObject[] buttonAnswer;
    [SerializeField] private GameObject[] buttonUi;

    [Header("Text")]
    [SerializeField] private Text questionsText;
    [SerializeField] private Text[] answerText;

    [Header("Panel")]
    [SerializeField] private GameObject[] panel;

    [Header("Video Player")]
    [SerializeField] private VideoPlayer cucitangan;
    [SerializeField] private AudioSource clipVO;
    [SerializeField] private AudioClip[] _clipVO = new AudioClip[22];
    [SerializeField] private VideoClip[] _cuciTangan = new VideoClip[6];

    private ButtonManager btn;
    private TextManager txt;

    private void Awake()
    {
        btn = this.gameObject.GetComponent<ButtonManager>();
        txt = this.gameObject.GetComponent<TextManager>();
    }

    private void Start()
    {
        Save.SetCurrentLevel("Termin", 0);
        SetTermin1(Save.GetCurrentLevel("Termin"));
    }

    private void SetButton()
    {
        for(int i = 0; i <= buttonUi.Length; i++)
            btn._buttonUI[i] = buttonUi[i].GetComponent<Button>();
        for (int i = 0; i <= buttonAnswer.Length; i++)
            btn._buttonAnswer[i] = buttonAnswer[i].GetComponent<Button>();
        for(int i = 0; i <= buttonSetting.Length; i++)
            btn._buttonSetting[i] = buttonSetting[i].GetComponent<Button>();
    }

    //Termin 1
    private void SetTermin1(int urutan)
    {
        Save.SetCurrentLevel("Termin", 1);
        string kata = txt._questionText[urutan];
        questionsText.text = kata;
        StartCoroutine(Typing(kata));
        clipVO.clip = _clipVO[urutan];
        clipVO.Play();
    }

    public void ToTermin2()
    {
        SetTermin1(Save.GetCurrentLevel("Termin"));
        for(int i = 0; i <= 2; i++)
            Instantiate(buttonAnswer[i],)
        Save.SetCurrentLevel("Termin", 2);
        Save.SetCurrentProgres("Termin2", 0);
    }

    //Termin 2
    public void Termin2Yes()
    {
        switch (Save.GetCurrentProgres("Termin2"))
        {
            case 0:

                break;
        }
    }

    IEnumerator Typing(string Questions)
    {
        questionsText.text = "";
        foreach(char huruf in Questions.ToCharArray())
        {
            questionsText.text += huruf;
            yield return null;
        }
    }


}
