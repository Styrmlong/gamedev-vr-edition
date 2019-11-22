using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaughEvent : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audio;

    public int id = 1;
    void Start()
    {
        EventSystem.eventController.onTestEventTrigger += laugh;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void laugh(int id)
    {
        if (id == this.id)
        {
            Debug.Log("Successful Test ID: " + id);
            audio.Play();

        }
    }
}
