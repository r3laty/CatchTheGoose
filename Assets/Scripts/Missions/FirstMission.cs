using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class FirstMission : MonoBehaviour, IMissionable
{
    [SerializeField] private string description = "Catch the goose";

    [SerializeField] private int needToEarn = 1;
    [SerializeField] private int reward = 100;
    [Space]
    [SerializeField] private TextMeshProUGUI missionText;
    [SerializeField] private Button earnButton;
    [Space]
    [SerializeField] private GooseCoin coinsBank;

    private Missions _missions;
    private int _current;
    private string _missionDescription = "Cath the goose";
    private void Awake()
    {
        _missions = GetComponent<Missions>();
    }
    private void OnEnable()
    {
        Spawner.Caught += OnCatche;
    }
    private void OnCatche()
    {
        _current++;
    }
    private void UpdateTask(string newMissionDescription, int newGooseAmount)
    {
        _missionDescription = newMissionDescription;
        missionText.text = _missionDescription;

        needToEarn = newGooseAmount;
    }
    public void Execute()
    {
        if (_current >= needToEarn)
        {
            coinsBank.AddToken(reward);
            _current = 0;

            UpdateTask("Cath three gooses", 3);
        }
        _missions.StartMissionOne = false;
    }
    private void OnDisable()
    {
        Spawner.Caught -= OnCatche;
    }
}
