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
    public string[] args;
    public string levelupDescription;

    protected virtual void Start()
    {
        snakeBody = GetComponent<SnakeBody>();
        args = new string[3];
        for (int i = 0; i < args.Length; i++)
            args[i] = "";
    }
    public abstract void SetBodyInfo(string discription, params object[] args);
    public abstract void LevelUp();
}
