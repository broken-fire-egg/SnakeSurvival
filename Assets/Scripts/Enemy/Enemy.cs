using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
    public MultipleMultiplierValue SpeedMultiply;
    public float time;
    public float Attack;
    public DebuffList debuffList;
    public float contactDamage;

    const float SpeedCorrection = 0.05555f; //DO NOT MODIFY THIS VALUE
    public Vector3 vec3;

    ContactPoint2D lastContact;
    bool isContactWall;
    public Vector2Int bottomLeft, topRight, startPos, targetPos;
    public bool allowDiagonal, dontCrossCorner;
    Rigidbody2D rb;
    public bool MoveBool;
    Collider2D _collider;
    public Animator Anim;

    public bool DeadBool;

    Direction dir = Direction.none;

    protected virtual void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        Anim = GetComponent<Animator>();
        StartCoroutine(MyCoroutine());
        Player = SnakeHead.instance.gameObject;

        Init();
        gameObject.transform.position = new Vector2((int)Math.Round(transform.position.x), (int)Math.Round(transform.position.y));

       // rgbd2d = GetComponent<Rigidbody2D>();
    }

    public void Init()
    {
        debuffList = new DebuffList();
        MoveBool = true;
        DeadBool = false;
        SpeedMultiply = new MultipleMultiplierValue(1);
        _collider.enabled = true;
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
            DeadBool = true;
            _collider.enabled = false;
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

            yield return new WaitForSeconds(0.75f + Random.Range(0, 0.1f)); // 1ÃÊ ´ë±â
        }
    }

    void SetDirection()
    {

        Vector3 vec3 = Player.transform.position - transform.position;

        if(isContactWall)
        {
            this.vec3 = Vector3.Cross(lastContact.normal, Vector3.back);
        }

        //if( MathF.Abs(vec3.x) > MathF.Abs(vec3.y))
        if (Random.Range(0, MathF.Abs(vec3.x)) > Random.Range(0, MathF.Abs(vec3.y)))
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
        if (!MoveBool)
            return;
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
        //if (rgbd2d)
        //rgbd2d.MovePosition(transform.position + ( vec3 * Speed * Time.deltaTime * Application.targetFrameRate * SpeedCorrection * SpeedMultiply));

        rb.MovePosition(transform.position + vec3 * Speed * Time.deltaTime * Application.targetFrameRate * SpeedCorrection * SpeedMultiply);
        //transform.Translate(vec3 * Speed * Time.deltaTime * Application.targetFrameRate * SpeedCorrection * SpeedMultiply);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {


            vec3 = Vector3.Cross( collision.GetContact(0).normal,Vector3.back);
            vec3 = Random.Range(0, 2) == 0 ? vec3 : -vec3;

            lastContact = collision.GetContact(0);
            isContactWall = true;
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 v = Vector3.Cross(collision.GetContact(0).normal, Vector3.back);
            if(v.x > 0.2f)
            {
                dir = Direction.right;
            }
            else if(v.x < -0.2f)
            {
                dir = Direction.left;
            }
            else if(v.y > 0.2f)
            {
                dir = Direction.up;
            }
            else 
            {
                dir = Direction.down;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isContactWall = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isContactWall = false;
        }
    }
}