using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private SpriteRenderer sprite; //Reference to Sprite for flip
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Animator anim; //Reference to animation
    

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component from the player object
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y); // Set the velocity to move the player

        if (Input.GetButtonDown("Jump")) //Uses unity input manager to jump
        {
            rb.velocity = new Vector3(0, jumpForce, 0);
        }

        if (dirX > 0f) // Trigger the running animation if there's horizontal movement
        {
            anim.SetBool("isRunning", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("isRunning", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

    }

}

