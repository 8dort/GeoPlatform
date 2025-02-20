using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerSpawn playerSpawn = other.GetComponent<PlayerSpawn>();

        if (playerSpawn != null) // E�er �arp��an nesne PlayerSpawn i�eriyorsa
        {
            playerSpawn.Respawn(); // Oyuncuyu spawn noktas�na geri d�nd�r
        }
    }
}
