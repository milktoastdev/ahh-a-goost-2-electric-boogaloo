using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Script_Karl_JobApp : MonoBehaviour
{

    public float intimAdd = 0.75f;
    public Slider mainSlider;
    public List<float>
        intimValList;
    public float jobOne = 0.5f;
    public float jobTwo = 0.25f;
    public float jobThree = 0.75f;
    public Button buttonOne;
    public Button buttonTwo;
    public Button buttonThree;
    public GameObject JobAppUI;
    public int gameFailI = 0;

    // Start is called before the first frame update
    void Start()
    {
        intimValList.Add(0.25f);
        intimValList.Add(0.5f);
        intimValList.Add(0.75f);
        JobAppUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameStart()
    {
        JobAppUI.gameObject.SetActive(true);
    }
    //I can probably get all of these functions working as a single function.
    //However, each button pulls a function. I could have if statements that check which button
    //has been pressed but at the moment I am trying to ensure this works. Thats priority
    public void JobOne()
    {
        mainSlider.value += jobOne;
        SetJobs();
    }

    public void JobTwo()
    {
        mainSlider.value += jobTwo;
        SetJobs();
    }

    public void JobThree()
    {
        mainSlider.value += jobThree;
        SetJobs();
    }

    void SetJobs()
    {
        int jobOneI = Random.Range(0, 3);
        jobOne = intimValList[jobOneI];


        int jobTwoI = Random.Range(0, 3);
        jobTwo = intimValList[jobTwoI];


        int jobThreeI = Random.Range(0, 3);
        jobThree = intimValList[jobThreeI];

        gameFailI += 1;
        if (gameFailI == 5)
        {
            GameFail();
        }
    }

    public void GameFail()
    {
        print("You suck");
        buttonOne.gameObject.SetActive(false);
        buttonTwo.gameObject.SetActive(false);
        buttonThree.gameObject.SetActive(false);
    }
}
