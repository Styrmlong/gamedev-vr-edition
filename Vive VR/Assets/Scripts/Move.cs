using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed = 3.5f;

    private Motor motor;
    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<Motor>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMovment = Input.GetAxisRaw("Horizontal");
        float yMovment = Input.GetAxisRaw("Vertical");

        Debug.Log(xMovment);
        Debug.Log(yMovment);

        //make a velocity vector that "pushes" the character
        Vector3 moveSide = transform.right * xMovment;
        Vector3 moveFront = transform.forward * yMovment;

        //the speed of the character
        Vector3 velocity = (moveSide + moveFront).normalized * speed;

        motor.move(velocity);

    }
}
