using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public GameObject target;

    private void Update()
    {
        if(target)
        transform.position = target.transform.position - new Vector3(0,0,10);
    }
    // Start is called
}
