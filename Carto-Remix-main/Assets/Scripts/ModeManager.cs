using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    [SerializeField] public GameObject[] Tiles;
    [SerializeField] public GameObject MysteryTile;

    void Start() {
        EnableModes();
    }

    void EnableModes() {
        //Debug.Log($"Mode Checker: Night Mode- {OptionsMenu.nightMode}, Explore Mode: {OptionsMenu.exploreMode}");
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Debug.Log($"Enemies Length: {enemies.Length}");

        if (OptionsMenu.exploreMode) {
            for (int i = 0; i < enemies.Length; i++) {
                enemies[i].SetActive(false);
            }
        } 
    }
}
