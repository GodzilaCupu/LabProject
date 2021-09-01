using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject[] menu;

    [Header("Main Menu")]
    [SerializeField] private GameObject panelMainMenu;
    [SerializeField] private string[] _textMainMenu;
    [SerializeField] private Text[] textMainMenu;
    [SerializeField] private Button[] btnMainMenu;

    [Header("Mini Game Level")]
    [SerializeField] private GameObject panelMiniGame;
    [SerializeField] private string[] _textMiniGame;
    [SerializeField] private Text[] textMiniGame;
    [SerializeField] private Button[] btnMiniGame;

    [Header("Level Menu")]
    [SerializeField] private GameObject panelLevelMenu;
    [SerializeField] private string[] _textLevelMenu;
    [SerializeField] private Text[] textLevelMenu,descLevelMenu;
    [SerializeField] private Button[] btnLevelMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
