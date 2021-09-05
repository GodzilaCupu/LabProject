using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStory2 : MonoBehaviour
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
        if (collision.gameObject.name == "Lactobrote")
            story.SpatulaToMedium();

    }
}
