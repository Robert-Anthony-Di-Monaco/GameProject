using UnityEngine;
using System.Collections;

public class TestingCamera : MonoBehaviour
{
    public Transform TargetAnchor;
    public float sensitivity;
    float rotX, rotY;
    
	void Start ()
    {
        rotX = Input.GetAxis("Mouse Y");
        rotY = Input.GetAxis("Mouse X");
    }
	
	void Update ()
    {
        transform.position = TargetAnchor.position;

        // Only rotate the camera if Mouse-Right-Click is held down
        if (Input.GetMouseButton(1))
        {
            rotX -= Input.GetAxis("Mouse Y");
            rotY += Input.GetAxis("Mouse X");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotX, rotY, 0), sensitivity * Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(0))
        {
            ResetCamera();
        }
    }
    void FixedUpdate()
    {
        if (Physics.Linecast(transform.position, TargetAnchor.parent.position))
        {

        }
    }

    // Reset camera back to default orientation
    void ResetCamera()
    {
        transform.rotation = Quaternion.Euler(20f, 0, 0);
        transform.forward = (TargetAnchor.position - transform.position).normalized;
    }
}

// If all die, go back to last one, check if its null
/*  
 *  Camera moves to other point quickly see all inbetween  
 */

    // Rigidbody/Agent use velocity to position camera behind




/*
    Slowly rotate to go to face so can see it from the another view, 
    Also to go under stuff
     */