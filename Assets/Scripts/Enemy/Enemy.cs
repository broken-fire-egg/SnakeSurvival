using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxhp;
    public float hp;
    public GameObject Player;

    public enum Direction { right, down, left, up }
    public enum Type { normal, archer, ghost, explosion, horseman, wizard, corrosion, healer}

    public Type EnemyType;

    public Direction dir;
    public bool test = false;
    public float Speed;
    GameObject testing;
    float time;
    void Start()
    {
        testing = GameObject.Find("Square");
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

    private void Update()
    {
        time += Time.deltaTime;
        if (test)
            CheckLength();
        else
            CheckWidth();
        switch (EnemyType)
        {
            case Type.normal:
                break;
            case Type.archer:
                Self_Destruct();
                break;
            case Type.ghost:
                if (time >= 1f)
                    EnemyStealth();
                break;
            case Type.explosion:
                break;
            case Type.horseman:
                break;
            case Type.wizard:
                break;
            case Type.corrosion:
                if (time >= 1f)
                    Corrosion();
                    break;
            case Type.healer:
                break;
            default:
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
            Destroy(collision.gameObject);
    }

    void CheckWidth()
    {
        if (Mathf.Round(Player.transform.position.x) > Mathf.Round(transform.position.x))
        //dir = Direction.right;
            transform.Translate(new Vector3(1, 0) * Speed);

        else if (Mathf.Round(Player.transform.position.x) == Mathf.Round(transform.position.x))
            test = true;
        else
            //dir = Direction.left;
            transform.Translate(new Vector3(-1, 0) * Speed);
    }
    void CheckLength()
    {
        if (Mathf.Round(Player.transform.position.y) > Mathf.Round(transform.position.y))
        //dir = Direction.up
            transform.Translate(new Vector3(0, 1) * Speed);

        else if (Mathf.Round(Player.transform.position.y) < Mathf.Round(transform.position.y))
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

    void EnemyStealth()
    {
        time = 0;
        if (gameObject.GetComponent<SpriteRenderer>().enabled)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    void Self_Destruct()
    {
        if (Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(Player.transform.position.x, Player.transform.position.y)) <= 2)
            Destroy(gameObject);
    }

    void Corrosion()
    {
        time = 0;
        Instantiate(testing, gameObject.transform.position, Quaternion.identity);
    }

}
