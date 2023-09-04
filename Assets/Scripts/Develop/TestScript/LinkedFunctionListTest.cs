using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedFunctionListTest : MonoBehaviour
{
    public LinkedFunctionList<float> LFL;
    // Start is called before the first frame update
    void Start()
    {
       LFL = new LinkedFunctionList<float>(firstFunc).AppendFunction(secondFunc).AppendFunction(thirdFunc);

       Debug.Log(LFL.Function(8f));
    }

    public float firstFunc(float args)
    {
        Debug.Log("first" + args.ToString());
        return (float)args + 1f;
    }
    public float secondFunc(float args)
    {
        Debug.Log("second" + args.ToString());
        return (float)args * 2f;
    }
    public float thirdFunc(float args)
    {
        Debug.Log("third" + args.ToString());
        return (float)args - 3f;
    }
}
