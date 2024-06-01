using UnityEngine;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    [HideInInspector] public bool Easy, Normal, Hard, GamemodeChosen;
    [HideInInspector] public int LvlMode;

    [SerializeField] private GameObject easyModeLvl;
    [SerializeField] private GameObject normalModeLvl;
    [SerializeField] private GameObject hardModeLvl;
    [Space]
    [SerializeField] private GameObject inGameMenuCanvas;
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject choosingGameModeCanvas;
    [Space]
    [SerializeField] private TimerCounter timer;
    public void GamemodeEasy()
    {
        LvlMode = 1;

        choosingGameModeCanvas.SetActive(false);
        easyModeLvl.SetActive(true);
        inGameMenuCanvas.SetActive(true);
        
        StartCoroutine(timer.StartGame(LvlMode));
        Debug.Log("Easy");
    }
    public void GamemodeNormal()
    {
        LvlMode = 2;

        choosingGameModeCanvas.SetActive(false);
        normalModeLvl.SetActive(true);
        inGameMenuCanvas.SetActive(true);

        StartCoroutine(timer.StartGame(LvlMode));
        Debug.Log("Medium");
    }

    public void GamemodeHard()
    {
        LvlMode = 3;

        choosingGameModeCanvas.SetActive(false);
        hardModeLvl.SetActive(true);
        inGameMenuCanvas.SetActive(true);
        
        StartCoroutine(timer.StartGame(LvlMode));
        Debug.Log("Hard");
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Continue()
    {
        Time.timeScale = 1;
    }
    public void LeaveToMainMenu()
    {
        easyModeLvl.SetActive(false);
        normalModeLvl.SetActive(false);
        hardModeLvl.SetActive(false);
        inGameMenuCanvas.SetActive(false);
        choosingGameModeCanvas.SetActive(false);

        mainMenuCanvas.SetActive(true);
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
