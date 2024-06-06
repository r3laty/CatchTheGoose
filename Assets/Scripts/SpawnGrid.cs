using UnityEngine;

public class SpawnGrid : MonoBehaviour
{
    public int GidSize = 3;
    public float CellSize = 1;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        for (int x = 0; x < GidSize; x++)
        {
            for (int z = 0; z < GidSize; z++)
            {
                Vector3 spawnPoint = transform.position + new Vector3(x * CellSize, 0f, z * CellSize);
                Gizmos.DrawWireCube(spawnPoint, Vector3.one * CellSize);
            }
        }
    }
}
