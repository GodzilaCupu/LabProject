using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiringTringger : MonoBehaviour
{
    [SerializeField] private GameObject tabungKosong, tabungSample;
    private void Start()
    {
        tabungKosong = GameObject.Find("TabungKosong");
        tabungSample = GameObject.Find("TabungSample");

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
    }
}
