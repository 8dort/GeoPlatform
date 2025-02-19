using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Transform spawnPoint; // Spawn noktasý
    public float deathYLevel = -10f; // Ölme seviyesi

    void Update()
    {
        // Eðer karakter belirlenen Y seviyesinin altýna düþerse
        if (transform.position.y < deathYLevel)
        {
            Respawn(); // Respawn çaðýr
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Eðer çarptýðý obje "Trap" (veya baþka bir ölümcül obje) tagine sahipse
        if (other.CompareTag("Trap"))
        {
            Respawn(); // Yeniden doðma fonksiyonunu çaðýr
        }
    }

    void Respawn()
    {
        transform.position = spawnPoint.position; // Spawn noktasýna ýþýnla
        GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Hýzý sýfýrla (Yere düþme devam etmesin)
    }
}
