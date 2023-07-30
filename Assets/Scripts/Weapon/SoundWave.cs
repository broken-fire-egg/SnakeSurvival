using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWave : Bullet
{

    protected override void Hit(Enemy target)
    {
        if (from)
        {
            if (Random.Range(0, 100) < GameInfo.Instance.criticalChance + from.bonusCriticalChance)
            {
                if(from.level == 7)
                    target.Hit(damage * 2f, 2f, true);
                else
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
}
