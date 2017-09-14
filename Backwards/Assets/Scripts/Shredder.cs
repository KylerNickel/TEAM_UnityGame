using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

    private void OnTriggerEnter(Collider trigger)
    {
        foreach (Transform child in trigger.transform)
        {
            if (child.gameObject.tag == "Model")
            {
                Destroy(child.gameObject);
                Debug.Log("You fell out of the world!");
                // TODO Add respawning function.
                Cursor.visible = true;
            }
        }

    }
}
