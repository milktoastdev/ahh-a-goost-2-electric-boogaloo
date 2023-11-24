using System.Collections;
using System.Collections.Generic;
// using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

// Bare minimum requirements all minigames should have in order to function
public class Script_Karl_Goo_Screen : MonoBehaviour
{
    // PLEASE MAKE A COPY OF THIS AND TITLE IT Script_[Name]_[Game]
    // EXAMPLE : Script_Karl_Flashing
    // PLEASE MAKE THE GAME THE SAME AS FOUND IN Script_MinigameTemplate

    public GameObject gooSpawn;
    float delay = 1.5f;
    float timer;
    int gooCount = 0;
    [SerializeField] private Renderer myMaterial;
    Ray ray;
    RaycastHit hit;
    int col;
    GameObject gooClone;
    private float time;
    int gooDestroyed = 0;

    // OnEnable is called before Start
    void OnEnable()
    {
        delay = Random.Range(0.8f, 2.4f);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay && gooCount != 5)
        {
            SpawnGoo();
            timer = 0f;
        }
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            col = (hit.colliderInstanceID);
            col.ToString();
            DestroyGoo();
        }
        if(gooDestroyed == 5)
        {
            Win();
        }
    }

    void SpawnGoo()
    {
        for(int i = 0; i < 1; i++)
        {
            if (gooCount == 5)
            {
                break;
            }
            float pos = Random.Range(-5.3f, 5.5f);
            float pos2 = Random.Range(-4.4f, 0.2f);
            float pos3 = Random.Range(-8.0f, -10.2f);

            gooClone = Instantiate(gooSpawn, new Vector3(pos, pos2, pos3), Quaternion.Euler(new Vector3(270, 0, 0)));
            GameObject[] gooToCount = GameObject.FindGameObjectsWithTag("Goo");
            gooCount = gooToCount.Length;
        }
    }

    void DestroyGoo()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Destroy(GameObject.Find("Goo(Clone)"));
            gooDestroyed = gooDestroyed +1;
            print(gooDestroyed);
        }
    }

    // Function for fail state

    void Win()
    {
        gooCount = 5;
        gooDestroyed = 0;
        print("You got rid of the goop!");
    }

    void Fail()
    {
        print("Get gooed idiot!");
    }

    // Functions to talk to higher scripts (UI, Minigame Manager, Game Manager etc.)
}
