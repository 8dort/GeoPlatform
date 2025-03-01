using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA; // Baþlangýç noktasý
    public Transform pointB; // Bitiþ noktasý
    public float speed = 2f; // Platformun hareket hýzý
    private Vector3 targetPosition; // Hedef nokta

    void Start()
    {
        targetPosition = pointB.position; // Ýlk hedef B noktasý
    }

    void Update()
    {
        // Platformu hedefe doðru hareket ettir
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Eðer hedefe ulaþtýysa, yön deðiþtir
        if (Vector3.Distance(transform.position, targetPosition) < 0.05f) // Daha hassas kontrol için 0.05f
        {
            targetPosition = (targetPosition == pointA.position) ? pointB.position : pointA.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform); // Oyuncuyu platforma baðla
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null); // Oyuncuyu serbest býrak
        }
    }
}
