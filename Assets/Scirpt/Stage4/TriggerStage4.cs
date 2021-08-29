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
            story.AquadesToTabungUkur();

        if (collision.gameObject.name == "sample3tabungNonAnimKosong")
            story.TabungUkurToTabungReaksi();
    }
}
