using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA; // Ba�lang�� noktas�
    public Transform pointB; // Biti� noktas�
    public float speed = 2f; // Platformun hareket h�z�
    private Vector3 targetPosition; // Hedef nokta

    void Start()
    {
        targetPosition = pointB.position; // �lk hedef B noktas�
    }

    void Update()
    {
        // Platformu hedefe do�ru hareket ettir
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // E�er hedefe ula�t�ysa, y�n de�i�tir
        if (Vector3.Distance(transform.position, targetPosition) < 0.05f) // Daha hassas kontrol i�in 0.05f
        {
            targetPosition = (targetPosition == pointA.position) ? pointB.position : pointA.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform); // Oyuncuyu platforma ba�la
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null); // Oyuncuyu serbest b�rak
        }
    }
}
