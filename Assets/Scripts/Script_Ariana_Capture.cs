using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Ariana_Capture : MonoBehaviour
{
    // The manager objects. These are important. Benevolent overlords, if you will.
    public GameObject _minigameManager;
    public GameObject _UIManager;
    
    // Added in inspector in order Red, Green, Blue (RGB) (I'm creative)
    public List<GameObject> _captureButtons = new List<GameObject>();
    // I just discovered dictionaries and my life has been changed forever
    private Dictionary<GameObject, int> _buttonIndexDictionary = new Dictionary<GameObject, int>();
    
    // I might not need to use these hold on
    // Keeps track of which button the player pressed last. Starts at -1 because the first button a player can press is at index 0 in the list.
    private int _lastButtonIndex = -1;
    // Do I need to explain it again lol
    private int _nextButtonIndex = 0;
    
    // OnEnable is called before Start
    void OnEnable()
    {
        // Help I'm delusional
        //Debug.Log("Yarghhhh I be awakened matey");
        
        // Adds each button to the dictionary in order I can't believe this isn't throwing errors oh my fucking god
        //Debug.Log("Executing dictionary for loop...");
        for(int i = 0; i < _captureButtons.Count; i++)
        {
            // int i ends up being the same as the index of the buttons in the list. I think. Coding math is hard.
            //Debug.Log($"Adding {_captureButtons[i]} key to dictionary with a value of {i}..."); 
            _buttonIndexDictionary.Add(_captureButtons[i],i);
            //Debug.Log($"Added {_captureButtons[i]} key to dictionary with a value of {i}.");
            // The fact that this is throwing no compile errors is astounding honestly
        }
        //Debug.Log("Dictionary for loop executed.");
                
        // Starts the internal game loop
        //Debug.Log("Calling internal game loop...");
        CaptureStart();
        //Debug.Log("Internal game loop called.");

        // Sorry
        //Debug.Log("Ready to sail the high seas me matey yarghhhh");
    }

    // Starts the dang thang. You can't play a game you ain't started
    void CaptureStart()
    {
        // Resets the countdown and should instantiate it to the canvas
        //Debug.Log("Resetting timer...");
        _UIManager.GetComponent<Script_UIManager>().TimerReset();
        //Debug.Log("Timer is reset.");

        // Running the minigame manager from the backend so it can do its fancy shiz
        //Debug.Log("Running minigame...");
        _minigameManager.GetComponent<Script_MinigameManager>()._isMinigameRunning = true;
        //Debug.Log("Minigame is running.");

        // Can't play a button game without clicking buttons (the correct ones, specifically)
        //Debug.Log("Starting button order coroutine...");
        StartCoroutine(ButtonOrder());
        //Debug.Log("Button order coroutine started.");
    }
    
    // Assigns the button the player pressed a variable to be able to be checked in the coroutine
    string WhatButtonAmI(string myName)
    {
        //myName = GameObject.name;
        
        return myName;
    }
    
    IEnumerator ButtonOrder()
    {
        // While the game is running... (so you can't keep playing during a win or fail state)
        while(_minigameManager.GetComponent<Script_MinigameManager>()._isMinigameRunning == true)
        {
            //if(_buttonIndexDictionary[myName].Value = )
        } 

        // I don't need this to wait for any amount of time before running again
        yield return null;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when the minigame is won
    void CaptureWin()
    {
        // Tells the minigame manager to do it's win processes
        Debug.Log("Local win function called");
        _minigameManager.GetComponent<Script_MinigameManager>().MinigameWon();
        Debug.Log("Remote win function called");
    }

    // Called when the minigame is lost
    void CaptureFail()
    {
        // Tells the minigame manager to do it's lose processes
        Debug.Log("Local lose function called");
        _minigameManager.GetComponent<Script_MinigameManager>().MinigameFailed();
        Debug.Log("Remote lose function called");
    }
}