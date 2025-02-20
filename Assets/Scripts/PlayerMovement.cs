using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float dashSpeed = 15f; // Dash h�z�
    public float dashDuration = 0.2f; // Dash s�resi
    public float dashCooldown = 1f; // Dash'in tekrar kullan�lma s�resi

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isDashing;
    private bool canDash = true;

    private float moveInput;

    public Button leftButton;
    public Button rightButton;
    public Button jumpButton;
    public Button dashButton; // Dash butonu

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bile�enini al

        // Butonlara t�klan�nca hareketi ayarla
        leftButton.onClick.AddListener(() => moveInput = -1);
        rightButton.onClick.AddListener(() => moveInput = 1);
        jumpButton.onClick.AddListener(Jump);
        dashButton.onClick.AddListener(() => StartCoroutine(Dash())); // Dash butonu ekledik
    }

    void Update()
    {
        if (!isDashing) // E�er dash atm�yorsak normal hareket
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    IEnumerator Dash()
    {
        if (!canDash) yield break; // E�er dash cooldown'daysa, ��k
        canDash = false;
        isDashing = true;

        float originalGravity = rb.gravityScale; // Yer�ekimini kaydet
        rb.gravityScale = 0; // Yer�ekimini kapat (Dash s�ras�nda havada s�z�lebilsin)

        rb.velocity = new Vector2(moveInput * dashSpeed, 0f); // Dash h�z�n� uygula
        yield return new WaitForSeconds(dashDuration); // Dash s�resince bekle

        rb.gravityScale = originalGravity; // Yer�ekimini eski haline getir
        isDashing = false; // Dash bitti
        yield return new WaitForSeconds(dashCooldown); // Dash cooldown s�resi
        canDash = true; // Tekrar dash at�labilir
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
