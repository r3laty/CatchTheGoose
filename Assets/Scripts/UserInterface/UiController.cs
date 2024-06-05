using UnityEngine;
using UnityEngine.SocialPlatforms;

public class UiController : MonoBehaviour
{
    [HideInInspector] public int LvlMode;

    [SerializeField] private GameObject easyModeLvl;
    [SerializeField] private GameObject normalModeLvl;
    [SerializeField] private GameObject hardModeLvl;
    [Space]
    [SerializeField] private GameObject inGameMenuCanvas;
    [SerializeField] private GameObject staticInGameMenuCanvas;
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject choosingGameModeCanvas;
    [Space]
    [SerializeField] private GameObject theEndMenu;
    [Space]
    [SerializeField] private TimerCounter timer;
    public void GamemodeEasy()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
        LvlMode = 1;

        choosingGameModeCanvas.SetActive(false);
        easyModeLvl.SetActive(true);
        inGameMenuCanvas.SetActive(true);
        staticInGameMenuCanvas.SetActive(true);

        StartCoroutine(timer.StartGame(LvlMode));
        Debug.Log("Easy, Timescale " + Time.timeScale);
    }
    public void GamemodeNormal()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
        LvlMode = 2;

        choosingGameModeCanvas.SetActive(false);
        normalModeLvl.SetActive(true);
        inGameMenuCanvas.SetActive(true);
        staticInGameMenuCanvas.SetActive(true);

        StartCoroutine(timer.StartGame(LvlMode));
        Debug.Log("Medium, Time.timeScale" + Time.timeScale);
    }

    public void GamemodeHard()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
        LvlMode = 3;

        choosingGameModeCanvas.SetActive(false);
        hardModeLvl.SetActive(true);
        inGameMenuCanvas.SetActive(true);
        staticInGameMenuCanvas.SetActive(true);

        StartCoroutine(timer.StartGame(LvlMode));
        Debug.Log("Hard, Timescale " + Time.timeScale);
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Continue()
    {
        Time.timeScale = 1;
    }
    public void TryAgain()
    {
        easyModeLvl.SetActive(false);
        normalModeLvl.SetActive(false);
        hardModeLvl.SetActive(false);
        inGameMenuCanvas.SetActive(false);
        choosingGameModeCanvas.SetActive(false);
        theEndMenu.SetActive(false);
        staticInGameMenuCanvas.SetActive(false);

        mainMenuCanvas.SetActive(true);
    }
}
