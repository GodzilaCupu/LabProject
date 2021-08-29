using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryControllerStage3 : MonoBehaviour
{
    private GameObject sampleA, sampleB;
    private Task_Content task;

    public Animator anim;

    public bool isSampleA, isSampleB;

    private void Start()
    {
        GameObject _gamemanager = GameObject.Find("GameManager");
        sampleA = GameObject.Find("SampleA");
        sampleB = GameObject.Find("SampleB");

        task = _gamemanager.GetComponent<Task_Content>();
        Save.SetCurrentLevel("Level", 3);

        anim.GetComponent<Animator>();
        Restart();

    }

    public void IfSampleA()
    {
        isSampleA = true;
        isSampleB = false;

        sampleB.SetActive(false);
        task.ChangeColor();


        Save.SetSample("Sample", "SampleA");
        Save.SetCurrentProgres("Stage3", 1);
    }

    public void IfSampleB()
    {
        isSampleA = false;
        isSampleB = true;

        sampleA.SetActive(false);
        task.ChangeColor();

        Save.SetSample("Sample", "SampleB");
        Save.SetCurrentProgres("Stage3", 1);
    }


    private void Restart()
    {
        Save.DelateKey("Stage3");
        sampleA.SetActive(true);
        sampleB.SetActive(true);

        isSampleA = true;
        isSampleB = true;
    }

}
