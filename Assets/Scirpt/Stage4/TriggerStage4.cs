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
        if(this.gameObject.name == "Akuades" && collision.gameObject.name == "TabungUkurKosong")
            if(Save.GetCurrentProgres("Stage4") == 0)
                story.AquadesToTabungUkur();

        if (this.gameObject.name == "Tabung ukur Penuh" && collision.gameObject.name == "sample3tabungNonAnimKosong")
            if (Save.GetCurrentProgres("Stage4") == 1)
                story.TabungUkurToTabungReaksi();

        if (this.gameObject.name == "PipetKosong" && collision.gameObject.name == "TabungReaksiAwal")
            if (Save.GetCurrentProgres("Stage4") == 2)
                story.PipetToSampleSatu();

        if (this.gameObject.name == "PipetPenuh" && collision.gameObject.name == "sample3tabungNonAnimPenuh")
            if (Save.GetCurrentProgres("Stage4") == 3)
                story.SampleSatuToTigaSample();
    }
}
