using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void Respawn()
    {
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position; // Karakteri tekrar spawn noktas�na ���nla
        }
        else
        {
            Debug.LogError("SpawnPoint atanmad�! Respawn i�lemi ba�ar�s�z.");
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}

