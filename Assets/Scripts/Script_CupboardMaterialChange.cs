using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_CupboardMaterialChange : MonoBehaviour
{
    //Declaration
    public Material closedDoor;
    public Material openDoor;
    Ray ray;
    // Start is called before the first frame update
    void OnEnable()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeMaterial();
        }*/
        //I was testing to see if this worked and it does :P
    }

    public void ChangeMaterialToOpen()
    {
        gameObject.GetComponent<MeshRenderer>().material = openDoor;
    }

    public void ChangeMaterialToClosed()
    {
        gameObject.GetComponent<MeshRenderer>().material = closedDoor;
    }



}
