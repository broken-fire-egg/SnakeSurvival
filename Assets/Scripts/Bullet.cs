using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public bool pene;   //°üÅë
    public float stun;

    public Collider2D collider2d;
    public BodyClass from;
    public Rigidbody2D rb2d;
    public virtual void Start()
    {
        collider2d = GetComponent<Collider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Hit(collision.transform.GetComponent<Enemy>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Hit(collision.transform.GetComponent<Enemy>());
        }
    }

    protected virtual void Hit(Enemy target)
    {
        
        if (from)
        {
            if (Random.Range(0, 100) < GameInfo.Instance.criticalChance + from.bonusCriticalChance)
            {
                target.Hit(damage * 2f, stun, true);
            }
            else
            {
                target.Hit(damage, stun);
            }
                from.PlayHitEffect(target.gameObject);
        }
        gameObject.SetActive(pene);
    }


    public void PhysicsSimulate()
    {
        RaycastHit2D[] res = new RaycastHit2D[30];
        collider2d.Cast(Vector2.zero, res);
        foreach (var coll in res)
        {
            if (coll)
                if (coll.transform.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    enemy.Hit(damage);
                    if (!pene)
                    {
                        gameObject.SetActive(false);
                        break;
                    }
                }
        }
    }
}
