using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_GameManager : MonoBehaviour
{
    public GameObject _minigameManager;
    public GameObject _uiManager;

    int _startingLives = 3;
    public int _remainingLives;

    // Resets lives, resets lists, initiates minigame loop
    public void StartGame()
    {
        _remainingLives = _startingLives;
        // Debug.Log($"Lives have been reset to {_remainingLives}");

        // Debug.Log("Reset Game function called...");
        _minigameManager.GetComponent<Script_MinigameManager>().ResetGame();
        // Debug.Log("Reset Game function executed successfully");
        
        // Debug.Log("Start Game function called...");
        _minigameManager.GetComponent<Script_MinigameManager>().NextMinigame();
        // Debug.Log("Start Game function executed successfully");
    }

    // Closes built out application
    public void QuitGame()
    {
        // Debug.Log("Quitting game...");
        Application.Quit();
        // Debug.Log("Game has been quit, see you next time!");
    }

    // Called when player completes all games with life remaining
    public void GameWin()
    {
        // Debug.Log("Game win function called");
        _uiManager.GetComponent<Script_UIManager>().GameWonScreen();
        // Debug.Log("Game win function executed");
    }

    // Called when the player has no remaining life
    public void GameOver()
    {
        // Debug.Log("Game over function called");
        _uiManager.GetComponent<Script_UIManager>().GameOverScreen();
        // Debug.Log("Game over function executed");
    }
}