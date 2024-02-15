using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModeManager : MonoBehaviour
{

    public TextMeshProUGUI NightModeIndicator;
    public TextMeshProUGUI ExploreModeIndicator;

    void Start() {
        ExploreModeIndicator.text = "";
        NightModeIndicator.text = "";
    }

    void Update() {
        EnableModes();
    }

    void EnableModes() {
        //Debug.Log($"Mode Checker: Night Mode- {OptionsMenu.nightMode}, Explore Mode: {OptionsMenu.exploreMode}");
        //Debug.Log($"Enemies Length: {enemies.Length}");

        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (OptionsMenu.exploreMode) {
            for (int i = 0; i < enemies.Length; i++) {
                enemies[i].SetActive(false);
            }
        }

        if (OptionsMenu.exploreMode) {
            ExploreModeIndicator.text = "Explore Mode: ON";
        }
        if (OptionsMenu.nightMode) {
            NightModeIndicator.text = "Night Mode: ON";
        } 
    }
}
