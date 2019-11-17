using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class VR_Controller : MonoBehaviour
{
    public float m_Sensitivity = 0.1f;
    public float m_MaxSpeed = 5.0f;

    public float m_Gravity = 30.0f;

    public SteamVR_Action_Boolean m_MovePress = null;
    public SteamVR_Action_Vector2 m_MoveValue = null;

    private float m_Speed = 5.0f;

    private CharacterController m_CharacterController = null;
    public Transform m_CameraRig = null;
    public Transform m_Head = null;

    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //m_CameraRig = SteamVR_Render.Top().origin;
        //m_Head = SteamVR_Render.Top().head;
    }

    // Update is called once per frame
    void Update()
    {
        HandleHead();
        HandleHeight();
        CalculateMovement();

    }

    private void HandleHead()
    {
        //Store current
        Vector3 oldPosition = m_CameraRig.position;
        Quaternion oldRotation = m_CameraRig.rotation;

        //Rotation
        transform.eulerAngles = new Vector3(0.0f, m_Head.rotation.eulerAngles.y, 0.0f);

        //Restore
        m_CameraRig.position = oldPosition;
        m_CameraRig.rotation = oldRotation;


    }

    private void CalculateMovement()
    {
        //Movement orientation
        Vector3 orientationEuler = new Vector3(0, transform.eulerAngles.y, 0);
        Quaternion orientation = Quaternion.Euler(orientationEuler);
        Vector3 movement = Vector3.zero;

        //If not moving
        if (m_MovePress.GetStateUp(SteamVR_Input_Sources.Any))
        {
            //m_Speed = 0;
        }

        //If button pressed
        if (m_MovePress.state)
        {

            //Add, clamp
            Debug.Log("Supposed to move");
            m_Speed += m_MoveValue.axis.y * m_Sensitivity;
            Debug.Log("Move value y: " + m_MoveValue.axis.y);
            m_Speed = Mathf.Clamp(m_Speed, -m_MaxSpeed, m_MaxSpeed);

            //Orientation
            Debug.Log("Orientation: " + orientation + " Speed: " + m_Speed + " Vector3: " + Vector3.forward);

            movement += orientation * (m_Speed * Vector3.forward);
            Debug.Log("Movement variable: " + movement);

        }

        //Gravity
        movement.y -= m_Gravity * Time.deltaTime;

        //Apply
        m_CharacterController.Move(movement * Time.deltaTime);
    }

    private void HandleHeight()
    {
        //Get the head in local space
        float headHeight = Mathf.Clamp(m_Head.localPosition.y, 1, 2);
        m_CharacterController.height = headHeight;

        //Cut in half
        Vector3 newCenter = Vector3.zero;
        newCenter.y = m_CharacterController.height / 2;
        newCenter.y += m_CharacterController.skinWidth;

        //Move capsule in local space
        newCenter.x = m_Head.localPosition.x;
        newCenter.z = m_Head.localPosition.z;

        //Rotate
        newCenter = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * newCenter;

        //Apply
        m_CharacterController.center = newCenter;


    }
}
