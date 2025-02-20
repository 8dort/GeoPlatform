using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float dashSpeed = 15f; // Dash hýzý
    public float dashDuration = 0.2f; // Dash süresi
    public float dashCooldown = 1f; // Dash'in tekrar kullanýlma süresi

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
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileþenini al

        // Butonlara týklanýnca hareketi ayarla
        leftButton.onClick.AddListener(() => moveInput = -1);
        rightButton.onClick.AddListener(() => moveInput = 1);
        jumpButton.onClick.AddListener(Jump);
        dashButton.onClick.AddListener(() => StartCoroutine(Dash())); // Dash butonu ekledik
    }

    void Update()
    {
        if (!isDashing) // Eðer dash atmýyorsak normal hareket
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
        if (!canDash) yield break; // Eðer dash cooldown'daysa, çýk
        canDash = false;
        isDashing = true;

        float originalGravity = rb.gravityScale; // Yerçekimini kaydet
        rb.gravityScale = 0; // Yerçekimini kapat (Dash sýrasýnda havada süzülebilsin)

        rb.velocity = new Vector2(moveInput * dashSpeed, 0f); // Dash hýzýný uygula
        yield return new WaitForSeconds(dashDuration); // Dash süresince bekle

        rb.gravityScale = originalGravity; // Yerçekimini eski haline getir
        isDashing = false; // Dash bitti
        yield return new WaitForSeconds(dashCooldown); // Dash cooldown süresi
        canDash = true; // Tekrar dash atýlabilir
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
