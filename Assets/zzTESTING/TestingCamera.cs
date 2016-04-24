using UnityEngine;
using System.Collections;

public class TestingCamera : MonoBehaviour
{
    public Transform TargetAnchor; 
    float rotX = 0, rotY = 0;
    float sensitivity = 5f;

	void Start ()
    {
        TargetAnchor = GameObject.Find("TestPlayer").transform;
	}
	
	void Update ()
    {
        transform.position = new Vector3(TargetAnchor.position.x, TargetAnchor.position.y + 50f, TargetAnchor.position.z - 55f);

        // Only rotate camera if right-click held down
        if (Input.GetMouseButton(1))
        {
            rotX -= Input.GetAxis("Mouse Y") * sensitivity;
            rotY += Input.GetAxis("Mouse X") * sensitivity;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotX, rotY, 0), sensitivity);
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
