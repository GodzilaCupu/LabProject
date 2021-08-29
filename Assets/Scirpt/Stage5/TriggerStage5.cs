using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStage5 : MonoBehaviour
{
    StoryControllerStage5 story;

    // Start is called before the first frame update
    void Start()
    {
        GameObject _gameManager = GameObject.Find("GameManager");
        story = _gameManager.GetComponent<StoryControllerStage5>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "kompor")
            if (Save.GetCurrentProgres("Stage5") == 0)
            {
                story.ElenmayerToHeater();
                Debug.Log("Berhasil 2");
            }



    }
}
