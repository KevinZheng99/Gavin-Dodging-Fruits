using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHit : MonoBehaviour
{
    public int lives = 3; // Starting lives
    [SerializeField] private Text livesText;

    private Animator anim;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Fruit"))
        {
            lives--;
            livesText.text = "Lives: " + lives;
          
            if (lives <= 0)
             {
                die();
             }
        }
    }

    private void die()
    {
        anim.SetTrigger("death");
    }
}
