using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatMenu : MonoBehaviour
{
    public GameObject defeatMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.Instance.Health == 0) {
            defeatMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Restart() {
        defeatMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PlayerStats.Instance.Heal(3);
        // Reset the Scene
        // Reset the Score
    }
}
