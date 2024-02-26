using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public float lifetime = 5f; // Time in seconds before the fruit is despawned
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime); // Destroys this fruit object after 'lifetime' seconds
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
