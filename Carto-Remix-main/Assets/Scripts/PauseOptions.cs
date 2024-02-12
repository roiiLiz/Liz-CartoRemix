using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseOptions : MonoBehaviour
{
    [SerializeField] public Toggle nightCheckbox;
    [SerializeField] public Toggle exploreCheckbox;
    [SerializeField] public GameObject pauseBox;
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
            //Debug.Log("Escape Pressed");
            isGamePaused = !isGamePaused;
            pauseBox.SetActive(!pauseBox.activeInHierarchy);
            if(isGamePaused) {
                Time.timeScale = 0f;
            } else {
                Time.timeScale = 1f;
            }
        }
    }
}
