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
        
    }

    public override void LevelUp()
    {
        level++;
        switch(level)
        {
            case 1:
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

    public override void SetItemInfo()
    {
        itemName = "에어백";
        itemDescription = "<b>-[쿠션감]-</b>\n\n장애물 충돌 피해를 막아주는 보호막을 생성합니다\n\n<i><장애물 충돌 피해를 1번 막아주는 보호막 생성></i>";
    }
}
