using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStage3 : MonoBehaviour
{
    StoryControllerStage3 story3;
    private void Start()
    {
        GameObject _gamemanager = GameObject.Find("GameManager");
        story3 = _gamemanager.GetComponent<StoryControllerStage3>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Ditaro Pada Tabung Reaksi
        if (collision.gameObject.name == Save.GetSample("Sample"))
            if (Save.GetCurrentProgres("Stage3") == 1)
                story3.PiringToTabungReaksi();

        if (collision.gameObject.name == "AquadesnonAnim")
            if (Save.GetCurrentProgres("Stage3") == 2)
                story3.AquadesToTabungUkur();

        if (collision.gameObject.name == "TabungUkurnonAnim_2")
            if (Save.GetCurrentProgres("Stage3") == 3)
                story3.TabungUkurPenuhToTabungReaksi();
    }


}
