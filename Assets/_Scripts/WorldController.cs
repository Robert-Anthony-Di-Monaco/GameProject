using UnityEngine;
using System.Collections;

/*
    Volcano --> switch + boom + smoke + lower lake 
    Water Switch  --> waterfall + raise lake
    Elevator + barriers
     
*/

public class WorldController : MonoBehaviour
{
    // World event objects
    public GameObject Lake,
                      playerElevator, enemyElevator,   // 275.4 ---> 26.1  for enemy, 97.45 for player
                      leftElevator, rightElevator;     // 251 --> 0.1

	void Start ()
    {
	    
	}
	
	void Update ()
    {
        //if(button pressed)
            //moveElevator(leftElevator)
	}

    /* Raise or Lower elevator when activated
     *      parameter: which elevator to move     
    */ void moveElevator(GameObject elevator)
    {
                
    }

    // Activate Volcano eruption
    void erupt()
    {

    }

    /* Moves the Lake up or down 
     *      parameter: direction the lake moves in 
    */ void moveLake(string direction)
    {

    }
}