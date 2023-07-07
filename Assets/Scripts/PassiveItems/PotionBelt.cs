using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBelt : PassiveItem
{
    private void Awake()
    {
        SetItemInfo("<b>-[벌컥벌컥]-\n\n물약을 저장합니다\n쓰러지려 할 때 사용해 체력을 회복합니다");
        maxlevel = 4;
    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                activated = true;
                itemDescription = "최대 2개까지 물약을 충전합니다.";
                break;
            case 2:
                itemDescription = "최대 3개까지 물약을 충전합니다.";
                break;
            case 3:
                itemDescription = "최대 4개까지 물약을 충전합니다.";
                break;
            case 4:

                break;
        }
    }

    public override void SetItemInfo(string discription, params object[] args)
    {       
        itemName = "물약 주머니";
        itemDescription = discription;
    }
}
