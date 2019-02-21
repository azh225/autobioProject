using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsController : MonoBehaviour
{
    public Rigidbody thisRigidBody; //variable for the rigidbody
    public Camera thisCamera;

    public float fpForwardBackward;
    public float fpStrafe;

    public float pitch; //select a variable, press f2, can change the name of your variable everywhere in the script
    public float yaw; // yaw is mouseX, pitch is mouseY

    public Vector3 inputVelocity;
    public float velocityModifier;

    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        yaw = Input.GetAxis("Mouse X");
        transform.Rotate(0, yaw, 0);

        pitch = Input.GetAxis("Mouse Y");
        thisCamera.transform.Rotate(-pitch, 0, 0);

        fpForwardBackward = Input.GetAxis("Vertical");
        fpStrafe = Input.GetAxis("Horizontal");

        inputVelocity = transform.forward * fpForwardBackward;
        inputVelocity += transform.right * fpStrafe;
    }

    void FixedUpdate()
    {
        thisRigidBody.velocity = inputVelocity * velocityModifier + (Physics.gravity * .69f);
    }
}
