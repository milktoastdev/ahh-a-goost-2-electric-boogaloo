using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Manages anything on the Canvas.
public class Script_UIManager : MonoBehaviour
{
    public GameObject _gameManager;
    public GameObject _minigameManager;
    public GameObject _sceneManager;
       
    public GameObject _quitButton;
    public GameObject _returnButton;
    public GameObject _continueButton;

    public GameObject _winGameImage;
    public GameObject _loseGameImage;
    public GameObject _loseLifeImage;
    
    public GameObject _timerTMP;
    // This is 31 because by the time the timer is displayed it hits 29
    private float _timeAllowed = 31.0f;
    private float _timeRemaining = 0.0f;
    private bool _isTimerDisplayed = false;
    public TextMeshProUGUI _countDown;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Calls the start function in the Game Manager
    public void StartButton()
    {
        // Debug.Log("Start button pressed");
        _gameManager.GetComponent<Script_GameManager>().StartGame();
        // Debug.Log("Start button exectued succesfully");
    }

    // Calls the return to start scene function in the Scene Manager
    public void TitleButton()
    {
        // Debug.Log("Title button pressed");
        _sceneManager.GetComponent<Script_SceneManager>()._nextSceneType = "Menu";
        _sceneManager.GetComponent<Script_SceneManager>()._nextSceneName = "Main";
        _sceneManager.GetComponent<Script_SceneManager>().PlsLoadSceneAsync();
        // Debug.Log("Title button executed successfully");
    }
    
    public void DisplayTitleButton()
    {
        // Debug.Log("Displaying title button...");

        // Instantiates the prefab
        _returnButton = Instantiate(_returnButton, new Vector3(0,140.0f,0), Quaternion.identity) as GameObject;

        // Parents it to the canvas
        _returnButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

        // Debug.Log("Title button displayed");
    }
    
    // Calls the credits scene function in the Scene Manager
    public void CreditsButton()
    {
        // Debug.Log("Credits button pressed");
        _sceneManager.GetComponent<Script_SceneManager>()._nextSceneType = "Menu";
        _sceneManager.GetComponent<Script_SceneManager>()._nextSceneName = "Credits";
        _sceneManager.GetComponent<Script_SceneManager>().PlsLoadSceneAsync();
        // Debug.Log("Credits button executed successfully");
    }

    public void ContinueButton()
    {

    }

    public void DisplayContinueButton()
    {

    }
    
    // Called when game is won or lost
    public void DisplayQuitButton()
    {
        // Debug.Log("Displaying quit button...");

        // Instantiates the prefab
        _quitButton = Instantiate(_quitButton, new Vector3(0,70.0f,0), Quaternion.identity) as GameObject;

        // Parents it to the canvas
        _quitButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

        // Debug.Log("Quit button displayed");
    }
    
    // Calls the quit function in the Game Manager
    public void QuitButton()
    {
        // Debug.Log("Quit button pressed");
        _gameManager.GetComponent<Script_GameManager>().QuitGame();
        // Debug.Log("Quit button executed successfully");
    }

    // Instantiates the timer prefab and displays it on the Canvas
    void DisplayTimer()
    {
        // If the timer is not already displayed (this defaults to false)
        if(_isTimerDisplayed == false)
        {   
            // Debug.Log("Displaying timer...");

            // Instantiates the prefab
            _timerTMP = Instantiate(_timerTMP, new Vector3(113.0f,18.0f,0), Quaternion.identity) as GameObject;

            // Parents it to the Canvas
            _timerTMP.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

            // Sets the text element
            _countDown = _timerTMP.GetComponent<TextMeshProUGUI>();

            // Timer is now displayed in this scene
            _isTimerDisplayed = true;

            // Debug.Log("Timer displayed");
        }
        // This function has already been executed in this scene
        else
        {
            // Debug.Log("Timer is already displayed");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Makes the timer count down while the minigame is running
        if(_minigameManager.GetComponent<Script_MinigameManager>()._isMinigameRunning == true)
        {
            // Countdown and update the UI
            _timeRemaining -= Time.deltaTime;
            // Display the time remaining
            _countDown.text = ($"00:{_timeRemaining}");
            
            // If there is no time remaining...
            if (_timeRemaining < 0)
            {
                // Display the countdown as 00:00
                _countDown.text = ("00:00");
                // The player loses
                _gameManager.GetComponent<Script_MinigameManager>().MinigameFailed();
                // Debug.Log("Out of time...");
            }
        }       
    }

    // Resets the countdown
    public void TimerReset()
    {
        _timeRemaining = _timeAllowed;
        // Debug.Log("Timer has been reset");
    }

    public void LoseLifeScreen()
    {
        _loseLifeImage.SetActive(true);
        // Debug.Log("Image displayed");
        DisplayQuitButton();
        DisplayContinueButton();
        DisplayTitleButton();
        // Debug.Log("Buttons displayed");
    }

    public void GameOverScreen()
    {
        _loseGameImage.SetActive(true);
        // Debug.Log("Image displayed");
        DisplayQuitButton();
        DisplayTitleButton();
        // Debug.Log("Buttons displayed");
    }

    public void GameWonScreen()
    {
        _winGameImage.SetActive(true);
        // Debug.Log("Image displayed");
        DisplayQuitButton();
        DisplayTitleButton();
        // Debug.Log("Buttons displayed");
    }
}
