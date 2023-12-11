using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bare minimum requirements all minigames should have in order to function
public class Script_TempFightActivate_Ethan : MonoBehaviour
{
    // PLEASE MAKE A COPY OF THIS AND TITLE IT Script_[Name]_[Game]
    // EXAMPLE : Script_Karl_Flashing
    // PLEASE MAKE THE GAME THE SAME AS FOUND IN Script_MinigameTemplate
    
    //Declaration
    Camera cam;
    public GameObject thermostatManager;

    public GameObject _thermostat;
    
    // OnEnable is called before Start
    void OnEnable()
    {
        cam = Camera.main;

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; 
            if(Physics.Raycast(ray, out hit))
            {
               thermostatManager.GetComponent<Script_TempFight_Ethan>().OnEnable();

            }
        }
    }

    public void OnTrigger(Collision other)
    {
        other.gameObject.GetComponent<Script_TempFight_Ethan>().OnEnable();
    }

    // Function for fail state

    // Function for win state

    // Function for player input

    // Functions to talk to higher scripts (UI, Minigame Manager, Game Manager etc.)
}
