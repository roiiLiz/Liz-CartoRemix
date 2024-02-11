using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public static bool nightMode, exploreMode; // Night Mode & Explore Mode

    public void activateNight() { // Enables/Disables "hard mode"
        nightMode = !nightMode;
        Debug.Log($"Night Mode: {nightMode}");
    }

    public void activateExplore() { // Enables/Disables "explore mode"
        exploreMode = !exploreMode;
        Debug.Log($"Explore Mode: {exploreMode}");
    } 
}
