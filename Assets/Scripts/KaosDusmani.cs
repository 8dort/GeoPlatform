using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaosDusmani : MonoBehaviour
{
    public bool canChase = false; // Takip �zelli�i
    public bool canJump = false; // Z�plama �zelli�i
    public bool canPatrol = false; // Gidip gelme �zelli�i

    public Transform player;
    public float speed = 2f;
    public float detectionRange = 5f;

    public float jumpForce = 5f;
    public float jumpInterval = 2f;
    private float jumpTimer;

    public Transform pointA, pointB;
    private Transform target;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTimer = jumpInterval;
        target = pointB; // E�er devriye modundaysa ilk noktay� ata
    }

    void Update()
    {
        if (canChase) ChasePlayer();
        if (canJump) Jumping();
        if (canPatrol) Patrol();
    }

    void ChasePlayer()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // E�er oyuncu belirlenen mesafe i�inde ise sadece X ekseninde takip et
        if (distance < detectionRange)
        {
            Vector2 targetPosition = new Vector2(player.position.x, transform.position.y); // Y sabit kalacak
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    void Jumping()
    {
        jumpTimer -= Time.deltaTime;
        if (jumpTimer <= 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpTimer = jumpInterval;
        }
    }

    void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            target = target == pointA ? pointB : pointA;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerSpawn>().Respawn();
        }
    }
}
