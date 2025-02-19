using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Transform spawnPoint; // Spawn noktas� referans�

    void Start()
    {
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position; // Karakteri spawn noktas�na ta��
        }
        else
        {
            Debug.LogError("SpawnPoint atanmad�! L�tfen bir SpawnPoint nesnesi olu�tur.");
        }
    }
}
