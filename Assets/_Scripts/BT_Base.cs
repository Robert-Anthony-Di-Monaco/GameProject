using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Random = UnityEngine.Random;
using Coroutine = System.Collections.IEnumerator;
using BTCoroutine = System.Collections.Generic.IEnumerator<BTNodeResult>;

public class BT_Base : MonoBehaviour
{
    public Transform NavMeshTarget;

    private BehaviorTree bt;

    void Awake()
    {
        InitBT();
        bt.Start();
    }

    void Update()
    {
    }

    private void InitBT()
    {
        bt = new BehaviorTree(Application.dataPath + "/_Scripts/BT_Tree_Example.xml", this);
    }

    // Condition
    [BTLeaf("")]
    public bool TooManyChasers()
    {
        return false;
    }
    
    // Leaf
    [BTLeaf("")]
    public BTCoroutine Chase()
    {
       yield return BTNodeResult.NotFinished;
    }
}



