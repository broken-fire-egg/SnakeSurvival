using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;

public abstract class Debuff
{
    public string debuffName;
    public float remainTime;

    public Multiplier multiplier;
    public MultipleMultiplierValue targetMMV;

    public bool isUnique;

    public abstract void EffectOn(float time);
    public abstract void EffectOff();
}

public class DebuffList
{
    public List<Debuff> list;
    
    public void AddDebuff(Debuff newDebuff)
    {
        if (newDebuff.isUnique)
        {
            foreach(Debuff debuff in list)
            {
                if (debuff.debuffName == newDebuff.debuffName)
                    if (newDebuff.remainTime > debuff.remainTime)
                    {
                        debuff.remainTime = newDebuff.remainTime;
                        return;
                    }
            }
        }
        list.Add(newDebuff);
    }


    public void DiscountTime(float amount)
    {
        var copylist = list.ToArray();
        foreach (Debuff debuff in copylist)
        {
            debuff.remainTime -= amount;
            if(debuff.remainTime <= 0)
                list.Remove(debuff);
        }
    }

    public DebuffList()
    {
        list = new List<Debuff>();
    }
}