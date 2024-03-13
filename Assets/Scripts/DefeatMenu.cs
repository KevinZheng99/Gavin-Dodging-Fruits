using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMenu : MonoBehaviour
{
    public GameObject defeatMenuUI;

    bool gameHasEnded = false;

    public void EndGame () {
        if (gameHasEnded == false) {
            gameHasEnded = true;
            Pause();
        }
    }

    void Pause () {
        defeatMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart() {
        defeatMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PlayerStats.Instance.Heal(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
