using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinting : PassiveItem
{
    private void Awake()
    {
        SetItemInfo("<b>-[제일 좋아하는 속도]-\n\n이동속도와 공격속도가 상승합니다");
        maxlevel = 5;
    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                activated = true;
                itemDescription = "이동속도와 공격속도가 상승합니다.";
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
