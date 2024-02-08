using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] public float totalTimeLeft = 90;
    public static bool timeRanOut = false;
    [SerializeField] public TextMeshProUGUI timerText;

    // Update is called once per frame
    void Update()
    {
        if (!PauseOptions.isGamePaused) {
            if(totalTimeLeft > 0) {
                totalTimeLeft -= Time.deltaTime;
            } else {
            timeRanOut = true;
            // Debug.Log("Time Ran Out!");
            }
        
            timerText.text = $"{Mathf.RoundToInt(totalTimeLeft)}";
        }
        
    }
}

