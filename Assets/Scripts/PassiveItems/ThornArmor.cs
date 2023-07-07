using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornArmor : PassiveItem
{


    //TODO : 아이템 내용 수정
    private void Awake()
    {
        SetItemInfo("<b>-[제일 좋아하는 속도]-\n\n받는 피해가 감소하고 주변 적에게 반사 피해를 줍니다");
        maxlevel = 4;
    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                activated = true;
                itemDescription = "적과 접촉 시 받는 피해 감소 \n .";
                break;
            case 2:
                itemDescription = "이동속도와 공격속도가 상승합니다.";
                break;
            case 3:
                itemDescription = "이동속도와 공격속도가 상승합니다.";
                break;
            case 4:
                itemDescription = "이동속도와 공격속도가 상승합니다.";
                break;
            case 5:
                break;

        }
    }

    public override void SetItemInfo(string discription, params object[] args)
    {
        itemName = "질주본능";
        itemDescription = discription;
    }
}
