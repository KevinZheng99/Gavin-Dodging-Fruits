using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public List<GameObject> hearts;
    void OnCollisionEnter2D (Collision2D collisionInfo) {
        if (collisionInfo.collider.tag == "Fruit") {
            Destroy(collisionInfo.collider.gameObject, 0f);
            PlayerStats.Instance.TakeDamage(1);
        }
    }
} 
