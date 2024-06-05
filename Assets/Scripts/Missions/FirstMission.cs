using UnityEngine;
public class FirstMission : MonoBehaviour, IMissionable
{
    [SerializeField] private string description = "Catch the goose";

    [SerializeField] private int needToEarn = 1;
    [SerializeField] private int reward = 100;
    [Space]
    [SerializeField] private GooseCoin coinsBank;

    private int _current;
    private void OnEnable()
    {
        Spawner.Caught += OnCatche;
    }
    private void OnCatche()
    {
        _current++;
    }

    public void Execute()
    {
        if (_current >= needToEarn)
        {
            coinsBank.AddToken(reward);
            _current = 0;
            Spawner.Caught -= OnCatche;
        }
    }
}
