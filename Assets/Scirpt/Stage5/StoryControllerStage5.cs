using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryControllerStage5 : MonoBehaviour
{
    [Header("Object Animasi")]
    [SerializeField] private GameObject[] objectsAnim;

    [Header("Object Trigger")]
    [SerializeField] private GameObject[] objectTrigger;
    
    [Header("Animator")]
    [SerializeField] private Animator[] anim;
    
    [Header("Panel Kesimpulan")]
    [SerializeField] private Text[] kesimpulan;
    [SerializeField] private Image gambar;
    // 0 = Sprite Positive ; 1 = Sprite Negative
    [SerializeField] private Sprite[] gambarKesimpulan;
    private string[] _kesimpulanTexts;

    Task_Congrats_Content task;
    BTN_Controller btn;

    private void Awake()
    {
        ValueContentKesimpulan();
        SetText();
        SetButton();
        SetGambar();
    }

    void Start()
    {
        GameObject _gameManager = GameObject.Find("GameManager");
        task = _gameManager.GetComponent<Task_Congrats_Content>();
        btn = _gameManager.GetComponent<BTN_Controller>();

        Save.SetCurrentLevel("Level", 5);
        ResetLevel();
    }

    #region Step
    //Step1
    public void ElenmayerToHeater()
    {
        objectTrigger[0].SetActive(false);
        objectTrigger[2].SetActive(false);
        objectsAnim[0].SetActive(true);
        anim[0].SetBool("Panasin", true);
        btn.PanelUIActive();

        StartCoroutine(ElenmayerJeda(3));
        Save.SetCurrentProgres("Stage5", 1);
        task.ChangeColor();

        Debug.Log("Berhasil");
    }

    //step2
    public void PipetToElenmayer()
    {
        objectTrigger[1].SetActive(false);
        objectTrigger[2].SetActive(false);
        objectTrigger[3].SetActive(false);
        objectTrigger[5].SetActive(false);


        objectsAnim[1].SetActive(true);
        anim[1].SetBool("MediumtoSample", true);
        btn.PanelUIActive();
        btn.isPanelON = true;

        StartCoroutine(PipetToElenmayerJeda(13));
        Save.SetCurrentProgres("Stage5", 2);
        task.ChangeColor();
    }

    //Step3
    public void DurhamToTabung()
    {
        objectTrigger[6].SetActive(false);
        Save.SetCurrentProgres("Stage5", 3);
        task.ChangeColor();
    }

    //Step4
    public void SampleToIncubator()
    {
        objectTrigger[8].SetActive(false);
        objectTrigger[4].SetActive(false);
        objectsAnim[2].SetActive(true);
        btn.PanelUIActive();

        StartCoroutine(IncobatorJeda(7));
    }

    private void Congrats()
    {
        objectTrigger[7].SetActive(false);
        Save.SetCurrentProgres("Stage5", 5);
    }
    #endregion

    #region IEnumClass
    IEnumerator ElenmayerJeda(int sec)
    {
        yield return new WaitForSeconds(3);
        anim[0].SetBool("Panasin", false);
        btn.PanelUIActive();
        Debug.Log("1");

        yield return new WaitForSeconds(sec);
        objectTrigger[1].SetActive(true);
        objectTrigger[2].SetActive(true);

        objectsAnim[0].SetActive(false);

        btn.PanelUINonActive();
        Debug.Log("2");
    }

    IEnumerator PipetToElenmayerJeda(int sec)
    {
        yield return new WaitForSeconds(sec);
        objectTrigger[2].SetActive(true);
        objectTrigger[4].SetActive(true);
        objectTrigger[5].SetActive(false);

        objectsAnim[1].SetActive(false);
        btn.PanelUINonActive();
    }

    IEnumerator IncobatorJeda(int sec)
    {
        anim[2].SetBool("Inkubasi", true);

        yield return new WaitForSeconds(sec);
        objectsAnim[3].SetActive(true);
        anim[3].SetBool("24Hour", true);
        Debug.Log("1- A");

        yield return new WaitForSeconds(sec);
        anim[2].SetBool("Idle", true);
        objectsAnim[3].SetActive(false);
        Debug.Log("2- b");

        yield return new WaitForSeconds(sec);
        objectTrigger[7].SetActive(true);
        btn.PanelUINonActive();
        Debug.Log("3- C");

        Save.SetCurrentProgres("Stage5", 4);
        task.ChangeColor();
    }

    #endregion

    #region Content Akhir 
    private void ValueContentKesimpulan()
    {
        _kesimpulanTexts = new string[4];
        _kesimpulanTexts[0] = "Hasil Pecobaan";
        _kesimpulanTexts[1] = "Selanjutnya";
        _kesimpulanTexts[2] = "Dari Hasil Percobaan Yang telah dilakukan, Tidak terdapat Gelembung pada tabung Durham yang menandakan Sample yang terpilih tidak terdapat Tidak Bakteri Coliform di dalamnya.";
        _kesimpulanTexts[3] = "Dari Hasil Percobaan yang telah dilakukan, Terdapat Gelembung pada tabung Durham yang menandakan Sample yang terpilih terdapat bakteri Coliform didalamnya";
    }

    private void SetGambar()
    {
        GameObject _gambar = GameObject.Find("IMG");
        gambar = _gambar.GetComponent<Image>();
    }

    private void SetButton()
    {
        objectTrigger[9] = GameObject.Find("BTN_ToQuiz");
        objectTrigger[9].GetComponent<Button>().onClick.AddListener(Congrats);
    }

    private void SetText()
    {
        kesimpulan[0].text = _kesimpulanTexts[0];
        kesimpulan[1].text = _kesimpulanTexts[1];

        if (Save.GetSample("Sample") == "SampleA")
        {
            kesimpulan[2].text = _kesimpulanTexts[2];
            gambar.sprite = gambarKesimpulan[0];
        }
        else if (Save.GetSample("Sample") == "SampleB")
        {
            kesimpulan[2].text = _kesimpulanTexts[3];
            gambar.sprite = gambarKesimpulan[1];
        }
    }
    #endregion

    private void ResetLevel()
    {
        objectTrigger[7].SetActive(false);
        Save.DelateKey("Stage5");
    }
}
