using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{   
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D (Collision2D collisionInfo) {
        if (collisionInfo.collider.tag == "Fruit") {
            ///Destroy(collisionInfo.collider.gameObject, 0f);
            PlayerStats.Instance.TakeDamage(1);
        }

        if (PlayerStats.Instance.Health == 0) {
            die();
            StartCoroutine(ShowDefeatMenuAfterDelay(1f)); // Start coroutine to delay the defeat menu
        }
    }

     private void die()
    {
        anim.SetTrigger("death");
    }

    // wait for a specified delay before showing the defeat menu
    IEnumerator ShowDefeatMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        FindObjectOfType<DefeatMenu>().EndGame();
    }
}

