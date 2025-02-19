using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Transform spawnPoint; // Spawn noktas�
    public float deathYLevel = -10f; // �lme seviyesi

    void Update()
    {
        // E�er karakter belirlenen Y seviyesinin alt�na d��erse
        if (transform.position.y < deathYLevel)
        {
            Respawn(); // Respawn �a��r
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // E�er �arpt��� obje "Trap" (veya ba�ka bir �l�mc�l obje) tagine sahipse
        if (other.CompareTag("Trap"))
        {
            Respawn(); // Yeniden do�ma fonksiyonunu �a��r
        }
    }

    void Respawn()
    {
        transform.position = spawnPoint.position; // Spawn noktas�na ���nla
        GetComponent<Rigidbody2D>().velocity = Vector2.zero; // H�z� s�f�rla (Yere d��me devam etmesin)
    }
}
