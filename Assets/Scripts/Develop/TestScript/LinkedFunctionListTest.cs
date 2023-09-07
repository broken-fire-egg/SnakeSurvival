using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedFunctionListTest : MonoBehaviour
{
    public LinkedFunctionList<float> LFL1;
    public LinkedFunctionList<float> LFL2;
    void Start()
    {
        LFL1 = new LinkedFunctionList<float>(FirstFunc).AppendFunction(SecondFunc).AppendFunction(ThirdFunc);
        Debug.Log("LFL1 result : " + LFL1.Function(8f));

        LFL2 = LFL1;
    }
     
    public float FirstFunc(float args)
    {
        Debug.Log("first function parameter : " + args.ToString());
        return (float)args + 1f;
    }
    public float SecondFunc(float args)
    {
        Debug.Log("second function parameter : " + args.ToString());
        return (float)args * 2f;
    }
    public float ThirdFunc(float args)
    {
        Debug.Log("third function parameter : " + args.ToString());
        return (float)args - 3f;
    }
}
