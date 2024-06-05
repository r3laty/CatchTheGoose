using TMPro;
using UnityEngine;

public class GooseCoin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinCountText;

    private int _coinCount;
    private void OnEnable()
    {
        print("Goose coin script on " + this.gameObject.name);
        Spawner.Caught += OnCatche;
    }
    private void OnCatche()
    {
        _coinCount++;
        UpdateCoinsText(_coinCount);
    }
    private void UpdateCoinsText(int amount)
    {
        coinCountText.text = amount.ToString();
    }
    public void AddToken(int amount)
    {
        _coinCount += amount;
        UpdateCoinsText(_coinCount);
    }
    private void OnDisable()
    {
        _coinCount = 0;
        UpdateCoinsText(_coinCount);

        print("On disable (coin count " + _coinCount + ')');
        Spawner.Caught -= OnCatche;
    }
}
