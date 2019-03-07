using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makingRays : MonoBehaviour
{
    // public float rayDistance = 2; 

    public float cameraRayDistance = 40;
    public Transform paintCube;
    public bool pinWheelMode; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(mouseRay.origin, (mouseRay.direction * cameraRayDistance), Color.red);

        RaycastHit myHit;

        if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out myHit, cameraRayDistance)) {

            paintCube.transform.position = myHit.point;

            if (myHit.transform.tag == "Ground")
            {
                myHit.transform.Rotate(0, 1, 0); // once you hit with a ray on the transform you can have all of the object, gameObject for ex.)
                
            }
        }

        if (Input.GetMouseButton(0))
        {
            Transform newCube = Instantiate(paintCube, paintCube.transform.position, Quaternion.Euler(0, 0, 0)); 

            if (pinWheelMode)
            {
                newCube.SetParent(myHit.transform, true); 
            }
        
        }        


        //Ray myRay = new Ray(this.transform.position, Vector3.down);
        //Debug.DrawRay(myRay.origin, new Vector3(0, -rayDistance, 0), Color.red);

        //RaycastHit myHit;

        //if (Physics.Raycast(myRay.origin, myRay.direction, out myHit, rayDistance))
        //{
        //    print("it hit " + myHit.rigidbody.transform); 
        //}
    }
}
