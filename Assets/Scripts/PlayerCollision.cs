using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{   
    private Animator anim;
    [SerializeField] private AudioSource OofSoundEffect;
    [SerializeField] private AudioSource OwSoundEffect;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D (Collider2D collider) {
        Debug.Log(collider);
        if (collider.tag == "Fruit") {
            // Randomly choose a sound to play
            int soundChoice = Random.Range(0, 2); // Generates 0 or 1

            if (soundChoice == 0) {
                OofSoundEffect.Play();
            } else {
                OwSoundEffect.Play();
            }
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

