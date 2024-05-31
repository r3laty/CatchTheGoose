using UnityEngine;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    [HideInInspector] public bool Easy, Normal, Hard, GamemodeChosen;
    [HideInInspector] public int LvlMode;


    [SerializeField] private TimerCounter timer;
    public void GamemodeEasy()
    {
        LvlMode = 1;
        StartCoroutine(timer.StartGame(LvlMode));
        Debug.Log("Easy");
    }
    public void GamemodeNormal()
    {
        LvlMode = 2;
        StartCoroutine(timer.StartGame(LvlMode));
        Debug.Log("Medium");
    }

    public void GamemodeHard()
    {
        LvlMode = 3;
        StartCoroutine(timer.StartGame(LvlMode));
        Debug.Log("Hard"); 
    }
    public void Pause() => Time.timeScale = 0;
    public void Continue() => Time.timeScale = 1;
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
