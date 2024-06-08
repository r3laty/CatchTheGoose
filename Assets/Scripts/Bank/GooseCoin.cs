using TMPro;
using UnityEngine;

public class GooseCoin : MonoBehaviour
{
    public int CoinAmount { get; private set; }
    
    [SerializeField] private int maxCoinCount;
    [SerializeField] private TextMeshProUGUI coinCountText;
    private void Start()
    {
        CoinAmount = maxCoinCount;
    }
    private void OnEnable()
    {
        Spawner.Caught += OnCatche;
    }
    private void OnCatche()
    {
        CoinAmount++;
        UpdateCoinsText(CoinAmount);
    }
    private void UpdateCoinsText(int amount)
    {
        coinCountText.text = amount.ToString();
    }
    public void AddToken(int amount)
    {
        CoinAmount += amount;
        UpdateCoinsText(CoinAmount);
    }
    public void SpendMoney(int amount)
    {
        CoinAmount -= amount;
        UpdateCoinsText(CoinAmount);
    }
    private void OnDisable()
    {
        CoinAmount = 0;
        UpdateCoinsText(CoinAmount);

        Spawner.Caught -= OnCatche;
    }
}
