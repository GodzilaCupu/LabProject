using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    private string[] _tutorialText;

    [Header ("Panel")]
    [SerializeField] private GameObject[] uiPanel;

    [Header("UI")]
    [SerializeField] private Animator anim;
    [SerializeField] private Text[] tutorialText;

    private void SetText()
    {
        _tutorialText = new string[10];
    }

}
