using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        EventSystem.eventController.TestEventTrigger(id);
    }
}
