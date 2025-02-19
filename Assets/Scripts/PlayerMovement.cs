using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isGrounded;

    private float moveInput;

    public Button leftButton;
    public Button rightButton;
    public Button jumpButton;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileþenini al

        // Butonlara týklanýnca hareketi ayarla
        leftButton.onClick.AddListener(() => moveInput = -1);
        rightButton.onClick.AddListener(() => moveInput = 1);
        jumpButton.onClick.AddListener(Jump);
    }

    void Update()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
