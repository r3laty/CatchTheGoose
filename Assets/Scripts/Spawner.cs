using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static event Action Caught;
    public float GameDuration
    {
        get
        {
            return gameDuration;
        }
        private set
        {
            gameDuration = value;
        }
    }
    public GooseConfig NewSkin
    {
        get
        {
            return goose;
        }
        set
        {
            goose = value;
        }
    }

    [SerializeField] private GooseConfig goose;
    [Space]
    [SerializeField] private SpawnGrid spawnGrid;
    [Space]
    [SerializeField] private float spawnInterval;
    [Space]
    [SerializeField] private float gameDuration;

    private List<GooseConfig> _spawnedObjects = new List<GooseConfig>();
    private void Start()
    {
        GameDuration = gameDuration;

        if (NewSkin != null)
        {
            goose = NewSkin;
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;
                if (clickedObject.CompareTag("Finish"))
                {
                    if (clickedObject.TryGetComponent<GooseConfig>(out GooseConfig goose))
                    {
                        Caught?.Invoke();
                        _spawnedObjects.Remove(goose);
                        Pool.Instance.PoolDestroy(goose);
                    }
                }
            }
        }
    }
    public IEnumerator SpawnGoosesWithDelay()
    {
        for (int x = 0; x < int.MaxValue; x++)
        {
            for (int z = 0; z < int.MaxValue; z++)
            {
                int randomX = UnityEngine.Random.Range(0, spawnGrid.GidSize);
                int randomZ = UnityEngine.Random.Range(0, spawnGrid.GidSize);

                Vector3 spawnPoint = transform.position + new Vector3(randomX * spawnGrid.CellSize, 0f, randomZ * spawnGrid.CellSize);

                GooseConfig newGoose = Pool.Instance.PoolInstatiate(goose, spawnPoint);

                _spawnedObjects.Add(newGoose);

                if (_spawnedObjects.Count > 1)
                {
                    int randomIndex = UnityEngine.Random.Range(0, _spawnedObjects.Count - 1);
                    GooseConfig objectToRemove = _spawnedObjects[randomIndex];
                    _spawnedObjects.RemoveAt(randomIndex);
                }
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }
}