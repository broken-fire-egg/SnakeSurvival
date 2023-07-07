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
        if(HP > maxHP)
            HP = maxHP;
        if (HP <= 0)
            Activate(false);
    }


    public bool CheckOverMoved()
    {
        if (destination == null) return false;
        switch (dir)
        {
            case SnakeHead.Direction.right:
                if(transform.position.x > destination.pos.x)
                {
                    transform.position = destination.pos;
                    return true;
                }
                break;
            case SnakeHead.Direction.down:
                if (transform.position.y < destination.pos.y)
                {
                    transform.position = destination.pos;
                    return true;
                }
                break;
            case SnakeHead.Direction.left:
                if (transform.position.x < destination.pos.x)
                {
                    transform.position = destination.pos;
                    return true;
                }
                break;
            case SnakeHead.Direction.up:
                if (transform.position.y > destination.pos.y)
                {
                    transform.position = destination.pos;
                    return true;
                }
                break;
        }
        return false;
    }
    public void Move()
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
    public void SetDestination()
    {
        if (destination.nextPH != null)
        {
            dir = destination.dir;
            destination = destination.nextPH;
            return;
        }
        dir = destination.dir;
        destination = null;
    }
    public void Activate(bool activate = true)
    {
        sr.enabled = activate;
        activated = activate;
    }
}
