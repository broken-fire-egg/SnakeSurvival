using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDebuff : Debuff
{
    //슬로우0 == 속박



    public SlowDebuff(float time, float amount, GameObject target)
    {
        debuffName = "Slow";

        if (amount == 0)
        {
            debuffName = "bind";
            isUnique = true;
        }
        
        EffectOn(time);
        multiplier = new Multiplier(amount);
        switch(target.tag)
        {
            case "Enemy":
                targetMMV = target.GetComponent<Enemy>().SpeedMultiply;
                break;
            case "Head":
                targetMMV = target.GetComponent<SnakeHead>().speedMultiplier;
                break;
        }




        targetMMV += multiplier;
    }


    public override void EffectOff()
    {
        multiplier.Active = false;
    }



    public override void EffectOn(float time)
    {
        remainTime = time;
    }
}
