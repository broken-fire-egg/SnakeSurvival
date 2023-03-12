using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyClass : MonoBehaviour
{
    protected SnakeBody snakeBody; 
    public GameObject bulletpref;
    public float shoottime;
    public float cooltime;
    protected virtual void Start()
    {
        snakeBody = GetComponent<SnakeBody>();
    }
}
