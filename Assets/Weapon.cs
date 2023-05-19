using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Collider2D col;
    SnakeHead head;
    // Start is called before the first frame update
    void Start()
    {
        head = SnakeHead.instance;
        col = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.TryGetComponent<Enemy>(out Enemy enemy);
            enemy.Hit(GameInfo.Instance.damageUnit);
            
            HitEffectObjectPool.instance.PlayEffect(collision.transform.position + 
                new Vector3(Random.Range(-collision.bounds.extents.x, collision.bounds.extents.x),
                Random.Range(-collision.bounds.extents.y, collision.bounds.extents.y)));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            collision.collider.TryGetComponent<Enemy>(out Enemy enemy);
            enemy.Hit(GameInfo.Instance.damageUnit);
            HitEffectObjectPool.instance.PlayEffect(collision.transform.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1)));

        }
    }
}
