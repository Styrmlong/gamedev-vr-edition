using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint next;

    public Vector3 GetPos() 
    {
        return new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
