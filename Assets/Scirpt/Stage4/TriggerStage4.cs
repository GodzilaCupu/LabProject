using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStage4 : MonoBehaviour
{
    StoryControllerStage4 story;

    private void Start()
    {
        GameObject _gameManager = GameObject.Find("GameManager");
        story = _gameManager.GetComponent<StoryControllerStage4>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "TabungUkurKosong")
            if(Save.GetCurrentProgres("Stage4") == 0)
                story.AquadesToTabungUkur();

        if (collision.gameObject.name == "sample3tabungNonAnimKosong")
            if (Save.GetCurrentProgres("Stage4") == 1)
                story.TabungUkurToTabungReaksi();

        if (collision.gameObject.name == "TabungReaksiAwal")
            if (Save.GetCurrentProgres("Stage4") == 2)
                story.PipetToSampleSatu();

        if (collision.gameObject.name == "sample3tabungNonAnimPenuh")
            if (Save.GetCurrentProgres("Stage4") == 3)
                story.SampleSatuToTigaSample();
    }
}
