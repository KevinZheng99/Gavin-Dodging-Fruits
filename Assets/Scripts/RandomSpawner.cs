using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject fruit;
    public float waittime;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(FruitSpawn());
    }

    IEnumerator FruitSpawn() {
        while (true) {
            Vector3 fruitspawn = new Vector3(Random.Range(-10f, 10f), 7f, 0);

            Instantiate(fruit, fruitspawn, Quaternion.identity);

            yield return new WaitForSeconds(waittime);
        }
    }
}
