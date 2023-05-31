using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public bool pene;   //����
    public Collider2D collider2d;
    public Rigidbody2D rb2d;
    private void Start()
    {
        collider2d = GetComponent<Collider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Enemy>().Hit(damage);
            gameObject.SetActive(pene);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Enemy>().Hit(damage);
            gameObject.SetActive(pene);
        }
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
