using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStage3 : MonoBehaviour
{
    [SerializeField] private GameObject tabungReaksiKosong, tabungReaksiSample, tabungReaksiCampuran,aquadesAnim,aquades,tabungUkurTrigger_1, tabungUkurTrigger_2, isiTabungUkur;

    Task_Content task;
    BTN_Controller btnSetting;
    StoryControllerStage3 story3;
    private void Start()
    {
        tabungReaksiKosong = GameObject.Find("TabungKosong");
        GameObject _gamemanager = GameObject.Find("GameManager");

        btnSetting = _gamemanager.GetComponent<BTN_Controller>();
        story3 = _gamemanager.GetComponent<StoryControllerStage3>();
        task = _gamemanager.GetComponent<Task_Content>();

        if(Save.GetCurrentProgres("Stage3") <= 2 )
            tabungReaksiSample.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == Save.GetSample("Sample"))
        {
            if ( Save.GetCurrentProgres("Stage3") == 1)
            {
                tabungReaksiKosong.SetActive(false);
                tabungReaksiSample.SetActive(true);

                GameObject piring = GameObject.Find(Save.GetSample("Sample"));
                piring.SetActive(false);
                Save.SetCurrentProgres("Stage3", 2);
                task.ChangeColor();

                Debug.LogWarning("Berhasil");
                Debug.LogWarning("Save terbaru" + Save.GetCurrentProgres("Stage3"));
            }
        }

        if (collision.gameObject.name == "AquadesnonAnim")
        {
            if(Save.GetCurrentProgres("Stage3") == 2)
            {
                aquades.SetActive(false);
                aquadesAnim.SetActive(true);

                Save.SetCurrentProgres("Stage3", 3);
                task.ChangeColor();

                story3.anim.SetBool("Squeze", true);
                StartCoroutine(waitTabungReaksiIsi());

                Debug.LogWarning("Save terbaru" + Save.GetCurrentProgres("Stage3"));

            }
            
        }

        if (collision.gameObject.name == "TabungUkurnonAnim_2")
        {
            if (Save.GetCurrentProgres("Stage3") == 3)
            {
                tabungReaksiCampuran.SetActive(true);
                tabungUkurTrigger_2.SetActive(false);

                Save.SetCurrentProgres("Stage3", 4);
                task.ChangeColor();

                Debug.LogWarning("Save terbaru" + Save.GetCurrentProgres("Stage3"));
            }
        }
    }

    IEnumerator waitTabungReaksiIsi()
    {
        yield return new WaitForSeconds(3);
        tabungUkurTrigger_1.SetActive(false);
        tabungReaksiSample.SetActive(true);
        tabungUkurTrigger_2.SetActive(true);
        aquadesAnim.SetActive(false);
    }
}
