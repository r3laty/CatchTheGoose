using TMPro;
using UnityEngine;

public class GooseCoin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinCountText;

    private int _coinCount;
    private void OnEnable()
    {
        Spawner.Caught += OnCatche;
    }
    private void OnCatche()
    {
        _coinCount++;
        coinCountText.text = _coinCount.ToString();
    }
    private void OnDisable()
    {
        _coinCount = 0;
        Spawner.Caught += OnCatche;
    }
}
