using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryControllerStage3 : MonoBehaviour
{
    public GameObject sampleA, sampleB;
    public Animator anim;

    public bool isSampleA, isSampleB;

    private void Start()
    {
        sampleA = GameObject.Find("SampleA");
        sampleB = GameObject.Find("SampleB");
        anim.GetComponent<Animator>();
        Restart();

    }

    public void IfSampleA()
    {
        isSampleA = true;
        isSampleB = false;

        sampleB.SetActive(false);

        Save.SetSample("Sample", "SampleA");
        Save.SetCurrentProgres("Stage3", 1);

        Debug.LogWarning(Save.GetSample("Sample"));
        Debug.LogWarning(Save.GetCurrentProgres("Stage3"));

    }

    public void IfSampleB()
    {
        isSampleA = false;
        isSampleB = true;

        sampleA.SetActive(false);

        Save.SetSample("Sample", "SampleB");
        Save.SetCurrentProgres("Stage3", 1);

        Debug.LogWarning(Save.GetSample("Sample"));
        Debug.LogWarning(Save.GetCurrentProgres("Stage3"));
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
