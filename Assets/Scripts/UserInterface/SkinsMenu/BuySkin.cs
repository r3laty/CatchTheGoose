using UnityEngine;

public class BuySkin : MonoBehaviour
{
    [SerializeField] private GooseCoin coinController;
    [Space]
    [SerializeField] private Spawner[] allGameModes;
    [SerializeField] private GooseConfig[] allGooseSkins;

    private int _skinId;
    public void Buy(int price)
    {
        if (price <= coinController.CoinAmount)
        {
            coinController.SpendMoney(price);
            Debug.Log("Buy skin");
        }
        else
        {
            Debug.Log("Not enought money");
        }
    }
    public void SetCurrentId(int skinId)
    {
        _skinId = skinId;

        SetCurrentSkin();
    }
    private void SetCurrentSkin()
    {
        if (_skinId != 0)
        {
            foreach (var gameMode in allGameModes)
            {
                allGooseSkins[_skinId - 1].gameObject.SetActive(false);
                gameMode.NewSkin = allGooseSkins[_skinId];
            }
            _skinId = 0;
        }
    }
}
