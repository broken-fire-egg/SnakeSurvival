using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Bullet
{


    public float cooltime;
    public float attackedtime;
    public Collider2D coll2D;

    

    

    private void Update()
    {
        attackedtime -= Time.deltaTime;
        RaycastHit2D[] hits = null;

        coll2D.Cast(Vector2.zero, hits);
    }

    public override void Start()
    {
        base.Start();
        coll2D = GetComponent<Collider2D>();

        from = GameObject.Find("Sawer").GetComponent<Sawer>();
    }

    protected override void Hit(Enemy target)
    {
        attackedtime = cooltime;
        target.Hit(damage);
        if (from)
            ((Sawer)from).PlayHitEffect(target.gameObject,gameObject);
        gameObject.SetActive(pene);
    }
}
