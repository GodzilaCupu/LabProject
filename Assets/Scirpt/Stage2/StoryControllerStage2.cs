using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryControllerStage2 : MonoBehaviour
{
    [Header("Object Animasi")]
    [SerializeField] private GameObject[] objectsAnim;
    [Header("Object Trigger")]
    [SerializeField] private GameObject[] objectTrigger;
    [Header("Animator")]
    [SerializeField] private Animator[] anim;

    Task_Content task;

    private void Start()
    {
        GameObject _gameManager = GameObject.Find("GameManager");
        task = _gameManager.GetComponent<Task_Content>();
        ResetProgres();

        Save.SetCurrentLevel("Level", 2);
    }

    #region Step

    //Step1


    #endregion

    private void ResetProgres()
    {
        Save.DelateKey("Stage2");
    }
}
