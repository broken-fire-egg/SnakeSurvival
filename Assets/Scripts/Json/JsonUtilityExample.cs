using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonUtilityExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //JsonTestClass jTest1 = new JsonTestClass();
        //string jsonData = JsonUtility.ToJson(jTest1);
        //Debug.Log(jsonData);

        //JsonTestClass jTest2 = JsonUtility.FromJson<JsonTestClass>(jsonData);
        //jTest2.Print();

        JsonVector jVector = new JsonVector();
        string jsonData = JsonUtility.ToJson(jVector);
        Debug.Log(jsonData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
