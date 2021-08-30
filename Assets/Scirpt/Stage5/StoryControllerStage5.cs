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
    [SerializeField] private GameObject[] gambarKesimpulan;

    private string[] kesimpulanTexts;

    Task_Content task;
    BTN_Controller btn;

    void Start()
    {
        GameObject _gameManager = GameObject.Find("GameManager");
        task = _gameManager.GetComponent<Task_Content>();
        btn = _gameManager.GetComponent<BTN_Controller>();

        Save.SetCurrentLevel("Level", 5);
        ResetProgres();
        Content();
        SetText();
    }

    
    #region Step
    //Step1
    public void ElenmayerToHeater()
    {
        objectTrigger[0].SetActive(false);
        //kompoor
        objectTrigger[2].SetActive(false);
        objectsAnim[0].SetActive(true);
        anim[0].SetBool("Panasin", true);
        btn.DisableAllBTN();

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
        btn.DisableAllBTN();

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
        anim[2].SetBool("Inkubasi", true);
        btn.DisableAllBTN();

        StartCoroutine(IncobatorJeda());

    }

    #endregion

    #region IEnumClass
    IEnumerator ElenmayerJeda(int sec)
    {
        yield return new WaitForSeconds(7);
        anim[0].SetBool("Panasin", false);
        btn.DisableAllBTN();
        Debug.Log("1");

        yield return new WaitForSeconds(sec);
        objectTrigger[1].SetActive(true);
        objectTrigger[2].SetActive(true);

        btn.EnebleALLBTN();

        objectsAnim[0].SetActive(false);
        Debug.Log("2");
    }

    IEnumerator PipetToElenmayerJeda(int sec)
    {

        yield return new WaitForSeconds(sec);
        objectTrigger[2].SetActive(true);
        objectTrigger[4].SetActive(true);
        objectTrigger[5].SetActive(false);

        objectsAnim[1].SetActive(false);
        btn.EnebleALLBTN();

    }

    IEnumerator IncobatorJeda()
    {
        yield return new WaitForSeconds(12);
        objectsAnim[3].SetActive(true);
        anim[2].SetBool("Inkubasi", false);
        anim[3].SetBool("24Hour", true);

        yield return new WaitForSeconds(6);
        objectsAnim[3].SetActive(false);
        anim[2].SetBool("Idle", true);

        yield return new WaitForSeconds(9);
        objectTrigger[7].SetActive(true);
        btn.EnebleALLBTN();

        Save.SetCurrentProgres("Stage5", 5);
        task.ChangeColor();
    }

    #endregion

    #region Content Akhir 
    private void Content()
    {
        kesimpulanTexts = new string[4];
        kesimpulanTexts[0] = "Hasil Pecobaan";
        kesimpulanTexts[1] = "Selanjutnya";
        kesimpulanTexts[2] = "Dari Hasil Percobaan Yang telah dilakukan, Tidak terdapat Gelembung pada tabung Durham yang menandakan Sample yang terpilih tidak terdapat Tidak Zat Coliform di dalamnya.";
        kesimpulanTexts[3] = "Dari Hasil Percobaan yang telah dilakukan, Terdapat Gelembung pada tabung Durham yang menandakan Sample yang terpilih terdapat Zat Coliform didalamnya";
    }

    private void SetText()
    {
        kesimpulan[0].text = kesimpulanTexts[0];
        kesimpulan[1].text = kesimpulanTexts[1];

        if (Save.GetSample("Sample") == "SampleA")
        {
            kesimpulan[2].text = kesimpulanTexts[2];
            gambarKesimpulan[0].SetActive(true);
        }
        else if (Save.GetSample("Sample") == "SampleB")
        {
            kesimpulan[2].text = kesimpulanTexts[3];
            gambarKesimpulan[1].SetActive(true);
        }
    }

    #endregion

    private void ResetProgres()
    {
        Save.DelateKey("Stage5");
    }
}
