using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public Transform spawnPoint; // Spawn noktas�
    public float deathYLevel = -10f; // �lme seviyesi
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody bile�enini al
    }

    void Update()
    {
        // E�er karakter belirlenen Y seviyesinin alt�na d��erse
        if (transform.position.y < deathYLevel)
        {
            Respawn(); // Spawn noktas�na ���nla
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // E�er �arpt��� obje "Trap" (engel) tagine sahipse
        if (other.CompareTag("Trap"))
        {
            Respawn(); // Spawn noktas�na ���nla
        }
    }

    void Respawn()
    {
        transform.position = spawnPoint.position; // Spawn noktas�na ���nla
        rb.velocity = Vector2.zero; // Hareketi s�f�rla (tak�lmalar� engelle)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
