using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SansEvent : MonoBehaviour
{
    // Start is called before the first frame update

    public int id = 5;
    //public int id2 = 420;

    public Transform girl;
    public Transform ball;

    private AudioSource audio;
    void Start()
    {
        EventSystem.eventController.onTestEventTrigger += EasterEgg;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame


    private void EasterEgg(int id)
    {
        if (id == this.id)
        {
            Debug.Log("Successful Test ID: " + id);
            girl.position = ball.position;
            audio.Play();

        }
    }
}
