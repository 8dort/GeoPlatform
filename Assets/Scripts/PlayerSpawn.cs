using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Transform spawnPoint; // Spawn noktasý referansý

    void Start()
    {
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position; // Karakteri spawn noktasýna taþý
        }
        else
        {
            Debug.LogError("SpawnPoint atanmadý! Lütfen bir SpawnPoint nesnesi oluþtur.");
        }
    }
}
