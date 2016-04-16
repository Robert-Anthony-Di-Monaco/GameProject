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

public class BTSelector : BTNode
{
    private BTNode[] subNodes;

    public BTSelector(IEnumerable<BTNode> subNodes)
    {
        this.subNodes = subNodes.ToArray();
    }

    public BTSelector(params BTNode[] subNodes)
    {
        this.subNodes = subNodes;
    }

    public override BTCoroutine Procedure()
    {
        foreach (BTNode node in subNodes)
        {
            BTCoroutine routine = node.Procedure();

            while (routine.MoveNext())
            {
                BTNodeResult result = routine.Current;

                if (result == BTNodeResult.Success)
                {
                    yield return BTNodeResult.Success;
                    yield break;
                }
                else
                {
                    yield return BTNodeResult.NotFinished; 
                    
                    if (result == BTNodeResult.Failure)
                        break;
                }
            }
        }

        yield return BTNodeResult.Failure;
    }
}