using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

// Bare minimum requirements all minigames should have in order to function
public class Script_Ethan_SpotTD : MonoBehaviour
{
    // PLEASE MAKE A COPY OF THIS AND TITLE IT Script_[Name]_[Game]
    // EXAMPLE : Script_Karl_Flashing
    // PLEASE MAKE THE GAME THE SAME AS FOUND IN Script_MinigameTemplate
    
    //Declaration 
    Camera cam;
    public GameObject gameManager;
    public GameObject squarePrefab;
    public GameObject roundPrefab;
    public GameObject trianglePrefab;
    public GameObject newPrefab;
    
//this is to hide the screen at the start of the game
    public GameObject screenCover_P;
    public int chosenItem;
    public bool correctItemChosen = false;

    
    // OnEnable is called before Start
    void OnEnable()
    {
        StartCoroutine(ScreenHide());
        cam = Camera.main;

    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnItem());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
           Ray ray = cam.ScreenPointToRay(Input.mousePosition);
           RaycastHit hit; 
           if(Physics.Raycast(ray, out hit))
           {
                CorrectItemPicked();
                Debug.Log(hit.transform.name);
           }
        }
    }
//this hides the camera and allows time for the object to be spawned in and them after removes the cover to display the room
//---------------------------------------------
    IEnumerator ScreenHide()
    {
        yield return new WaitForSeconds(5.0f);
        SpawnScreenCover();
        
        yield return new WaitForSeconds(1.0f);
        DestroyScreenCover();

    }
//this spawns the item lol 
    IEnumerator SpawnItem()
    {
        yield return new WaitForSeconds(5.1f);
        SpawnItemNew();
    }
//---------------------------------------------

//this is just the function for instantiating the screen cover
//------------------------------------------------------------------------------------------------------
    void SpawnScreenCover()
    {
        screenCover_P = Instantiate(screenCover_P, new Vector3(-82.54243f,89.55885f,-9.5f), Quaternion.identity);

        //screenCover_P.transform.Rotate(90f,180f,0f);

        //WaitForSeconds(5.0f);
        Debug.Log("Cover spawned, wait 5 seconds for reveal");

    }

//this destroys the screen cover

    void DestroyScreenCover()
    {
        Destroy(screenCover_P);
    }
//-------------------------------------------------------------------------------------------------------

// this randomises and choses which object to spawn in (yes i know it's gross)
//-------------------------------------------------
    void SpawnItemNew()
    {
        chosenItem = Random.Range(1,4);
        if(chosenItem == 1)
        {
            SpawnSquareItem();
        }
        else if(chosenItem == 2)
        {
            SpawnRoundItem();
        }
        else if(chosenItem == 3)
        {
            SpawnTriangleItem();
        }
        Debug.Log($"Item chosen was {chosenItem}");
    }
//--------------------------------------------------

//these 3 functions are just for spawning the items in with correct coordination and rotation
//------------------------------------------------------------------------------------------------------------------------
    void SpawnRoundItem()
    {
       newPrefab = Instantiate(roundPrefab, new Vector3(-84.14f,87.47f, -1.1f), transform.rotation * Quaternion.Euler(90f, 180f, 0f));
       newPrefab.tag = "New Item";
        
    }

    void SpawnSquareItem()
    {
       newPrefab = Instantiate(squarePrefab, new Vector3(-79.03f, 89.17579f, -0.7f), transform.rotation * Quaternion.Euler(90f, 180f, 0f));
       newPrefab.tag = "New Item";
    }

    void SpawnTriangleItem()
    {
        newPrefab = Instantiate(trianglePrefab, new Vector3(-83.59f, 87.33f, -0.76f), transform.rotation * Quaternion.Euler(90f, 180f, 0f));
        newPrefab.tag = "New Item";
    }


    void CorrectItemPicked()
    {
        
        if(GameObject.FindWithTag("New Item"))
            {
                correctItemChosen = true;
                Debug.Log("This fired");

            }
    }
//------------------------------------------------------------------------------------------------------------------------
    // Function for fail state
    void SpotTheDifLose()
    {
        Debug.Log("Fail function called from Game Manager");
        gameManager.GetComponent<Script_MinigameManager>().MinigameFailed();
    }

    // Function for win state
    void SpotTheDifWin()
    {
        if(correctItemChosen == true)
        {
            gameManager.GetComponent<Script_MinigameManager>().MinigameWon();
            Debug.Log("Correct item found you win");
        }

    }


    // Function for player input

    // Functions to talk to higher scripts (UI, Minigame Manager, Game Manager etc.)
}
