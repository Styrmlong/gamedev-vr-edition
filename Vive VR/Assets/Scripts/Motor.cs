using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 finalVelocity = Vector3.zero;
    private Vector3 finalRotation = Vector3.zero;
    private Vector3 finalCamRotation = Vector3.zero;
    private Vector3 finalJumpVelocity = Vector3.zero;

    [SerializeField]
    private float jumpHeight = 10f;

    [SerializeField]
    private Camera mainCam;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        performMovement();
        //performRotation();


    }

    //Takes in the velocity vector from PlayerController
    public void move(Vector3 velocity)
    {
        finalVelocity = velocity;
    }

    void performMovement()
    {
        rb.MovePosition(rb.position + finalVelocity * Time.fixedDeltaTime);
    }

}
