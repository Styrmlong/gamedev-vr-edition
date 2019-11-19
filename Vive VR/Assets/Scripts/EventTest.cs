//This Script is just for testing the EventSystem

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    public int id = 69;
    public int id2 = 420;

    public Transform girl;
    public Transform ball;

    private AudioSource audio;



    void Start()
    {
        EventSystem.eventController.onTestEventTrigger += TestEvent;
        EventSystem.eventController.onTestEventTrigger += TestMultiEvent;
        EventSystem.eventController.onTestEventTrigger += TestMultiEventSecond;

        audio = GetComponent<AudioSource>();

    }

    private void TestEvent(int id)
    {
        if (id == this.id)
        {
            Debug.Log("Successful Test ID: " + id);
            girl.position = ball.position;
            audio.Play();

        }
    }

    private void TestMultiEvent(int id) 
    {
        if (id == id2) 
        {
            Debug.Log("Successful Test!!!");
            Debug.Log(id2 + "!!!!");
        }
    }

    private void TestMultiEventSecond(int id)
    {
        if (id == id2)
        {
            Debug.Log("BLAZE IT!!!!!!!");
        }
    }
}
