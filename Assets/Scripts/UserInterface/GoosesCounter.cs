using TMPro;
using UnityEngine;

public class GoosesCounter : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [Space]
    [SerializeField] private TextMeshProUGUI gooseCountText;
    [SerializeField] private TextMeshProUGUI coinCountText;
    
    private int _count;
    private void OnEnable()
    {
        Spawner.Caught += OnCatche;
    }
    private void OnCatche()
    {
        _count++;
        gooseCountText.text = "Gooses count: " + _count.ToString();
        coinCountText.text = _count.ToString();
    }
    private void OnDisable()
    {
        _count = 0;
        Spawner.Caught += OnCatche;
    }
}
