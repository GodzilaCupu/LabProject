using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryControllerStage5 : MonoBehaviour
{
    [Header("Object Animasi")]
    [SerializeField] private GameObject[] objectsAnim;
    [Header("Object Trigger")]
    [SerializeField] private GameObject[] objectTrigger;
    [Header("Animator")]
    [SerializeField] private Animator[] anim;

    Task_Content task;

    void Start()
    {
        GameObject _gameManager = GameObject.Find("GameManager");
        task = _gameManager.GetComponent<Task_Content>();

        Save.SetCurrentLevel("Level", 4);
        ResetProgres();
    }


    #region Step
    //Step1
    public void ElenmayerToHeater()
    {
        objectTrigger[0].SetActive(false);
        //kompoor
        objectTrigger[2].SetActive(false);
        objectsAnim[0].SetActive(true);
        anim[0].SetBool("Panasin", true);

        StartCoroutine(ElenmayerJeda(3));
        Save.SetCurrentProgres("Stage5", 1);
        task.ChangeColor();

        Debug.Log("Berhasil");
    }

    #endregion


    #region IEnumClass
    IEnumerator ElenmayerJeda(int sec)
    {
        yield return new WaitForSeconds(7);
        anim[0].SetBool("Panasin", false);
        Debug.Log("1");

        yield return new WaitForSeconds(sec);
        objectTrigger[1].SetActive(true);
        objectTrigger[2].SetActive(true);

        objectsAnim[0].SetActive(false);
        Debug.Log("2");


    }


    #endregion



    private void ResetProgres()
    {
        Save.DelateKey("Stage5");
    }
}
