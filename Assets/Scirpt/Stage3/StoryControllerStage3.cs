using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryControllerStage3 : MonoBehaviour
{
    public GameObject sampleA, sampleB;

    public bool isSampleA, isSampleB;

    private void Start()
    {
        sampleA = GameObject.Find("SampleA");
        sampleB = GameObject.Find("SampleB");
        Restart();

    }

    private void Restart()
    {
        Save.ResetAllKey();
        sampleA.SetActive(true);
        sampleB.SetActive(true);

        isSampleA = true;
        isSampleB = true;
    }

}
