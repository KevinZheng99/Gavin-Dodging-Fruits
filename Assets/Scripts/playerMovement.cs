using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private float dirX = 0f; 
    private SpriteRenderer sprite; 
    private Rigidbody2D rb;
    private Animator anim; 

    private enum MovementState { idle, running, jumping };

    [SerializeField] private AudioSource NicotineSoundEffect;
    private float idleTimer = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component from the player object
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y); // Set the velocity to move the player

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f) // Checks if on the ground before jumping
        {
            rb.velocity = new Vector3(0, jumpForce, 0);///AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        UpdateAnimationState();
        UpdateIdleTimer();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        
        if (dirX > 0f) 
        {
            state = MovementState.running;
            sprite.flipX = false;
        }

        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (Mathf.Abs(rb.velocity.y) > 0.001f) // check for being in air
        {
            state = MovementState.jumping;

        }

        anim.SetInteger("state", (int)state);
    }

    private void UpdateIdleTimer()
    {
        if (Mathf.Abs(dirX) > 0f || Mathf.Abs(rb.velocity.y) > 0.001f)
        {
            idleTimer = 0f;
        }
        else 
        {
            idleTimer += Time.deltaTime;
            
            // Play the sound effect if the player has been idle for x seconds
            if (idleTimer >= 3f)
            {
                NicotineSoundEffect.Play();
                idleTimer = 0f; // Reset the timer after playing the sound
            }
        }
    }
}
