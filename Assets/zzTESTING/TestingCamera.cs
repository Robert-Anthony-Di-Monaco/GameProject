using UnityEngine;
using System.Collections;

public class TestingCamera : MonoBehaviour
{
    public Transform TargetAnchor;
    public float sensitivity;
    float rotX, rotY;
    float centerX, centerY;
    float lastMouseX, lastMouseY;
    Vector3 newForward = Vector3.zero;  
    
	void Start ()
    {
        rotX = Input.GetAxis("Mouse Y");
        rotY = Input.GetAxis("Mouse X");

        //centerX = Screen.width / 2;
        //centerY = Screen.height / 2;
        lastMouseX = Input.mousePosition.x;
        lastMouseY = Input.mousePosition.y;
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isMouse)
        {
            //lastMouseX = Input.mousePosition.x;
            //lastMouseY = Input.mousePosition.y;

            float targetX = lastMouseX + e.delta.magnitude * e.delta.normalized.x;
            float targetY = lastMouseY + e.delta.magnitude * e.delta.normalized.y;
            newForward = (new Vector3(targetX, targetY, 0) - transform.position).normalized;
            //transform.rotation = Quaternion.FromToRotation(transform.forward, newForward);

            if (e.mousePosition.x > centerX)
            {
                rotY -= 5f;
            }
            else if (e.mousePosition.x < centerX)
            {
                rotY += 5f;
            }

            if (e.mousePosition.y > centerY)
            {
                rotX += 5f;
            }
            else if (e.mousePosition.y < centerY)
            {
                rotX -= 5f;
            }
        }

        //centerX = Input.mousePosition.x;
        //centerY = Input.mousePosition.y;
    }


    void Update ()
    {
        lastMouseX = Input.mousePosition.x;
        lastMouseY = Input.mousePosition.y;
        transform.position = TargetAnchor.position;

        // Only rotate the camera if Mouse-Right-Click is held down
        if (Input.GetMouseButton(1))
        {
            //rotY += Input.GetAxis("Mouse X");
            //rotX -= Input.GetAxis("Mouse Y");
            //rotX = Mathf.Clamp(rotX, -35f, 75f);

            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotX, rotY, 0), 0.05f);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.FromToRotation(transform.forward, newForward), 0.05f);
            
        }
        if (Input.GetMouseButtonDown(1))
        {
            //ResetCamera();
        }
    }
    void FixedUpdate()
    {
        if (Physics.Linecast(transform.position, TargetAnchor.parent.position))
        {

        }
    }
    void LateUpdate()
    {
       
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

    




/*
    Slowly rotate to go to face so can see it from the another view, 
    Also to go under stuff
     */