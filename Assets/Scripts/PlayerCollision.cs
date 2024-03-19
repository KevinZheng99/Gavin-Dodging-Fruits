using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D collisionInfo) {
        if (collisionInfo.collider.tag == "Fruit") {
            Destroy(collisionInfo.collider.gameObject, 0f);
            PlayerStats.Instance.TakeDamage(1);
        }

        if (PlayerStats.Instance.Health == 0) {
            FindObjectOfType<DefeatMenu>().EndGame();
        }
    }
} 
