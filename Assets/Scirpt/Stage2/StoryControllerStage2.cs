using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryControllerStage2 : MonoBehaviour
{
    [Header("Object Animasi")]
    // 0 = SpatulaMediumToErlenmayer; 2 = Nuang Auades;
    [SerializeField] private GameObject[] objectsAnim;
    [Header("Object Trigger")]
    // 0 = Spatula; 1 = Lactobrote; 2 = posisi spatula awal; 3 = ErelenmayerKosong; 4 = ErlenmayerPenuh; 5 = Timbangan;
    // 6 = aquades
    [SerializeField] private GameObject[] objectTrigger;
    private Vector3 posSpatula;
    [Header("Animator")]
    // 0 = SpatulaMediumToErlenmayer; 2 = Nuang Auades;
    [SerializeField] private Animator[] anim;

    Task_Congrats_Content task;
    BTN_Controller btn;

    private void Start()
    {
        GameObject _gameManager = GameObject.Find("GameManager");
        task = _gameManager.GetComponent<Task_Congrats_Content>();
        btn = _gameManager.GetComponent<BTN_Controller>();
        ResetProgres();

        posSpatula = new Vector3(objectTrigger[2].transform.position.x, objectTrigger[2].transform.position.y, objectTrigger[2].transform.position.z);

        Save.SetCurrentLevel("Level", 2);
    }

    #region Step

    //Step1
    public void SpatulaToMedium()
    {
        objectTrigger[0].SetActive(false);
        objectTrigger[1].SetActive(false);
        objectTrigger[3].SetActive(false);

        objectsAnim[0].SetActive(true);

        btn.PanelUIActive();
        Debug.Log("Works");
        StartCoroutine(SpatulaJeda(5));
        task.ChangeColor();
    }

    #endregion

    IEnumerator SpatulaJeda(int sec)
    {
        Debug.Log("Work 2");
        anim[0].SetBool("AmbilMedium", true);

        yield return new WaitForSeconds(sec);

        objectsAnim[0].SetActive(false);

        objectTrigger[0].SetActive(true);
        objectTrigger[0].transform.position = posSpatula;
        objectTrigger[4].SetActive(true);

        Debug.Log("Work 1");

        Save.SetCurrentProgres("Stage2", 1);
        btn.PanelUINonActive();
    }

    private void ResetProgres()
    {
        Save.DelateKey("Stage2");
    }
}
