using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Ariana_Posession : MonoBehaviour
{
    // DO NOT DELETE -------------------------------------------------------
    public GameObject _minigameManager;
    // ---------------------------------------------------------------------
    
    public GameObject _theLamp;
    public GameObject _theBook;
    public GameObject _thePainting;
    public GameObject _posessedItem;
    // Can only have each object posessed once
    private int _objectsRemaing = 3;

    // I will not be the victim of my own hubris.
    private bool _canIWhileLoopPlease = false;
    // Can you clicky da objecty?
    private bool _canIClickPlease = false;
    
    // Holds all posessable items. I had to soft code these into the inspector for some reason. Sobs.
    public List<GameObject> _itemsToPosess = new List<GameObject>();
    
    // OnEnable is called on the enable of the object its attached to. I think. Also, it's called before start.
    void OnEnable()
    {
        Debug.Log("Starting posession...");
        PosessionStart();
        Debug.Log("Posession successfully started.");
    }

    // Initiates the posessed item and makes it move.
    void PosessionStart()
    {
        Debug.Log("Resetting timer...");
        //_minigameManager.GetComponent<Script_UIManager>().TimerReset();
        Debug.Log("Timer reset.");

        //_minigameManager.GetComponent<Script_MinigameManager>()._isMinigameRunning = true;
        Debug.Log("Minigame is running");

        // Allows the while loop within the coroutine to run
        _canIWhileLoopPlease = true;
        Debug.Log("We're in delicate territory rn");

        // I tried to call ShakeThatShit() as a normal function last night. Lol.
        Debug.Log("Initiating wiggling coroutine...");
        StartCoroutine(ShakeThatShit());
        Debug.Log("Wiggling coroutine initiated.");
    }
    
    // Makes the posessed item wiggle
    IEnumerator ShakeThatShit()
    {
        while(_canIWhileLoopPlease == true)
        { 
            Debug.Log("Picking item...");
            PickItem();
            Debug.Log("Item picked!");

            // Different duration of wiggle generated each time
            float durationOfWiggle = Random.Range(0.5f,2.0f);
            
            // Object shakey, clicky awakey
            _canIClickPlease = true;
            
            // Makes that shit shake asssss baybeyyyy
            // If this works i will cream i mean cream i mean scream
            _posessedItem.transform.Rotate((Mathf.Cos(Time.fixedTime)*durationOfWiggle),0,0,Space.World);

            // Fuck off and die.
            _canIClickPlease = false;

            // Keep them motherfuckers on their toes even while they're waiting
            float waitBetweenPosessions = Random.Range(1.0f,3.0f);
            // IEnum return values are weird. But it will wait for the time above before it goes again.
            yield return new WaitForSeconds(waitBetweenPosessions);
        }
    }
    
    // Picks which item to posess.
    public void PickItem()
    {
        _posessedItem = _itemsToPosess[Random.Range(0,_itemsToPosess.Count)];
        //Debug.Log("Slimon has chosen.");
        
        // Adds tag checked in raycasting
        _posessedItem.tag = "Posessed";
    }
    
    // Update is called once per frame
    void Update()
    {
        // *DEBUG ALERT*
        if(Input.GetKeyDown("p"))
        {
            Camera.main.transform.position = new Vector3(-79.7f,61.0f,-17.3f);
        }
        
        // On left click...
        if(Input.GetMouseButtonDown(0))
        {
            // Ray is wherever the mouse is
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Don't ask me
            RaycastHit hit;

            // If the ray collides with something...
            if(Physics.Raycast(ray, out hit))
            {
                // If the thing it collides with is posessed and currently moving...
                if (hit.collider.tag == "Posessed" && _canIClickPlease == true)
                {
                    // Stops the dang wiggle
                    _canIWhileLoopPlease = false;
                    Debug.Log("Wiggling paused");
                    
                    //Instantiate an image on the canvas to indicate success
                    
                    // Destroys the posessed object
                    Destroy(_posessedItem);
                    Debug.Log("Successfully eradicated the object lol");

                    // Removes one from the counter
                    _objectsRemaing--;
                    Debug.Log($"{_objectsRemaing} items left!");

                    // Starts the dang wiggle
                    _canIWhileLoopPlease = true;
                    Debug.Log("Wiggling resumed");
                }
            }
        }
        
        // Checks if the player has met the win count of clicks on posessed items
        if(_objectsRemaing == 0)
        {
            // Stops the dang wiggle
            _canIWhileLoopPlease = false;
            Debug.Log("Wiggling paused");
            
            // I am so fucking tired lol.
            PosessionWin();
            Debug.Log("You won! Nice going, fucker");
        }
    }

    // Player wins minigame
    void PosessionWin()
    {
        Debug.Log("Local win function called");
        _minigameManager.GetComponent<Script_MinigameManager>().MinigameWon();
        Debug.Log("Remote win function called");
    }

    // Player fails minigame
    void PosessionFail()
    {
        Debug.Log("Local lose function called");
        _minigameManager.GetComponent<Script_MinigameManager>().MinigameFailed();
        Debug.Log("Remote lose function called");
    }
}