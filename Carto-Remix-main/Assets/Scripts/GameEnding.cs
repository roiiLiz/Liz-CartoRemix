using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public GameObject GameScreen;
    public GameObject HealthBar;
    public GameObject Character;
    public GameObject EndScreen;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    public GameObject PauseScreen;
    public AudioClip LoseSound;
    public AudioClip WinSound;
    public AudioSource audio;
    
    private bool audioPlayed;

    void Awake() 
    {
        audioPlayed = false;
    }

    void Start() 
    {
        AudioSource audio = GetComponent<AudioSource>();
    }

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

    public void EndGame() {
        GameScreen.SetActive(false); // disables game elements
        HealthBar.SetActive(false);
        Character.SetActive(false);

        EndScreen.SetActive(true); // enables end screens

        // lose / win conditions
        // if you ran out of time or health, you lose
        // otherwise you win
        if(Timer.timeRanOut || CharacterControl.health == 0) {
            LoseScreen.SetActive(true);
            if (!audio.isPlaying && !audioPlayed) {
                audio.clip = LoseSound;
                audio.Play();
                audioPlayed = true;
            }
        } else {
            WinScreen.SetActive(true);
            if (!audio.isPlaying && !audioPlayed) 
            {
                audio.clip = WinSound;
                audio.Play();
                audioPlayed = true;
            }
            
        }
    }
}
