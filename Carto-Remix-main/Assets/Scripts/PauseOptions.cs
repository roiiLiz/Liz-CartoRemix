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
        nightCheckbox.isOn = OptionsMenu.nightMode;
        exploreCheckbox.isOn = OptionsMenu.exploreMode;
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
