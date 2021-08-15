using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiringTringger : MonoBehaviour
{
    [SerializeField] private GameObject tabungKosong, tabungSample, _story3;

    StoryControllerStage3 story3;
    private void Start()
    {
        tabungKosong = GameObject.Find("TabungKosong");
        tabungSample = GameObject.Find("TabungSample");

        _story3 = GameObject.Find("GameManager");
        story3 = _story3.GetComponent<StoryControllerStage3>();

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
            Debug.LogWarning("Berhasil");
        }

        if (collision.gameObject.name == "TabungUkur")
        {
            Save.SetCurrentProgres("Stage3", 3);
            story3.anim.SetTrigger("Squeze");

        }
    }
}
