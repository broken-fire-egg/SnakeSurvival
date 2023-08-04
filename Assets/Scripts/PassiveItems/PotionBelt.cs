using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBelt : PassiveItem
{
    private void Awake()
    {
        SetItemInfo("<b>-[벌컥벌컥]-</b> \n물약을 저장합니다\n쓰러지려 할 때 사용해 체력을 회복합니다");
    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
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
