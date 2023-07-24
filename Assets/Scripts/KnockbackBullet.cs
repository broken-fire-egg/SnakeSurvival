using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackBullet : Bullet
{
    public float knockback;


    protected override void Hit(Enemy target)
    {
        base.Hit(target);

        Vector3 vec3 = target.transform.position - transform.position;

        if (target)
        {
            target.transform.Translate(vec3.normalized * knockback, Space.Self);
        }
    }

}
