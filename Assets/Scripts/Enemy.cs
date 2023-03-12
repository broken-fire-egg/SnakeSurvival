using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EXPManager;

public class Enemy : MonoBehaviour
{
    public float hp;
    public GameObject Player;

    public enum Direction { right, down, left, up }

    public Direction dir;
    public bool test = false;
    public float Speed;
    void Start()
    {
        Player = GameObject.Find("Head");
    }
    public void Hit(float damage)
    {

    }
    private void Update()
    {
        if (test)
            CheckLength();
        else
            CheckWidth();
        //Move();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
            Destroy(collision.gameObject);
        if (hp <= 0)
        {
            EXPManager.instance.itemOP.GetRestingPoolObject().SetPositionAndActive(transform.position);
            Destroy(gameObject);
        }
    }

    void CheckWidth()
    {
        if (Mathf.Round(Player.transform.position.x * 100) / 100 > Mathf.Round(transform.position.x * 100) / 100)
            //dir = Direction.right;
            transform.Translate(new Vector3(1, 0) * Speed);

        else if (Mathf.Round(Player.transform.position.x * 100) / 100 == Mathf.Round(transform.position.x * 100) / 100)
            test = true;
        else
            //dir = Direction.left;
            transform.Translate(new Vector3(-1, 0) * Speed);
    }
    void CheckLength()
    {
        if (Mathf.Round(Player.transform.position.y * 100) / 100 > Mathf.Round(transform.position.y * 100) / 100)
            //dir = Direction.up;
            transform.Translate(new Vector3(0, 1) * Speed);

        else if (Mathf.Round(Player.transform.position.y * 100) / 100 < Mathf.Round(transform.position.y * 100) / 100)
            //dir = Direction.down;
            transform.Translate(new Vector3(0, -1) * Speed);
        else
            test = false;
    }

    void Move()
    {
        switch (dir)
        {
            case Direction.right:
                transform.Translate(new Vector3(1, 0) * Speed);
                break;
            case Direction.down:
                transform.Translate(new Vector3(0, -1) * Speed);
                break;
            case Direction.left:
                transform.Translate(new Vector3(-1, 0) * Speed);
                break;
            case Direction.up:
                transform.Translate(new Vector3(0, 1) * Speed);
                break;
        }
    }
}
