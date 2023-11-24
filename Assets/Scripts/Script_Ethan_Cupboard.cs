using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Bare minimum requirements all minigames should have in order to function
public class Script_Ethan_Cupboard : MonoBehaviour
{
    // PLEASE MAKE A COPY OF THIS AND TITLE IT Script_[Name]_[Game]
    // EXAMPLE : Script_Karl_Flashing
    // PLEASE MAKE THE GAME THE SAME AS FOUND IN Script_MinigameTemplate

    public GameObject gameManager;
    
    //Declaration
    public List<GameObject> cupboards = new List<GameObject>();
    public int cupboardChosen;
    RaycastHit hit;
    Ray ray;
    public new Camera camera;
    
    // OnEnable is called before Start
    void OnEnable()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }
    
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(CupboardRandomiser());
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = this.camera.ScreenPointToRay(Input.mousePosition);
        
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, 100.0f))
            {  
             CloseCupboardDoor();
             Debug.Log("this is doing something?");
            }
        }
    }

//this function keeps the function that changes the materials on the door changing 
    IEnumerator CupboardRandomiser()
    {
        while(true)
        {

            OpenCupboardDoor();
            
            yield return new WaitForSeconds(2.0f);
        }
    }

//this grabs the function from the prefabs which changes the material on it to open 
    void OpenCupboardDoor()
    {
        cupboardChosen = Random.Range(1, cupboards.Count);

        cupboards[cupboardChosen].GetComponent<Script_CupboardMaterialChange>().ChangeMaterialToOpen();
    }

//this, when fired, reverts the material back to closed
    void CloseCupboardDoor()
    {
       cupboards[cupboardChosen].GetComponent<Script_CupboardMaterialChange>().ChangeMaterialToClosed();
    }



    // Function for win state
    void CupboardsWin()
    {
        Debug.Log("Win function called from Game Manager");
        gameManager.GetComponent<Script_MinigameManager>().MinigameWon();
    }

    // Function for fail state
    void CupboardsLose()
    {
        Debug.Log("Fail function called from Game Manager");
        gameManager.GetComponent<Script_MinigameManager>().MinigameFailed();
    }

    // Function for player input

    // Functions to talk to higher scripts (UI, Minigame Manager, Game Manager etc.)
}
