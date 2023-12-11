using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_SceneManager : MonoBehaviour
{
    public GameObject _gameManager;
    public GameObject _minigameManager;
    
    // All scenes in the order they appear in the build settings
    private List<string> _sceneIndexList = new List<string> {"Main","Credits","Capture","Posession","Cupboards","Difference","Cleaning","Gooing"};

    // Defaults to the main menu just in case
    //private int _currentSceneIndex = 0;
    private int _nextSceneIndex = 0;
    public string _nextSceneName = "Main";
    public string _nextSceneType = "Menu";

    // Sets the next name of the scene to be loaded
    private void SetNextName()
    {
        _nextSceneName = _minigameManager.GetComponent<Script_MinigameManager>()._minigamesRemaining[_minigameManager.GetComponent<Script_MinigameManager>()._currentMinigame];
        // Debug.Log($"Name of next scene to be loaded : {_nextSceneName}");
    }
    
    // Sets the next index of the scene to be loaded
    private void SetNextIndex()
    {        
        _nextSceneIndex = _sceneIndexList.IndexOf(_nextSceneName);
        // Debug.Log($"Index of next Scene to be loaded : {_nextSceneIndex}");
    }
    
    // Trying to fix the issue where all my scenes load at once by using asynchronous loads
    // This was a beast to try and figure out lmfao
    public IEnumerator PlsLoadSceneAsync()
    {
        // Delicious coroutines mmm yummy
        yield return null;
        
        if(_nextSceneType == "Minigame")
        {
            SetNextName();
            // Debug.Log("Next name set");
        }
        else if(_nextSceneType == "Menu")
        {
            // Debug.Log("Next scene type is Menu");
        }
        
        SetNextIndex();
        // Debug.Log("Next index set");
        
        // Debug.Log("Load Scene Async function called...");
        
        int _sceneBuildIndex = _nextSceneIndex;
        
        AsyncOperation _loadSceneAsync = SceneManager.LoadSceneAsync(_sceneBuildIndex);
        // Debug.Log("Scene loaded asynchronously");

        //AsyncOperation.allowSceneActivation = true;
        // Debug.Log("Scene activation allowed");

        // Debug.Log("Load Scene Async function executed successfully");
        
        yield return null;
    }
    
    /* Async function removes the need for this
    // Retrieves the name of the active scene
    public void SetCurrentSceneName(Scene scene)
    {
        scene = SceneManager.GetActiveScene();
        Debug.Log($"Scene : {scene.name as string}");
    } */

    /* Async function removes the need for this
    // Loads and sets the credits scene as active
    public void CreditsScene()
    {
        Debug.Log("Credits Scene function called...");
        
        // Loads credits scene
        SceneManager.LoadScene("Scene_Credits", LoadSceneMode.Additive);
        Debug.Log("Loaded credits scene...");

        // Sets credits scene as active
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene_Credits"));
        Debug.Log("Set credits scene as active...");

        Debug.Log("Credits Scene function executed successfully");
    } */
    
    /* Async function removes the need for this
    // Loads and sets the next scene as active
    public string ChangeScene(string _nextActiveScene, string _currentActiveScene)
    {
        // Next active scene is equivalent to the game chosen in the minigame manager
        _nextActiveScene = _sceneIndexList[_minigameManager.GetComponent<Script_MinigameManager>().NextMinigame()];
        
        // Loads the scene
        SceneManager.LoadScene($"{_nextActiveScene}", LoadSceneMode.Additive);
        // Tells us which scene is now loaded
        Debug.Log($"Loaded {_minigameManager.GetComponent<Script_MinigameManager>()._minigamesList[_minigameManager.GetComponent<Script_MinigameManager>().NextMinigame()]} scene");

        // Sets the scene as active
        SceneManager.SetActiveScene(SceneManager.GetSceneByName($"{_nextActiveScene}"));
        // Tells us which scene is now active
        Debug.Log($"Set {_minigameManager.GetComponent<Script_MinigameManager>()._minigamesList[_minigameManager.GetComponent<Script_MinigameManager>().NextMinigame()]} as active scene");

        // What was next in line is now current
        _currentActiveScene = _nextActiveScene;

        // Next is now empty
        _nextActiveScene = null;
        
        //return scene.name;
        return _currentActiveScene;
    } */
}