using System.Collections;
using System.Collections.Generic;
using UnityEditor;
// using UnityEditor.Rendering;
using UnityEngine;

// Bare minimum requirements all minigames should have in order to function
public class Script_Karl_Cleaning : MonoBehaviour
{
    public GameObject _minigameManager;
    
    float transp = 0.8f;
    //Forcing a field for the script so it knows which object in the scene to pull from when I ask for a colour
    [SerializeField] private Renderer myMaterial;
    
    // Start is called before the first frame update
    void Start()
    {
        _minigameManager.GetComponent<Script_MinigameManager>()._isMinigameRunning = true;
    }

    // OnMouseOver is called whenever the mouse is within the collision box of the attached object
    void OnMouseOver()
    {
        //storing a variable which will be used later on upon completing of minigame
        bool gooGone = false;
        if (Input.GetMouseButtonDown(0))
        {
            //selecting the objects materials colour and saving its value into color
            Color color = myMaterial.material.color;
            //changing the alpha to match the value stored in transp
            color.a = transp;
            //changing the alpha of the material to match the value stored in color
            myMaterial.material.color = color;
            //lowering the stored value of transp
            transp = transp - 0.2f;
            if (myMaterial.material.color.a <= 0.2f)
            {
                //ensuring there is no negative alpha
                transp = 0f;
                gooGone = true;

            }

        }
        //will be used to transition to the next minigame
        if (gooGone == true) 
        {

            Win();

        }

    }

    void Win()
    {
        print("You did it!");
    }

    void Fail()
    {
        print("Get gooed");
    }

    // Functions to talk to higher scripts (UI, Minigame Manager, Game Manager etc.)
}
