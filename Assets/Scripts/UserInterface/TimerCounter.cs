using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerCounter : MonoBehaviour
{
    [SerializeField] private List<Spawner> spawners;
    [Space]
    [SerializeField] private TextMeshProUGUI timerText;
    [Space]
    //[SerializeField] private GameObject theEndMenu;

    private float _currentTime = 0;
    private int _currentGameMode;
    private string _modeTextPattern;

    public IEnumerator StartGame(int currentGameMode)
    {
        _currentGameMode = currentGameMode - 1;
        Debug.Log("Start game coroutine");
        switch (currentGameMode)
        {
            case 1: _modeTextPattern = "Easy mode, time left " + _currentTime.ToString() + " sec";
                break;
            case 2: _modeTextPattern = "Normal mode, time left " + _currentTime.ToString() + " sec";
                break;
            case 3: _modeTextPattern = "Hard mode, time left " + _currentTime.ToString() + " sec";
                break;
        }

        _currentTime = spawners[_currentGameMode].GameDuration;
        StartCoroutine(spawners[_currentGameMode].SpawnGoosesWithDelay());

        while (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
            UpdateTimerText(timerText, _modeTextPattern);
            yield return null;
        }
    }
    private void UpdateTimerText(TextMeshProUGUI tmpText, string textTemplate)
    {
        Debug.Log(_currentTime.ToString() + " Timer");
        tmpText.text = textTemplate;
    }
    private void OnDisable()
    {
        _currentTime = 0;
        StopAllCoroutines();
    }
}
