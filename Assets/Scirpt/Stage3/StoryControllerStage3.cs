using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryControllerStage3 : MonoBehaviour
{
    public GameObject sampleA, sampleB;

    private void Start()
    {
        sampleA = GameObject.Find("SampleA");
        sampleB = GameObject.Find("SampleB");
    }



}
