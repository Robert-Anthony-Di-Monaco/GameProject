using UnityEngine;
using System.Collections;

public class TestingCamera : MonoBehaviour
{
    public Transform TargetAnchor, AlternateAnchor;
    float rotX = 0, rotY = 0;
    
    void Update ()
    {
        transform.position = TargetAnchor.position;

        // If user holds down Right-Click rotate camera
        if (Input.GetMouseButton(1))
        {
            rotY += Input.GetAxis("Mouse X") * 3.5f;
            rotX -= Input.GetAxis("Mouse Y") * 2.5f;
            rotX = Mathf.Clamp(rotX, -35f, 60f);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotX, rotY, 0), 0.05f);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        }
        else   // Otherwise rotate back to face target
        {
            float savedRotX = transform.rotation.eulerAngles.x;
            Vector3 targetFwd = (TargetAnchor.parent.position - transform.position).normalized;
            transform.forward = Vector3.Slerp(transform.forward, targetFwd, 0.025f);
            transform.rotation = Quaternion.Euler(savedRotX, transform.rotation.eulerAngles.y, 0);
        }
        
        // 
        if (Input.GetKey(KeyCode.Q))
        {

        }

        // 
        if (Input.GetKey(KeyCode.W))
        {

        }

        // 
        if (Input.GetKey(KeyCode.E))
        {

        }

        // 
        if (Input.GetKey(KeyCode.R))
        {

        }

        // 
        if (Input.GetKey(KeyCode.Space))
        {

        }
    }

    void LateUpdate()
    {
        int terrainMask = 1 << 9;  // Get bit mask for terrain layer

        if (Physics.Linecast(transform.position, TargetAnchor.transform.parent.position, terrainMask))
        {
            transform.position = Vector3.Lerp(transform.position, AlternateAnchor.position, 0.5f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, TargetAnchor.position, 0.5f);
        }
    }
}

/*  
 *  Camera moves to other point quickly see all inbetween  --> can look around during journey
 *  
 *  How attack based who clicked, formation based on this, rockets one target, guns go after another
 *  
 *  Doub le click to go to that view, lights it up see it so can go to it
 */
 