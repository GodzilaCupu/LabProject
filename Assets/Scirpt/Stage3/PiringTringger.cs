using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiringTringger : MonoBehaviour
{
    [SerializeField] private GameObject tabungKosong, tabungSample;

    Task_Content task;
    StoryControllerStage3 story3;
    private void Start()
    {
        tabungKosong = GameObject.Find("TabungKosong");
        tabungSample = GameObject.Find("TabungSample");
        GameObject _gamemanager = GameObject.Find("GameManager");

        story3 = _gamemanager.GetComponent<StoryControllerStage3>();
        task = _gamemanager.GetComponent<Task_Content>();

        tabungSample.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == Save.GetSample("Sample"))
        {
            tabungKosong.SetActive(false);
            tabungSample.SetActive(true);

            GameObject piring = GameObject.Find(Save.GetSample("Sample"));
            piring.SetActive(false);
            Save.SetCurrentProgres("Stage3", 2);
            task.progres++;
            Debug.LogWarning(task.progres + "Progres2");


            Debug.LogWarning("Berhasil");
            Debug.LogWarning(Save.GetCurrentProgres("Stage3"));
        }

        if (collision.gameObject.name == "TabungUkur")
        {
            Save.SetCurrentProgres("Stage3", 3);
            task.progres++;
            Debug.LogWarning(task.progres + "Progres2");
            story3.anim.SetBool("Squeze",true);
            Debug.LogWarning(Save.GetCurrentProgres("Stage3"));


        }
    }
}
