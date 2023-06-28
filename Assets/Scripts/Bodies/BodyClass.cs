using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyClass : MonoBehaviour
{
    protected SnakeBody snakeBody; 
    public GameObject bulletpref;

    public float shoottime;
    public float cooltime;


    public string bodyName;
    public string bodyDescription;
    
    public virtual void SetBodyInfo()
    {
        bodyName = "%ColleagueName%";
        bodyDescription = "%bodyDescription%";
    }

    protected virtual void Start()
    {
        snakeBody = GetComponent<SnakeBody>();
    }
}
