using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseOptions : MonoBehaviour
{
    [SerializeField] public Toggle nightCheckbox;
    [SerializeField] public Toggle exploreCheckbox;
    public GameObject pauseBox;
    public static bool isGamePaused = false;

    void Start() {
        CheckModes();
    }

    void CheckModes() {
        Debug.Log($"Mode Checker: Night Mode- {OptionsMenu.nightMode}, Explore Mode: {OptionsMenu.exploreMode}");
        if(OptionsMenu.nightMode) {
            nightCheckbox.isOn = true;
        }
        if (OptionsMenu.exploreMode) {
            exploreCheckbox.isOn = true;
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isGamePaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        pauseBox.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void Pause()
    {
        pauseBox.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
}
