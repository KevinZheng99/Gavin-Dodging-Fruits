using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public List<GameObject> hearts;
    void OnCollisionEnter2D (Collision2D collisionInfo) {
        if (collisionInfo.collider.tag == "Fruit") {
            Debug.Log(collisionInfo.collider.name);
        }
    }
} 
