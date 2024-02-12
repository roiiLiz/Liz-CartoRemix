using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    [SerializeField] public GameObject GameScreen;
    [SerializeField] public GameObject HealthBar;
    [SerializeField] public GameObject Character;
    [SerializeField] public GameObject EndScreen;
    [SerializeField] public GameObject WinScreen;
    [SerializeField] public GameObject LoseScreen;
    [SerializeField] public GameObject PauseScreen;

    void Update()
    {
        if (Timer.timeRanOut || CharacterControl.gameOver) {
            EndGame();
        }

        // debug purposes
        if (Input.GetKeyDown(KeyCode.P)) {
            EndGame();
        };
    }

    void EndGame() {
        GameScreen.SetActive(false); // disables game elements
        HealthBar.SetActive(false);
        Character.SetActive(false);

        EndScreen.SetActive(true); // enables end screens

        // lose / win conditions
        // if you ran out of time or health, you lose
        // otherwise you win
        if(Timer.timeRanOut || CharacterControl.health == 0) {
            LoseScreen.SetActive(true);
        } else {
            WinScreen.SetActive(true);
        }
    }
}
