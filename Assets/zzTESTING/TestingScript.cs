using UnityEngine;
using System.Collections;

public class TestingScript : MonoBehaviour
{
    RaycastHit hitInfo = new RaycastHit();
    NavMeshAgent agent;
    bool underControl = true;  // Is the player controlling this NPC

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && underControl)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
                agent.destination = hitInfo.point;
        }
    }
}


