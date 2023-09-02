using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornArmor : PassiveItem
{

    public float damageReduce;
    public float damageReflect;

    //TODO : 아이템 내용 수정
    private void Awake()
    {
        SetItemInfo("<b>-[함께 나누는 고통]-\n\n받는 피해가 감소하고 주변 적에게 반사 피해를 줍니다");

    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                activated = true;
                itemDescription = "받는 피해가 더 감소하고 반사 효과가 강화됩니다.";
                break;
            case 2:
                itemDescription = "받는 피해가 더욱 감소하고 반사 효과가 더 강화됩니다.";
                break;
            case 3:
                itemDescription = "받는 피해가 더더욱 감소하고 반사 효과가 더욱 강화됩니다.";
                break;
            case 4:
                itemDescription = "";
                break;

        }
    }

    public override void SetItemInfo(string discription, params object[] args)
    {
        itemName = "질주본능";
        itemDescription = discription;
    }
}
