using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airbag : PassiveItem
{




    float cooltime;
    float waitedtime;
    private void Awake()
    {
        SetItemInfo("<b>-[쿠션감]-</b>\n\n장애물 충돌 피해를 막아주는 보호막을 생성합니다");
    
    }

    public override void LevelUp()
    {
        level++;
        switch(level)
        {
            case 1:
                activated = true;
                itemDescription = "쿨타임이 감소합니다.";
                break;
            case 2:
                itemDescription = "쿨타임이 감소합니다.";
                break;
            case 3:
                itemDescription = "쿨타임이 감소합니다.";
                break;
            case 4:
                itemDescription = "쿨타임이 감소합니다.";
                break;
            case 5:

                break;
        }
    }

    public override void SetItemInfo(string discription, params object[] args)
    {
        //TODO : Alternate to Levelup
        itemName = "에어백";
        itemDescription = discription;
    }
}
