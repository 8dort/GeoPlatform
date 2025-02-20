using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaosSekli : MonoBehaviour
{
    public float speed = 3f; // Hareket h�z�
    public float moveDistance = 5f; // Gidip gelecek toplam mesafe

    private Vector3 startPos;
    private int direction = 1; // Ba�lang�� y�n�

    void Start()
    {
        startPos = transform.position; // Ba�lang�� konumunu kaydet
    }

    void Update()
    {
        // Nesneyi ileri-geri hareket ettir
        transform.position += Vector3.right * direction * speed * Time.deltaTime;

        // E�er belirlenen mesafeye ula�t�ysa y�n de�i�tir
        if (Vector3.Distance(startPos, transform.position) >= moveDistance)
        {
            direction *= -1; // Y�n� tersine �evir
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerSpawn playerSpawn = other.GetComponent<PlayerSpawn>();

        if (playerSpawn != null) // E�er �arp��an nesne oyuncuysa
        {
            playerSpawn.Respawn(); // Oyuncuyu spawn noktas�na geri d�nd�r
        }
    }
}
