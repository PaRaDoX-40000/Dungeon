using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test4:MonoBehaviour
{
    public Test2 test2;
    public Test3 test3;

    private void Start()
    {
        
        if(test2 == test3)
        {
            Test3 test = (Test3)test2;
            Debug.Log(test.str);
        }
        else
        {
            Debug.Log(false);
        }

    }

}
