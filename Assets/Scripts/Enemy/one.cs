using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class one : MonoBehaviour
{
    public enum Direction
    {
        right,
        down,
        left,
        up
    }

    Direction a;

    void Start()
    {
    }

    void Update()
    {
        Debug.Log(a++);
    }
}
 