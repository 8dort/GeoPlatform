using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaosSekli : MonoBehaviour
{
    public float speed = 3f; // Hareket hýzý
    public float moveDistance = 5f; // Gidip gelecek toplam mesafe

    private Vector3 startPos;
    private int direction = 1; // Baþlangýç yönü

    void Start()
    {
        startPos = transform.position; // Baþlangýç konumunu kaydet
    }

    void Update()
    {
        // Nesneyi ileri-geri hareket ettir
        transform.position += Vector3.right * direction * speed * Time.deltaTime;

        // Eðer belirlenen mesafeye ulaþtýysa yön deðiþtir
        if (Vector3.Distance(startPos, transform.position) >= moveDistance)
        {
            direction *= -1; // Yönü tersine çevir
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerSpawn playerSpawn = other.GetComponent<PlayerSpawn>();

        if (playerSpawn != null) // Eðer çarpýþan nesne oyuncuysa
        {
            playerSpawn.Respawn(); // Oyuncuyu spawn noktasýna geri döndür
        }
    }
}
