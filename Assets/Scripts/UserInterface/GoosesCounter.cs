using TMPro;
using UnityEngine;

public class GoosesCounter : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [Space]
    [SerializeField] private TextMeshProUGUI gooseCountText;
    
    private int _count;
    private void OnEnable()
    {
        Spawner.Caught += OnCatche;
    }
    private void OnCatche()
    {
        _count++;
        gooseCountText.text = "Gooses count: " + _count;
    }
    private void UpdateCountText(int newCount)
    {
        gooseCountText.text = newCount.ToString();
    }
    private void OnDisable()
    {
        _count = 0;
        gooseCountText.text = "Gooses count: " + _count;

        print("On disable (count " + _count + ')');
        Spawner.Caught -= OnCatche;
    }
}
