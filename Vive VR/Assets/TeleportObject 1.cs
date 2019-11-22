using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    public Transform storedObject;
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            TeleportStoredObject();
        }
    }

    public void TeleportStoredObject() 
    {
        storedObject.position.Set(transform.position.x, transform.position.y, 0.0f);
    }

    public void TeleportToLocation(Transform objectTransform) 
    {
        objectTransform.position.Set(transform.position.x, transform.position.y, 0.0f);
    }
}
