using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_MinigameManager : MonoBehaviour
{
    // DO NOT DELETE -------------------------------------------------------
    public GameObject _gameManager;
    public GameObject _uiManager;
    public GameObject _sceneManager;
    // ---------------------------------------------------------------------
    
    public int _currentMinigame;
    int _maximumMinigames = 6;
    public bool _isMinigameRunning = false;
    
    // All minigames overall. This list should not change so it can reset the other lists for new players.
    public List<string> _minigamesList = new List<string>{"Capture","Posession","Cupboards","Difference","Cleaning","Gooing"};
        
    // Holds minigames not yet played this run
    public List<string> _minigamesRemaining = new List<string>{};
    
    // Holds won minigames so they can't be repeated in a run
    private List<string> _minigamesWon = new List<string>{};
        
    // Holds lost minigames for the opportunity to retry later
    private List<string> _minigamesFailed = new List<string>{};

    // Holds the loop checking if the quantity of minigames in a run has been met.
    public void NextMinigame()
    {
        Debug.Log("Next minigame called!");
        
        int _thisMinigame = -1;
        
        for(int i = 0; i < _maximumMinigames; i++)
        {
            _thisMinigame = Random.Range(0,_minigamesRemaining.Count);

            _currentMinigame = _thisMinigame;          
        }
    } 

    // Called by the minigame itself when the game is won
    public void MinigameWon()
    {
        _isMinigameRunning = false;
        // Debug.Log("Current minigame won");
        
        // Adds the current game to the Won list
        _minigamesWon.Add("{_minigamesList[_currentMinigame]}");
        // Debug.Log($"{_minigamesList[_currentMinigame]} was added to _minigamesWon");
        
        // Removes the current game from the overall list
        _minigamesList.Remove("{_minigamesList[_currentMinigame]}");
        // Debug.Log($"{_minigamesList[_currentMinigame]} was removed from _minigamesWon");
        
        // Makes sure it can't accidentally remove a game
        _currentMinigame = -1;
        // Debug.Log($"The value of _currentMinigame has been reset to {_currentMinigame}");

        // Progresses to the next minigame
        NextMinigame();
        // Debug.Log("Calling next minigame...");
    }
    
    // Called by the minigame itself when the game is lost if the player has remaining lives
    public void MinigameFailed()
    {
        _isMinigameRunning = false;
        //Debug.Log("Current minigame failed");

        // Removes a life from remaining lives
        _gameManager.GetComponent<Script_GameManager>()._remainingLives--;
        // Debug.Log("Life removed");
        
        // if the player has no remaining lives...
        if(_gameManager.GetComponent<Script_GameManager>()._remainingLives < 1)
        {
            _gameManager.GetComponent<Script_GameManager>().GameOver();
        }
        // if the player has remaining lives...
        else
        {
            _uiManager.GetComponent<Script_UIManager>().LoseLifeScreen();
            // Debug.Log("Calling lose a life display...");
            
            _minigamesFailed.Add($"{_minigamesRemaining[_currentMinigame]}");
            // Debug.Log("Minigame added to failed list...");

            _minigamesRemaining.Remove($"{_minigamesRemaining[_currentMinigame]}");
            // Debug.Log("Minigame removed from remaining minigames list...");
        }
    }
    
    // Called when start function is initiated in the Game Manager
    public void ResetGame()
    {
        //Debug.Log("Game being reset...");

        // Goes through the list to add every game back to games remaining in the correct order
        for(int i = 0; i < _minigamesList.Count; i++)
        {
            _minigamesRemaining.Add(_minigamesList[i]);
            // Debug.Log($"Added {_minigamesList[i]} to _minigamesRemaining");
        }

        // Clears the rest of the lists
        // Debug.Log("Clearing lists...");
        _minigamesRemaining.Clear();
        _minigamesWon.Clear();
        _minigamesFailed.Clear();
        // Debug.Log("Lists cleared");

        // Debug.Log("Game reset successfully");
    }
}