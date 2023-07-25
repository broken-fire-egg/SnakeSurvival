using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleMine : MonoBehaviour
{
    public Bullet bullet;
    public SpriteRenderer sr;
    public CircleCollider2D detectCollider;
    public CircleCollider2D explosionCollider;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void UpdateInfo(float damage, float range, float detectrange, BodyClass bodyClass = null)
    {
        if (bodyClass)
            bullet.from = bodyClass;

        detectCollider.radius = detectrange;
        bullet.damage = damage;
        explosionCollider.radius = range;
        transform.GetChild(0).localScale = new Vector3(range, range, 1);
    }
    public void SetSpriteRendererActive(bool b)
    {
            sr.enabled = (b);
    }
}
