using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerSpawn playerSpawn = other.GetComponent<PlayerSpawn>();

        if (playerSpawn != null) // Eðer çarpýþan nesne PlayerSpawn içeriyorsa
        {
            playerSpawn.Respawn(); // Oyuncuyu spawn noktasýna geri döndür
        }
    }
}
