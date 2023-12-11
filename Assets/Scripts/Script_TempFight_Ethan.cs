using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Bare minimum requirements all minigames should have in order to function
public class Script_TempFight_Ethan : MonoBehaviour
{
    // PLEASE MAKE A COPY OF THIS AND TITLE IT Script_[Name]_[Game]
    // EXAMPLE : Script_Karl_Flashing
    // PLEASE MAKE THE GAME THE SAME AS FOUND IN Script_MinigameTemplate

    //Declaration
    public float temp;

    public int desiredTemp;

    public float tempdecrease = 1.0f;

    public TextMeshProUGUI stickynoteText;
    public TextMeshProUGUI tempDisplay;

    public Slider thermostat;

    public GameObject _minigameManager;
    public GameObject _roomManager;

    
    // OnEnable is called before Start
    public void OnEnable()
    {   
        gameObject.SetActive(true);

    }
    
    // Start is called before the first frame update
    void Start()
    {
        desiredTemp = Random.Range(19, 40);
        stickynoteText.text = ($"Ideal Temp:\n\n{desiredTemp}C");
        temp = Random.Range(0f, 10f);
        thermostat.value = temp;
        tempDisplay.text = ($"Temp: {thermostat.value}C");
    }

    // Update is called once per frame
    void Update()
    {
        //tempdecrease = Time.deltaTime;
        temp -= Time.deltaTime;
        thermostat.value = temp;
        if(temp == 0f)
        {
            thermostat.value = 0;
        }
        tempDisplay.text = ($"Temp: {thermostat.value}C");

        if(thermostat.value >= desiredTemp)
        {   
            _minigameManager.GetComponent<Script_MinigameManager>().MinigameWon();
            _roomManager.SetActive(false);
            gameObject.SetActive(false);
            

        }
    }

    public void TempUPButton()
    {
        //thermostat.value += 1f;
        temp += 1f;
    }

    public void TempDownButton()
    {
        //thermostat.value -= 1f;
        temp -= 1f;
    }

    // Function for fail state

    // Function for win state

    // Function for player input

    // Functions to talk to higher scripts (UI, Minigame Manager, Game Manager etc.)
}
