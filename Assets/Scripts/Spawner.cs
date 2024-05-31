using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : GooseConfig
{
    public static event Action Caught;

    [HideInInspector] public bool IsGameStarted;

    public float GameDuration;
    [Space]
    [SerializeField] private SpawnGrid spawnGrid;

    private List<GameObject> _spawnedObjects = new List<GameObject>();

    private void Start()
    {
        IsGameStarted = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Get mouse button down");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;
                if (clickedObject.CompareTag("Finish"))
                {
                    Caught?.Invoke();
                    _spawnedObjects.Remove(clickedObject);
                    Destroy(clickedObject);
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
                int randomX = UnityEngine.Random.Range(0, spawnGrid.gridSize);
                int randomZ = UnityEngine.Random.Range(0, spawnGrid.gridSize);

                Vector3 spawnPoint = transform.position + new Vector3(randomX * spawnGrid.cellSize, 0f, randomZ * spawnGrid.cellSize);

                GameObject newGoose = Instantiate(Prefab, spawnPoint, Quaternion.identity);

                _spawnedObjects.Add(newGoose);

                if (_spawnedObjects.Count > 1)
                {
                    int randomIndex = UnityEngine.Random.Range(0, _spawnedObjects.Count - 1);
                    GameObject objectToRemove = _spawnedObjects[randomIndex];
                    _spawnedObjects.RemoveAt(randomIndex);
                    Destroy(objectToRemove);
                }
                yield return new WaitForSeconds(SpawnInterval);
            }
        }
    }

}