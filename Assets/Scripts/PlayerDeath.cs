using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public Transform spawnPoint; // Spawn noktasý
    public float deathYLevel = -10f; // Ölme seviyesi
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody bileþenini al
    }

    void Update()
    {
        // Eðer karakter belirlenen Y seviyesinin altýna düþerse
        if (transform.position.y < deathYLevel)
        {
            Respawn(); // Spawn noktasýna ýþýnla
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Eðer çarptýðý obje "Trap" (engel) tagine sahipse
        if (other.CompareTag("Trap"))
        {
            Respawn(); // Spawn noktasýna ýþýnla
        }
    }

    void Respawn()
    {
        transform.position = spawnPoint.position; // Spawn noktasýna ýþýnla
        rb.velocity = Vector2.zero; // Hareketi sýfýrla (takýlmalarý engelle)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
