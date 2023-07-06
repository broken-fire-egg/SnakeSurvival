using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airbag : PassiveItem
{
    public bool activated;

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
                break;
            case 2:
                break;

            case 3:
                break;

            case 4:
                break;

            case 5:
                break;

            case 6:
                break;

            case 7:
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
