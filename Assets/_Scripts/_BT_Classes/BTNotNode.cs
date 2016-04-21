using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

using Random = UnityEngine.Random;
using Coroutine = System.Collections.IEnumerator;
using BTCoroutine = System.Collections.Generic.IEnumerator<BTNodeResult>;

/*
    PLEASE NOTE: This class and all other classes in the BT Classes Folder was not written by me(Robert Anthony Di Monaco) 
                 They were taken from a school Lab assignment and were created for the students to use by the TA/Professor 
                 I did go through every class, comments were all written by myself ---> so I understand the code
*/

public class BTNotNode : BTNode
{
    private BTNode childNode;

    public BTNotNode(BTNode childNode)
    {
        this.childNode = childNode;
    }

    public override BTCoroutine Procedure()
    {
        BTCoroutine routine = childNode.Procedure();

        while (routine.MoveNext())
        {
            BTNodeResult result = routine.Current;

            if (result == BTNodeResult.NotFinished)
                yield return BTNodeResult.NotFinished;
            else
            {
                yield return result == BTNodeResult.Failure ? BTNodeResult.Success : BTNodeResult.Failure;
                yield break;
            }
        }
    }
}
