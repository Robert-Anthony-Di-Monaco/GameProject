using UnityEngine;
using System.Collections;

public class TestingCamera : MonoBehaviour
{
    public Transform TargetAnchor;
    float rotX = 0, rotY = 0;
    float sincePressedOnce = 0;
    bool pressedOnce = false;
    
    void Update ()
    {
        transform.position = TargetAnchor.position;

        // If user double clicks Right-Click reset the camera
        pressedOnce = ( Input.GetMouseButtonDown(1) && (Time.time - sincePressedOnce) < 1.5f ) ? true : false;
        if (Input.GetMouseButtonDown(1))
        {
            if (pressedOnce)
            {
                transform.forward = (TargetAnchor.position - transform.position).normalized;
                transform.rotation = Quaternion.Euler(25f, 0, 0);
            }
            else
                sincePressedOnce = Time.time;
        }   

        // If user holds down Right-Click rotate camera
        if (Input.GetMouseButton(1))
        {
            rotY += Input.GetAxis("Mouse X") * 3.5f;
            rotX -= Input.GetAxis("Mouse Y") * 2.5f;
            rotX = Mathf.Clamp(rotX, -35f, 60f);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotX, rotY, 0), 0.05f);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        }
    }
}

// If all die, go back to last one, check if its null
/*  
 *  Camera moves to other point quickly see all inbetween  
 */