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
        up,
        none
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
    private RaycastHit2D hit;

    public GameObject Player;
    public GameObject SelfRelatedObj;

    public float maxhp;
    public float hp;
    public float Speed;
    public float time;

    public bool MoveCheck = false;
    public bool MoveBool = true;

    public IEnumerator ieum;
    public Direction dir;
    public Direction Lastdir;
    public Type EnemyType;

    private Tuple<float, float> WallLength;
    private Tuple<float, float> WallWidth;
    private bool testx, testy = false;
    private Direction Trick;



    bool CollCheck = false;
    bool Temp = false;
    bool test = true;
    bool UpDownCheck = false;
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
            //EXPManager.instance.itemOP.GetRestingPoolObject().SetPositionAndActive(transform.position);
            Destroy(gameObject);
        }
    }

    protected virtual void Update()
    {
        if(test)
            Move();
    }

    IEnumerator MoveCor()
    {
        while (true)
        {
            test = true;
            if (Player != null)
            {
                if (!MoveBool)
                    WallMove();
                else
                {
                    DirectionSet();
                }
            }

            yield return new WaitForSeconds(0.5f);
        }

    }
    Vector2 colvector;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("colstart");
        if (collision.transform.CompareTag("Player"))
            Destroy(collision.gameObject);
        if (collision.transform.CompareTag("Wall"))
        {
            test = false;
            CollCheck = true;
            MoveBool = false;
            Temp = false;
            colvector = new Vector2(gameObject.transform.position.x, transform.position.y);
            Trick = dir;
            Wallcheck(collision.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("colstay");
        //transform.position = colvector;
        //dir = Direction.down;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("colend");
        CollCheck = false;
    }
    void DirectionSet()
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

                else
                    dir = Direction.down;
            }

        }
    }


    void Wallcheck(GameObject wall)
    {
        WallWidth = new Tuple<float, float>(wall.transform.position.x - (wall.transform.localScale.x / 2), wall.transform.position.x + (wall.transform.localScale.x / 2));
        WallLength = new Tuple<float, float>(wall.transform.position.y + (wall.transform.localScale.y / 2), wall.transform.position.y - (wall.transform.localScale.y / 2));
        Debug.Log(WallLength.Item1);
    }
    void WallMove()
    {
        Debug.Log(WallLength.Item2);
        Debug.Log(transform.position.y);
        if ((WallLength.Item1 < transform.position.y || WallLength.Item2 > transform.position.y) && (WallWidth.Item1 < transform.position.x && WallWidth.Item2 > transform.position.x))
        {
            UpDownCheck = false;
            Debug.Log(testx);
            
            if (!testx)
            {
                if (Mathf.Abs(Mathf.Abs(transform.position.x) - Mathf.Abs(WallWidth.Item1)) <= Mathf.Abs(Mathf.Abs(transform.position.x) - Mathf.Abs(WallWidth.Item2)) && WallWidth.Item1 <= transform.position.x)
                    dir = Direction.left;

                else //if (Mathf.Abs(Mathf.Abs(transform.position.x) - Mathf.Abs(WallWidth.Item1)) > Mathf.Abs(Mathf.Abs(transform.position.x) - Mathf.Abs(WallWidth.Item2)) && WallWidth.Item2 >= transform.position.x)
                    dir = Direction.right;

            }
           // else
           // {
           //     if (Mathf.Abs(Mathf.Abs(transform.position.y) - Mathf.Abs(WallLength.Item1)) <= Mathf.Abs(Mathf.Abs(transform.position.y) - Mathf.Abs(WallLength.Item2)) && WallLength.Item1 <= transform.position.y && !Temp)
           //     {
           //         dir = Direction.down;
           //         Temp = true;
           //
           //     }
           //     else
           //     {
           //         if (!Temp)
           //         {
           //             dir = Direction.up;
           //             Temp = true;
           //         }
           //     }
           //
           //     if ( WallLength.Item2 - 2 > transform.position.y)
           //     {
           //         testy = true;
           //     }
           //     else if ( WallLength.Item1 + 2 < transform.position.y)
           //         testy = true;
           // }

        }
        if (WallWidth.Item1 >= transform.position.x || WallWidth.Item2 <= transform.position.x)
            testx = true;
        else//(WallWidth.Item1 > transform.position.x || WallWidth.Item2 < transform.position.x || UpDownCheck)
        {
            UpDownCheck = true;
            
            if (!testy)
            {
                if (Mathf.Abs(Mathf.Abs(transform.position.y) - Mathf.Abs(WallLength.Item2)) <= Mathf.Abs(Mathf.Abs(transform.position.y) - Mathf.Abs(WallLength.Item1)) && WallLength.Item2 <= transform.position.y)
                    dir = Direction.down;

                else
                    dir = Direction.up;

            }

            if (WallLength.Item1 <= transform.position.y || WallLength.Item2 >= transform.position.y)
            {
                testy = true;
            }
            //else
            //{
            //    Debug.Log("AS");
            //    if (Mathf.Abs(Mathf.Abs(transform.position.x) - Mathf.Abs(WallWidth.Item1)) <= Mathf.Abs(Mathf.Abs(transform.position.x) - Mathf.Abs(WallWidth.Item2)) && WallWidth.Item1 <= transform.position.x && !Temp)
            //    {
            //        dir = Direction.left;
            //        Temp = true;
            //
            //    }
            //    else
            //    {
            //        if (!Temp)
            //        {
            //            dir = Direction.right;
            //            Temp = true;
            //        }
            //    }
            //
            //    if (dir == Direction.left && WallWidth.Item2 + 2 > transform.position.x)
            //        testx = true;
            //
            //    else if (dir == Direction.right && WallWidth.Item1 - 2 < transform.position.x)
            //        testx = true;
            //}
        }

        if (testx && testy)
        {
            MoveBool = !MoveBool;
        }
    }
    void Move()
    {
        switch (dir)
        {
            case Direction.right:
                transform.Translate(new Vector3(1, 0) * Speed * Time.deltaTime);
                hit = Physics2D.Raycast(transform.position + new Vector3(1, 0, 0), Vector2.right, 10f);
                break;
            case Direction.down:
                transform.Translate(new Vector3(0, -1) * Speed * Time.deltaTime);
                hit = Physics2D.Raycast(transform.position + new Vector3(1, 0, 0), Vector2.down, 10f);
                break;
            case Direction.left:
                transform.Translate(new Vector3(-1, 0) * Speed * Time.deltaTime);
                hit = Physics2D.Raycast(transform.position + new Vector3(1, 0, 0), Vector2.left, 10f);
                break;
            case Direction.up:
                transform.Translate(new Vector3(0, 1) * Speed * Time.deltaTime);
                hit = Physics2D.Raycast(transform.position + new Vector3(1, 0, 0), Vector2.up, 10f);
                break;
            case Direction.none:
                Destroy(gameObject);
                break;
        }
    }
}
