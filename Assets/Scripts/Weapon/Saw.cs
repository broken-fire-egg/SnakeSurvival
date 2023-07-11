using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Bullet
{
    public override void Start()
    {
        base.Start();
        from = GameObject.Find("Sawer").GetComponent<Sawer>();
    }

    protected override void Hit(Enemy target)
    {
        target.Hit(damage);
        if (from)
            ((Sawer)from).PlayHitEffect(target.gameObject,gameObject);
        gameObject.SetActive(pene);
    }
}
