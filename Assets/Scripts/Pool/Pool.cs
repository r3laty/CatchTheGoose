using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool Instance;
    private void Start()
    {
        Instance = this;
    }
    public GooseConfig PoolInstatiate(GooseConfig objectToInstatiate, Vector3 spawnPoint)
    {
        GooseConfig goose = objectToInstatiate;
        goose.gameObject.SetActive(true);
        goose.transform.position = spawnPoint;

        return goose;
    }
    public GooseConfig PoolDestroy(GooseConfig objectToRemove)
    {
        GooseConfig goose = objectToRemove;
        goose.gameObject.SetActive(false);

        return goose;
    }
}
