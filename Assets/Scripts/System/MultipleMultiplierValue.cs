using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;


public class Multiplier
{
    bool isActive;
    public int priority;
    public float multiplier;
    public float value { get { return isActive ? multiplier : 1f; } }
    public Multiplier(float multiplier, int priority)
    {
        this.priority = priority;
        this.multiplier = multiplier;
    }

    public static implicit operator float(Multiplier m)
    {
        return m.multiplier;
    }
    public Multiplier()
    {
        multiplier = 1.0f;
        priority = 0;
    }
}

public class MultipleMultiplierValue
{
    public float baseValue;
    public List<Multiplier> multipliers;
    float result { get { return this; } }


    public float GetMultipliedValue(float value = 0f)
    {
        if (value == 0f)
            value = baseValue;

        for (int i = 0; i < multipliers.Count; i++)
        {
            value *= multipliers[i].multiplier;
        }

        return value;
    }


    public MultipleMultiplierValue AddMultiplier(Multiplier m)
    {
        multipliers.Add(m);
        multipliers = multipliers.OrderBy((x => x.priority)).ToList();
        return this;
    }

    public MultipleMultiplierValue RemoveMultiplier(Multiplier m)
    {
        multipliers.Remove(m);
        return this;
    }

    public static implicit operator float(MultipleMultiplierValue mmv)
    {
        float res = mmv.baseValue;

        for(int i = 0; i < mmv.multipliers.Count;i++)
        {
            res *= mmv.multipliers[i].multiplier;
        }

        return res;
    }

    public static MultipleMultiplierValue operator + (MultipleMultiplierValue mmv,Multiplier m)
    {
        return mmv.AddMultiplier(m);
    }

    public MultipleMultiplierValue()
    {
        multipliers = new List<Multiplier>();
        baseValue = 1f;
    }
    public MultipleMultiplierValue(float defaultValue)
    {
        multipliers = new List<Multiplier>();
        baseValue = defaultValue;
    }
}
