using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightMode : MonoBehaviour
{
    [SerializeField] public GameObject NightOverlay;
    [SerializeField] public GameObject TimerHolder;

    void Start() {
        if (OptionsMenu.nightMode) {
            NightOverlay.SetActive(true);
            TimerHolder.SetActive(true);
        }
    }
}
