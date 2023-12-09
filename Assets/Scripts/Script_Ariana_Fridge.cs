using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Ariana_Fridge : MonoBehaviour
{
    public GameObject _minigameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when the minigame starts
    void FridgeStart()
    {

    }

    // Called when the minigame is won
    void FridgeWin()
    {
        // Calls the game loop's minigame win function
        _minigameManager.GetComponent<Script_MinigameManager>().MinigameWon();
    }

    // Called when the minigame is failed
    void FridgeFail()
    {
        // Calls the game loop's minigame fail function
        _minigameManager.GetComponent<Script_MinigameManager>().MinigameFailed();
    }
}
