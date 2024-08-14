using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls;
    float direction = 0;
    public bool isFacingRight = true;

    public Rigidbody2D playerRb;
    public float speed;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;
    int numberOfJumps = 0;

    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;


    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

        controls.Land.Jump.performed += ctx => Jump();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, 0.1f, groundLayer);
        playerRb.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRb.velocity.y);

        if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
            Flip();
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void Jump()
    {
        // Check if playerRb is null before accessing it
        if (playerRb == null)
        {
            Debug.LogWarning("Player Rigidbody2D is null. Jump method aborted.");
            return;
        }

        if (isGrounded)
        {
            numberOfJumps = 0;
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            numberOfJumps++;
            AudioManager.instance.Play("Jump");
        }
        else
        {
            if (numberOfJumps == 1)
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
                numberOfJumps++;
                AudioManager.instance.Play("Jump");
            }
        }
    }

}

