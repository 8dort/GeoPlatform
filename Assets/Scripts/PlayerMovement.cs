using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float dashSpeed = 15f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isDashing;
    private bool canDash = true;

    private float moveInput;

    public Button leftButton;
    public Button rightButton;
    public Button jumpButton;
    public Button dashButton;

    public ParticleSystem dashEffect;
    public Light dashLight; // Dash sýrasýnda parlayan ýþýk efekti

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        leftButton.onClick.AddListener(() => moveInput = -1);
        rightButton.onClick.AddListener(() => moveInput = 1);
        jumpButton.onClick.AddListener(Jump);
        dashButton.onClick.AddListener(() => StartCoroutine(Dash()));

        if (dashLight != null)
        {
            dashLight.enabled = false;
        }
    }

    void Update()
    {
        if (!isDashing)
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
        if (!canDash) yield break;
        canDash = false;
        isDashing = true;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;

        rb.velocity = new Vector2(moveInput * dashSpeed, 0f);

        if (dashEffect != null)
        {
            var emission = dashEffect.emission;
            emission.rateOverTime = 80; // Partikül sayýsýný artýrýyoruz
            dashEffect.Play();
        }

        if (dashLight != null)
        {
            StartCoroutine(DashLightEffect());
        }

        yield return new WaitForSeconds(dashDuration);

        rb.gravityScale = originalGravity;
        isDashing = false;

        if (dashEffect != null)
        {
            dashEffect.Stop();
        }

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    IEnumerator DashLightEffect()
    {
        if (dashLight == null) yield break;

        dashLight.enabled = true;
        dashLight.intensity = 6f;

        float timeElapsed = 0f;
        float fadeDuration = dashDuration;

        while (timeElapsed < fadeDuration)
        {
            dashLight.intensity = Mathf.Lerp(6f, 0f, timeElapsed / fadeDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        dashLight.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
