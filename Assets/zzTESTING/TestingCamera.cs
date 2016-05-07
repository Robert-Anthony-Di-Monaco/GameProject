using UnityEngine;
using System.Collections;

public class TestingCamera : MonoBehaviour
{
    public Transform TargetAnchor; 
    float rotX = 0, rotY = 0;
    float sensitivity = 5f;

	void Start ()
    {
       
	}
	
	void Update ()
    {
        transform.position = TargetAnchor.position;

        // Only rotate the camera if Mouse-Right-Click is held down
        if (Input.GetMouseButton(1))
        {
            rotX -= Input.GetAxis("Mouse Y") * sensitivity;
            rotY += Input.GetAxis("Mouse X") * sensitivity;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotX, rotY, 0), sensitivity);
        }
    }
    void LateUpdate()
    {
        if (Physics.Linecast(transform.position, TargetAnchor.parent.position))
        {
            transform.position -= new Vector3(0, 10f, 0);
        }
    }

    // Reset camera back to default orientation
    void resetCamera()
    {
        //transform.position = new Vector3(TargetAnchor.position.x, TargetAnchor.position.y + 6f, TargetAnchor.position.z - 6f);
        transform.rotation = Quaternion.Euler(20f, 0, 0);
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
    Also for turning camera make it slower  ---> JUST ALTER SENETIVITY VAR UP TOP
     
     
     */