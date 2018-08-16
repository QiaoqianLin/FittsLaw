using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Task : MonoBehaviour {
    static GameObject[] gameObjects;
    List<int> generatedNumber = new List<int>();
    GameObject currentObject;
    int index;
    GameObject cyls;
    // Use this for initialization


    void Start () {
        cyls = GameObject.Find("cyls");
        List<GameObject> children = new List<GameObject>();
        foreach (Transform tran in cyls.transform)
        {
            children.Add(tran.gameObject);
        }
        gameObjects = children.ToArray();

        getIndex();
    }

    void getIndex()
    {

        index = Random.Range(0, gameObjects.Length);
    
        generatedNumber.Add(index);
        currentObject = gameObjects[index];

        currentObject.tag = "Untagged";
        //currentObject.GetComponent<Renderer>().material.color = Color.white;
        task();


    }

    // Update is called once per frame
    void task() {
        

        if (currentObject.tag == "Untagged")
        {
            currentObject.tag = "target";
            currentObject.GetComponent<Renderer>().material.color = Color.green;
        }
        if (currentObject.tag == "target")
        {
            print("got target");
            currentObject.GetComponent<VRTK_InteractableObject>().InteractableObjectUsed += Task_InteractableObjectUsed;
        }
        else if (currentObject.tag == "selected")
        {
            getIndex();
        }
        
        

    }

    private void Task_InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        currentObject.GetComponent<Renderer>().material.color = Color.white;
        Debug.Log("correct");
        currentObject.tag = "selected";
        currentObject.GetComponent<VRTK_InteractableObject>().InteractableObjectUsed -= Task_InteractableObjectUsed;
        getIndex();
    }
}
