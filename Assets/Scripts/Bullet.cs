using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public bool pene;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Enemy>().hp -= damage;
            if(!pene)
                gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            var enemy = collision.transform.GetComponent<Enemy>();
            enemy.hp -= damage;
            enemy.CheckDead();
            if (!pene)
                gameObject.SetActive(false);
        }
    }
}
