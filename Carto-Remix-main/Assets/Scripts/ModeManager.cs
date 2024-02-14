using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{

    public GameObject[] enemies;

    void Start() {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        EnableModes();
    }

    void EnableModes() {
        //Debug.Log($"Mode Checker: Night Mode- {OptionsMenu.nightMode}, Explore Mode: {OptionsMenu.exploreMode}");
        //Debug.Log($"Enemies Length: {enemies.Length}");

        if (OptionsMenu.exploreMode) {
            for (int i = 0; i < enemies.Length; i++) {
                enemies[i].SetActive(false);
            }
        } 
    }
}
