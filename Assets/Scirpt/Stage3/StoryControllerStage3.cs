using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryControllerStage3 : MonoBehaviour
{
    [SerializeField] private GameObject tabungReaksiKosong, tabungReaksiSample, tabungReaksiCampuran, aquadesAnim, aquades, tabungUkurTrigger_1, tabungUkurTrigger_2;

    [SerializeField] private GameObject sampleA, sampleB;
    Task_Congrats_Content task;

    public Animator anim;

    public bool isSampleA, isSampleB;

    private void Start()
    {
        GameObject _gamemanager = GameObject.Find("GameManager");
        sampleA = GameObject.Find("SampleA");
        sampleB = GameObject.Find("SampleB");

        task = _gamemanager.GetComponent<Task_Congrats_Content>();
        anim.GetComponent<Animator>();

        Save.SetCurrentLevel("Level",3);
        if (Save.GetCurrentProgres("Stage3") <= 2)
            tabungReaksiSample.SetActive(false);

        Restart();
    }

    #region Step
    //Step 1
    public void IfSampleA()
    {
        isSampleA = true;
        isSampleB = false;

        sampleB.SetActive(false);
        task.ChangeColor();


        Save.SetSample("Sample", "SampleA");
        Save.SetCurrentProgres("Stage3", 1);

        Debug.Log(Save.GetCurrentLevel("Level") + "LEVEL");

    }

    public void IfSampleB()
    {
        isSampleA = false;
        isSampleB = true;

        sampleA.SetActive(false);
        task.ChangeColor();

        Save.SetSample("Sample", "SampleB");
        Save.SetCurrentProgres("Stage3", 1);

        Debug.Log(Save.GetCurrentLevel("Level") + "LEVEL");

    }

    //Step2
    public void PiringToTabungReaksi()
    {
        tabungReaksiKosong.SetActive(false);
        tabungReaksiSample.SetActive(true);

        GameObject piring = GameObject.Find(Save.GetSample("Sample"));
        piring.SetActive(false);
        Save.SetCurrentProgres("Stage3", 2);
        task.ChangeColor();

    }

    //Step3
    public void AquadesToTabungUkur()
    {
        aquades.SetActive(false);
        tabungUkurTrigger_1.SetActive(false);
        aquadesAnim.SetActive(true);

        Save.SetCurrentProgres("Stage3", 3);
        task.ChangeColor();

        anim.SetBool("Squeze", true);
        StartCoroutine(waitTabungReaksiIsi(4));
    }

    //Step4
    public void TabungUkurPenuhToTabungReaksi()
    {
        tabungReaksiCampuran.SetActive(true);
        tabungUkurTrigger_2.SetActive(false);

        Save.SetCurrentProgres("Stage3", 4);
        task.ChangeColor();
    }
    #endregion


    #region IEnumClas
    IEnumerator waitTabungReaksiIsi(int sec)
    {
        yield return new WaitForSeconds(sec);
        tabungReaksiSample.SetActive(true);
        tabungUkurTrigger_2.SetActive(true);
        aquadesAnim.SetActive(false);
    }

    //IEnumerator TabungUkurCampuranJeda( int sec)
    //{
    //    yield return new WaitForSeconds(sec);
    //    Save.SetCurrentProgres("Stage3", 4);
    //}

    #endregion


    private void Restart()
    {
        Save.DelateKey("Stage3");
        sampleA.SetActive(true);
        sampleB.SetActive(true);

        isSampleA = false;
        isSampleB = false;
    }

}
