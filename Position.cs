using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Position : MonoBehaviour {

    // Use this for initialization
    VRTK_Pointer pointer;

    // Use this for initialization
    void Start()
    {
        GameObject[] gameObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        pointer = GetComponent<VRTK_Pointer>();
        
        foreach (GameObject i in gameObjects)
        {
            if (i.GetComponent<VRTK_InteractableObject>() != null)
            {
                i.GetComponent<VRTK_InteractableObject>().InteractableObjectUsed += Position_InteractableObjectUsed;
            }
            
        }
        
    }

    private void Position_InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        Debug.Log(sender.ToString() + pointer.pointerRenderer.GetDestinationHit().point + Time.realtimeSinceStartup.ToString());
    }

}
