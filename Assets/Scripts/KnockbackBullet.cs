using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KnockbackBullet;
using static UnityEngine.GraphicsBuffer;

public class KnockbackBullet : Bullet
{
    public float knockback;
    public float power;
    [Serializable]
    public class Target
    {
        public Transform transform;
        public int remainKnockbackTime;

        public Target(Transform transform, int remainKnockbackTime)
        {
            this.transform = transform;
            this.remainKnockbackTime = remainKnockbackTime;
        }
    }


    public List<Target> targets;

    private void OnEnable()
    {
        targets = new List<Target>();
        StartCoroutine(KnockBack());
    }
    bool ContainAlready(Transform t)
    {
       foreach(var target in targets)
        {
            if (target.transform == t)
                return true;
        }
       return false;
    }
    Target Findtarget(Transform t)
    {
        foreach (var target in targets)
        {
            if (target.transform == t)
                return target;
        }
        return null;
    }
    protected override void Hit(Enemy target)
    {

        
        if (target)
            if (!ContainAlready(target.transform))
            {
                base.Hit(target);
                targets.Add(new Target(target.transform, 5));
            }

    }
    IEnumerator KnockBack()
    {
        Vector3 vec3;
        while (true)
        {
            foreach (var t in targets.ToArray())
            {
                if(t.transform)
                {
                    vec3 = t.transform.position - transform.position;


                    t.transform.Translate(vec3.normalized * power);
                    targets[targets.IndexOf(t)].remainKnockbackTime -= 1;
                    if(targets[targets.IndexOf(t)].remainKnockbackTime <= 0)
                        targets.Remove(t);
                }
            }
            yield return null;
        }
    }
}
