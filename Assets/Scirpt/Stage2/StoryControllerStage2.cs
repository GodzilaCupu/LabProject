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
    // 6 = aquades; 7 = Tabung Ukur Kosong; 8 = Tabung Ukur Penuh
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

    private void Update()
    {
        Debug.Log("Progress " + Save.GetCurrentProgres("Stage2"));
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

        Save.SetCurrentProgres("Stage2", 1);
        task.ChangeColor();

        StartCoroutine(SpatulaJeda(5));
    }

    //Step
    public void TuangAquades()
    {
        objectTrigger[6].SetActive(false);
        objectTrigger[7].SetActive(false);

        objectsAnim[1].SetActive(true);
        btn.PanelUIActive();

        StartCoroutine(NuangJeda(5));
    }

    //Step2
    public void MasukAquadesToSample()
    {
        objectTrigger[3].SetActive(false);
        objectTrigger[4].SetActive(false);
        objectTrigger[8].SetActive(false);

        objectsAnim[2].SetActive(true);
        btn.PanelUIActive();

        Save.SetCurrentProgres("Stage2", 2);
        task.ChangeColor();

        StartCoroutine(MasukAquadesJeda(5));
    }

    //Step3
    public void NgadukJeda()
    {
        objectTrigger[0].SetActive(false);
        objectTrigger[9].SetActive(false);

        objectsAnim[3].SetActive(true);
        btn.PanelUIActive();

        Save.SetCurrentProgres("Stage2", 3);
        task.ChangeColor();

        StartCoroutine(NgadukJeda(6));
    }

    //Step4
    public void MasukAutoClave()
    {
        objectTrigger[10].SetActive(false);
        objectTrigger[11].SetActive(false);

        objectsAnim[4].SetActive(true);
        btn.PanelUIActive();

        Save.SetCurrentProgres("Stage2", 4);
        task.ChangeColor();

        StartCoroutine(MasukAutoclaveJeda(5));
    }

    //Step5
    public void MasukKulkas()
    {
        objectTrigger[12].SetActive(false);
        objectTrigger[13].SetActive(false);

        objectsAnim[6].SetActive(true);
        btn.PanelUIActive();

        StartCoroutine(KulkasJeda(5));
    }
    #endregion

    #region IEnumClass
    IEnumerator SpatulaJeda(int sec)
    {
        anim[0].SetBool("AmbilMedium", true);

        yield return new WaitForSeconds(sec);

        objectsAnim[0].SetActive(false);

        objectTrigger[0].SetActive(true);
        objectTrigger[0].transform.position = posSpatula;
        objectTrigger[4].SetActive(true);

        btn.PanelUINonActive();
    }

    IEnumerator NuangJeda(int sec)
    {
        anim[1].SetBool("TuangAquades", true);

        yield return new WaitForSeconds(sec);
        objectsAnim[1].SetActive(false);

        objectTrigger[8].SetActive(true);
        btn.PanelUINonActive();
    }

    IEnumerator MasukAquadesJeda(int sec)
    {
        anim[2].SetBool("ErlenmayerToAquades", true);

        yield return new WaitForSeconds(sec);
        objectsAnim[2].SetActive(false);

        objectTrigger[9].SetActive(true);
        btn.PanelUINonActive();
    }
    
    IEnumerator NgadukJeda(int sec)
    {
        anim[3].SetBool("Aduk", true);

        yield return new WaitForSeconds(sec);
        objectsAnim[3].SetActive(false);

        objectTrigger[10].SetActive(true);
        btn.PanelUINonActive();
    }

    IEnumerator MasukAutoclaveJeda(int sec)
    {
        anim[4].SetBool("MasukAutoclave", true);

        yield return new WaitForSeconds(sec);
        objectsAnim[5].SetActive(true);
        anim[5].SetBool("24Hour", true);

        yield return new WaitForSeconds(sec);
        objectsAnim[5].SetActive(false);
        anim[4].SetBool("MasukAutoclave", false);

        yield return new WaitForSeconds(sec);
        objectsAnim[4].SetActive(false);

        objectTrigger[11].SetActive(true);
        objectTrigger[12].SetActive(true);

        btn.PanelUINonActive();
    }

    IEnumerator KulkasJeda(int sec)
    {
        anim[6].SetBool("MasukKulkas", true);
        yield return new WaitForSeconds(sec);

        objectsAnim[6].SetActive(false);
        objectTrigger[13].SetActive(true);
        Save.SetCurrentProgres("Stage2", 5);
        task.ChangeColor();

        btn.PanelUINonActive();
    }
    #endregion

    private void ResetProgres()
    {
        Save.DelateKey("Stage2");
    }
}
