using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public enum Direction
    {
        right,
        down,
        left,
        up
    }

    public enum Type
    {
        normal,
        archer,
        ghost,
        explosion,
        horseman,
        wizard,
        corrosion,
        healer
    }

    public GameObject       Player;
    public GameObject       SelfRelatedObj;

    public float            maxhp;
    public float            hp;
    public float            Speed;
    public float            time;

    public bool             MoveCheck = false;
    public bool             MoveBool = true;

    public IEnumerator      ieum;
    public Direction        dir;
    public Type             EnemyType;




    protected virtual void Start()
    {
        ieum = MoveCor();
        StartCoroutine(ieum);
            Player = GameObject.Find("Head");
    }
    public void Hit(float damage)
    {
        hp -= damage;
        CheckDead();
    }


    public void CheckDead()
    {
        if (hp <= 0)
        {
            EXPManager.instance.itemOP.GetRestingPoolObject().SetPositionAndActive(transform.position);
            Destroy(gameObject);
        }
    }

    protected virtual void Update()
    {
        if (MoveBool)
            Move();
    }

    IEnumerator MoveCor()
    {
        while (true)
        {
            if (Player != null)
                MoveWidth();
            yield return new WaitForSeconds(0.5f);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            Destroy(collision.gameObject);
    }

    void MoveWidth()
    {
        if (Vector2.Distance(Player.transform.position, transform.position) > 1f)
        {
            if (Mathf.Abs(Player.transform.position.x - transform.position.x) > Mathf.Abs(Player.transform.position.y - transform.position.y))
            {
                if (Mathf.Round(Player.transform.position.x) > Mathf.Round(transform.position.x))
                    dir = Direction.right;

                else
                    dir = Direction.left;
            }
            else
            {
                if (Mathf.Round(Player.transform.position.y) > Mathf.Round(transform.position.y))
                    dir = Direction.up;

                else// if (Mathf.Round(Player.transform.position.y) < Mathf.Round(transform.position.y))
                    dir = Direction.down;
            }

        }
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
