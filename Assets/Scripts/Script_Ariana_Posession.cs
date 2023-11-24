using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Ariana_Posession : MonoBehaviour
{
    // DO NOT DELETE -------------------------------------------------------
    public GameObject _gameManager;
    // ---------------------------------------------------------------------
    
    public GameObject _theLamp;
    public GameObject _theBook;
    public GameObject _thePainting;
    public GameObject _posessedItem;
    
    // Holds all posessable items.
    public List<GameObject> _itemsToPosess = new List<GameObject> {};
    
    // OnEnable is called before Start
    void OnEnable()
    {
        PickItem();
        Debug.Log("Picking item...");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        PosessionStart();
    }

    // Update is called once per frame
    void Update()
    {
        // checking if player has wonnnnn

        
    }

    // Picks which item to posess.
    public GameObject PickItem()
    {
        _posessedItem = _itemsToPosess[Random.Range(0,_itemsToPosess.Count)];
        Debug.Log("Slimon has chosen.");
        return _posessedItem;
    }

   // Initiates the posessed item and makes it move.
   void PosessionStart()
   {
        _gameManager.GetComponent<Script_UIManager>().TimerReset();
        Debug.Log("Resetting timer...");

        _gameManager.GetComponent<Script_MinigameManager>()._isMinigameRunning = true;
        Debug.Log("Minigame is running");
   }

    // Player wins minigame
    void PosessionWin()
    {
        Debug.Log("Local win function called");
        _gameManager.GetComponent<Script_MinigameManager>().MinigameWon();
        Debug.Log("Remote win function called");
    }

    // Player fails minigame
    void PosessionFail()
    {
        Debug.Log("Local lose function called");
        _gameManager.GetComponent<Script_MinigameManager>().MinigameFailed();
        Debug.Log("Remote lose function called");
    }
}