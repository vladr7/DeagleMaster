using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashSpeed = 20f; 
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool hasDashed = false;
    private bool isDashing = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProcessInputs();

        if (Input.GetKeyDown(KeyCode.Space) && !hasDashed)
        {
            Debug.Log("Dashing");
            Dash();
            Invoke(nameof(ResetDash), 3f); 
            Invoke(nameof(StopDash), 0.2f);
        }
    }

    void FixedUpdate()
    {
        if (!isDashing) // Only move if not dashing
        {
            Move();
        }
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void Dash()
    {
        rb.velocity = moveDirection * dashSpeed; 
        hasDashed = true;
        isDashing = true; 
    }

    void StopDash()
    {
        isDashing = false; 
    }

    void ResetDash()
    {
        hasDashed = false; 
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player hit by enemy");
            // Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}