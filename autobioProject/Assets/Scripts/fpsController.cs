using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsController : MonoBehaviour
{
    public Rigidbody playerRigidBody; //variable for the rigidbody
    public Camera thisCamera;

    public float fpForwardBackward;
    public float fpSide;

    public float mouseY; //select a variable, press f2, can change the name of your variable everywhere in the script
    public float mouseX; // yaw is mouseX, pitch is mouseY

    public Vector3 inputVelocity;
    public float velocityModifier;

    public float jumpForce;
    public float groundCheck;
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX, 0);

        mouseY = Input.GetAxis("Mouse Y");
        thisCamera.transform.Rotate(-mouseY, 0, 0);

        fpForwardBackward = Input.GetAxis("Vertical");
        fpSide = Input.GetAxis("Horizontal");

        bool canJump = false;

        Ray jumpingRay = new Ray();

        jumpingRay.origin = transform.position;
        jumpingRay.direction = Vector3.down;

        RaycastHit hit;
       
        Debug.DrawRay(jumpingRay.origin, jumpingRay.origin + jumpingRay.direction * groundCheck, Color.yellow);
       
        if (Physics.Raycast(jumpingRay, out hit,groundCheck))
        {
            if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("Tile"))
            {
                canJump = true;
            }
        }

        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidBody.AddForce(Vector3.up*jumpForce, ForceMode.Impulse); 
        }

        inputVelocity = transform.forward * fpForwardBackward;
        inputVelocity += transform.right * fpSide;
    }

    void FixedUpdate()
    {
        playerRigidBody.velocity += inputVelocity * velocityModifier;//= inputVelocity * velocityModifier + (Physics.gravity * .69f);
        Vector2 xZvelocity = new Vector2(playerRigidBody.velocity.x, playerRigidBody.velocity.z);

        xZvelocity = Vector2.ClampMagnitude(xZvelocity, 5f);
        playerRigidBody.velocity = new Vector3(xZvelocity.x, playerRigidBody.velocity.y, xZvelocity.y);
    }

}
