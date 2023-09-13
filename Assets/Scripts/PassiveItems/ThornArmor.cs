using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornArmor : PassiveItem
{

    public Multiplier damageReduce;
    public Multiplier damageReflect;
    public float range;


    LinkedFunctionList<float> LFL;
    //TODO : 아이템 내용 수정
    private void Awake()
    {
        SetItemInfo("<b>-[함께 나누는 고통]-\n\n받는 피해가 감소하고 주변 적에게 반사 피해를 줍니다");
        damageReduce = new Multiplier(1f);
        damageReflect = new Multiplier(1f);
        LFL = new LinkedFunctionList<float>(DamageReflect);
    }

    public float DamageReflect(float damage)
    {
        float reflectDamage = damage * damageReflect;




        return damageReduce * damage;
    }

    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                activated = true;
                range = 1.5f;
                damageReduce.multiplier = 0.95f;
                damageReflect.multiplier = 0.5f;
                itemDescription = "받는 피해가 더 감소하고 반사 효과가 강화됩니다.";
                break;
            case 2:
                damageReduce.multiplier = 0.9f;
                damageReflect.multiplier = 0.55f;
                itemDescription = "받는 피해가 더욱 감소하고 반사 효과가 더 강화됩니다.";
                break;
            case 3:
                range = 2f;
                damageReduce.multiplier = 0.85f;
                itemDescription = "받는 피해가 더더욱 감소하고 반사 효과가 더욱 강화됩니다.";
                break;
            case 4:
                damageReduce.multiplier = 0.8f;
                damageReflect.multiplier = 0.6f;
                itemDescription = "";
                break;
        }
    }

    public override void SetItemInfo(string discription, params object[] args)
    {
        itemName = "가시갑옷";
        itemDescription = discription;
    }
}
