using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clam : Bullet
{
    public float knockback;
    protected override void Hit(Enemy target)
    {
        base.Hit(target);
        Vector3 vec = target.transform.position - from.transform.position;
        vec.Normalize();
        target.transform.Translate(vec * knockback);
    }
}
