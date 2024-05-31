using UnityEngine;

public class ChoosingGamemode : MonoBehaviour
{
    [SerializeField] private UiController uiController;
    [Header("LevelsMode")]
    [SerializeField] private GameObject easyModeLvl;
    [SerializeField] private GameObject normalModeLvl;
    [SerializeField] private GameObject hardModeLvl;
    private void Update()
    {
        if (uiController.LvlMode == 1)
        {
            easyModeLvl.SetActive(true); 
            Debug.Log("Easy mode");
        }

        if (uiController.LvlMode == 2)
        {
            normalModeLvl.SetActive(true); 
            Debug.Log("Normal mode");
        }
        if (uiController.LvlMode == 3)
        {
            hardModeLvl.SetActive(true); 
            Debug.Log("Hard mode");

        } 
    }
}
