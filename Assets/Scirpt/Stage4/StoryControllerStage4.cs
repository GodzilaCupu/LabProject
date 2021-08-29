using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryControllerStage4 : MonoBehaviour
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

    private void ResetProgres()
    {
        Save.DelateKey("Stage4");
    }

    #region Step

    //step 1
    public void AquadesToTabungUkur()
    {
        objectTrigger[0].SetActive(false);
        objectTrigger[1].SetActive(false);

        objectsAnim[0].SetActive(true);
        anim[0].SetBool("AquadesTabungUkur", true);

        Save.SetCurrentProgres("Stage4", 1);
        task.ChangeColor();

        StartCoroutine(AquadesJeda(4));
        Debug.Log("berhasil");
    }

    //step 2
    public void TabungUkurToTabungReaksi()
    {
        objectTrigger[2].SetActive(false);
        objectTrigger[3].SetActive(false);

        objectTrigger[4].SetActive(true);
        Save.SetCurrentProgres("Stage4", 2);
        task.ChangeColor();
    }



    #endregion
    IEnumerator AquadesJeda(int sec)
    {
        yield return new WaitForSeconds(sec);
        objectsAnim[0].SetActive(false);
        objectTrigger[2].SetActive(true);
    }
}
