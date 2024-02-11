using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CheckModes();
    }

    void CheckModes() {
        Debug.Log($"Mode Checker: Night Mode- {OptionsMenu.nightMode}, Explore Mode: {OptionsMenu.exploreMode}");
    }
}
