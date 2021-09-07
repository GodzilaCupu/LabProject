using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStage2 : MonoBehaviour
{
    StoryControllerStage2 story;
    // Start is called before the first frame update
    void Start()
    {
        GameObject _gamemanager = GameObject.Find("GameManager");
        story = _gamemanager.GetComponent<StoryControllerStage2>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(this.gameObject.name == "Spatula" && collision.gameObject.name == "Lactobrote")
            if (Save.GetCurrentProgres("Stage2") == 0)
                  story.SpatulaToMedium();

        if (this.gameObject.name == "Aquades" && collision.gameObject.name == "TabungUkurKosong")
            story.TuangAquades();

        if (this.gameObject.name == "TabungUkurPenuh" && collision.gameObject.name == "ErlenmayerWithLatobrote")
            if (Save.GetCurrentProgres("Stage2") == 1)
                story.MasukAquadesToSample();

        if (this.gameObject.name == "Spatula" && collision.gameObject.name == "Elenmayer_Medium_AquadesBeforeAduk")
            if (Save.GetCurrentProgres("Stage2") == 2)
                story.NgadukJeda();

        if (this.gameObject.name == "Elenmayer_Medium_AquadesAfterAduk" && collision.gameObject.name == "Autoclave")
            if (Save.GetCurrentProgres("Stage2") == 3)
                story.MasukAutoClave();

        if (this.gameObject.name == "AquadesAfter" && collision.gameObject.name == "Kulkas")
            if (Save.GetCurrentProgres("Stage2") == 4)
                story.MasukKulkas();
    }
}
