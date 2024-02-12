using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] public float totalTimeLeft = 100;
    public static bool timeRanOut = false;
    [SerializeField] public TextMeshProUGUI timerText;

    // resets variables for scene repurposing
    void Awake() {
        totalTimeLeft = 100;
        timeRanOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (OptionsMenu.nightMode) {
            if(totalTimeLeft > 0) {
                totalTimeLeft -= Time.deltaTime;
            } else {
                timeRanOut = true;
            }
        
            timerText.text = $"{Mathf.RoundToInt(totalTimeLeft)}";
        }
    }
}

