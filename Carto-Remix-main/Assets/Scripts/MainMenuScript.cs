using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    /*void Awake() {
        OptionsMenu.nightMode = false;
        OptionsMenu.exploreMode = false;
    }*/

    void LoadNextScene() {
        if (OptionsMenu.nightMode && OptionsMenu.exploreMode) {
            SceneManager.LoadScene("AlternateModes");
        } else if (!OptionsMenu.nightMode && OptionsMenu.exploreMode) {
            SceneManager.LoadScene("AlternateModes");
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void QuitGame() {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
