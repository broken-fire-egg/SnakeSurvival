using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BodyClass : MonoBehaviour
{
    protected SnakeBody snakeBody; 
    public GameObject bulletpref;

    public Sprite bodyIcon;

    public float damage;

    public float shoottime;
    public float cooltime;

    public int level;

    public string bodyName;
    public string bodyDescription;


    protected virtual void Start()
    {
        snakeBody = GetComponent<SnakeBody>();
    }
    public abstract void SetBodyInfo();
    public abstract void LevelUp();
}
