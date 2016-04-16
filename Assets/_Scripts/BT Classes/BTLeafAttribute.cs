using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

using Random = UnityEngine.Random;
using Coroutine = System.Collections.IEnumerator;
using BTCoroutine = System.Collections.Generic.IEnumerator<BTNodeResult>;

/*
    PLEASE NOTE: This class and all other classes in the BT Classes Folder was not written by me(Robert Anthony Di Monaco) 
                 They were taken from a school Lab assignment and were created for the students to use by the TA/Professor 
                 I did go through every class, comments were all written by myself ---> so I understand the code
*/

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class BTLeafAttribute : Attribute
{
    public string LeafName { get; private set; }

    public BTLeafAttribute(string leafName)
    {
        LeafName = leafName;
    }
}
