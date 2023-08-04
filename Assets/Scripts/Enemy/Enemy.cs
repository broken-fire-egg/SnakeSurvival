using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Enemy : MonoBehaviour
{

    public enum Direction
    {
        up,
        right,
        down,
        left,
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

    public GameObject Player;
    public GameObject SelfRelatedObj;

    public float stunTime;
    public float maxhp;
    public float hp;
    public float Speed;
    public float SpeedMultiply;
    public float time;
    public float Attack;
    const float SpeedCorrection = 0.05555f; //DO NOT MODIFY THIS VALUE

    public Vector2Int bottomLeft, topRight, startPos, targetPos;
    public bool allowDiagonal, dontCrossCorner;

    public bool MoveBool;

    public Animator Anim;

    public bool DeadBool;

    Direction dir = Direction.none;

    protected virtual void Start()
    {
        MoveBool = true;
        SpeedMultiply = 1;
        Anim = GetComponent<Animator>();
        StartCoroutine(MyCoroutine());
        Player = SnakeHead.instance.gameObject;

        gameObject.transform.position = new Vector2((int)Math.Round(transform.position.x), (int)Math.Round(transform.position.y));
        

    }

    public void Hit(float damage, float stun = 0f, bool isCrit = false)
    {
        hp -= damage;
        time -= stun;
        stunTime += stun;
        if (DamageTextObjectPool.instance)
            DamageTextObjectPool.instance.SpawnText(transform.position, damage, isCrit);
        CheckDead();
    }


    public void CheckDead()
    {
        if (hp <= 0)
        {
            MoveBool = false;
            Anim.SetBool("Die", true);
            Invoke("ObjectDestroy", 0.35f);
        }
    }

    public void ObjectDestroy()
    {
        Destroy(gameObject);
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hp = 0;
            CheckDead();
        }
        if (Player != null)
        {
            if (stunTime > 0)
                stunTime -= Time.deltaTime;
            else
                Move();
        }
        if (stunTime < 0)
            stunTime = 0;
    }

    private IEnumerator MyCoroutine()
    {
        while (true)
        {

            if (Player != null)
                SetDirection();

            yield return new WaitForSeconds(0.1f); // 1ÃÊ ´ë±â
        }
    }

    void SetDirection()
    {

        Vector3 vec3 = Player.transform.position - transform.position;

        if (MathF.Abs(vec3.x) > MathF.Abs(vec3.y))
        {
            if (vec3.x > 0)
            {
                dir = Direction.right;
                //right
            }
            else
            {
                dir = Direction.left;
                //left
            }
        }
        else
        {
            if (vec3.y > 0)
            {
                dir = Direction.up;
                //up
            }
            else
            {
                dir = Direction.down;
                //down
            }
        }
    }

    void Move()
    {

        Vector3 vec3 = Vector3.zero;
        switch (dir)
        {
            case Direction.right:
                vec3 = Vector3.right;
                break;
            case Direction.down:
                vec3 = Vector3.down;
                break;
            case Direction.left:
                vec3 = Vector3.left;
                break;
            case Direction.up:
                vec3 = Vector3.up;
                break;
        }
        transform.Translate(vec3 * Speed * Time.deltaTime * Application.targetFrameRate * SpeedCorrection * SpeedMultiply);
    }
}