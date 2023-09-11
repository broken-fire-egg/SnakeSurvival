using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sr;
    public Animator animator;
    public bool activated;
    public SnakeHead.PosHistory destination;
    public SnakeHead.Direction dir = SnakeHead.Direction.up;
    public float maxHP;
    public float HP;
    public bool faint;

    public virtual void SetBodyInfo()
    {

    }
    private void Start()
    {
        dir = SnakeHead.Direction.up;
        HP = maxHP;
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void Hit(float amount)
    {
        HP -= amount;
        HPCheck();
    }
    void HPCheck()
    {
        if (HP > maxHP)
            HP = maxHP;
        if (HP <= 0)
        {
            ObserverPatternManager.instance.ColleagueOrHeroDied(true, this);


            if (HP <= 0)
                Activate(false);
        }
    }


    public void CheckOverMoved()
    {
        bool res = false;
        float gap = 0;
        if (destination == null)
            res = false;
        else
        {
            switch (dir)
            {
                case SnakeHead.Direction.right:
                    if (transform.position.x > destination.pos.x)
                    {
                        transform.position = destination.pos;
                        gap = transform.position.x - destination.pos.x;
                        res = true;
                    }
                    break;
                case SnakeHead.Direction.down:
                    if (transform.position.y < destination.pos.y)
                    {
                        transform.position = destination.pos;

                        gap = destination.pos.y - transform.position.y;
                        res = true;
                    }
                    break;
                case SnakeHead.Direction.left:
                    if (transform.position.x < destination.pos.x)
                    {
                        transform.position = destination.pos;

                        gap = destination.pos.x - transform.position.x;
                        res = true;
                    }
                    break;
                case SnakeHead.Direction.up:
                    if (transform.position.y > destination.pos.y)
                    {
                        transform.position = destination.pos;
                        gap = transform.position.y - destination.pos.y;
                        res = true;
                    }
                    break;
            }
        }

        if (res)
        {
            SetDestination(gap);
        }


    }
    public void Move(int index)
    {
        if (destination == null)
        {
            switch (dir)
            {
                case SnakeHead.Direction.right:
                    transform.position = SnakeHead.instance.transform.position - new Vector3(1, 0, 0) * (index + 1) * 1.5f;
                    break;
                case SnakeHead.Direction.down:
                    transform.position = SnakeHead.instance.transform.position - new Vector3(0, -1, 0) * (index + 1) * 1.5f;
                    break;
                case SnakeHead.Direction.left:
                    transform.position = SnakeHead.instance.transform.position - new Vector3(-1, 0, 0) * (index + 1) * 1.5f;
                    break;
                case SnakeHead.Direction.up:
                    transform.position = SnakeHead.instance.transform.position - new Vector3(0, 1, 0) * (index + 1) * 1.5f;
                    break;
            }
        }
        else
        {
            switch (dir)
            {
                case SnakeHead.Direction.right:
                    sr.flipX = true;
                    transform.Translate(new Vector3(1, 0) * SnakeHead.instance.Speed);
                    break;
                case SnakeHead.Direction.down:
                    transform.Translate(new Vector3(0, -1) * SnakeHead.instance.Speed);
                    break;
                case SnakeHead.Direction.left:
                    sr.flipX = false;
                    transform.Translate(new Vector3(-1, 0) * SnakeHead.instance.Speed);
                    break;
                case SnakeHead.Direction.up:
                    transform.Translate(new Vector3(0, 1) * SnakeHead.instance.Speed);
                    break;
            }
        }
    }
    void Move(float amount)
    {
        switch (dir)
        {
            case SnakeHead.Direction.right:
                sr.flipX = true;
                transform.position = transform.position + new Vector3(amount, 0, 0);
                //transform.Translate(new Vector3(1, 0) * SnakeHead.instance.Speed);
                break;
            case SnakeHead.Direction.down:
                transform.position = transform.position + new Vector3(0, -amount, 0);
                //transform.Translate(new Vector3(0, -1) * SnakeHead.instance.Speed);
                break;
            case SnakeHead.Direction.left:
                transform.position = transform.position + new Vector3(-amount, 0, 0);
                sr.flipX = false;
                //transform.Translate(new Vector3(-1, 0) * SnakeHead.instance.Speed);
                break;
            case SnakeHead.Direction.up:
                transform.position = transform.position + new Vector3(0, amount, 0);
                //transform.Translate(new Vector3(0, 1) * SnakeHead.instance.Speed);
                break;
        }
    }
    public void CopyValue(SnakeBody from)
    {
        dir = from.dir;
        gameObject.transform.position = from.gameObject.transform.position;
        sr.flipY = from.sr.flipY;
        destination = from.destination;
    }

    public void SetDestination(float amount)
    {
        if (destination.nextPH != null)
        {
            dir = destination.dir;
            destination = destination.nextPH;
            Move(amount);
            return;
        }
        dir = destination.dir;
        destination = null;
        Move(amount);
    }
    public void Activate(bool activate = true)
    {
        if (activate)
            SnakeBodyManager.instance.AddBody(this);
        sr.enabled = activate;
        activated = activate;
    }

    public void Revive(float hp)
    {
        HP = hp;
        sr.enabled = true;
        activated = true;
    }
}
