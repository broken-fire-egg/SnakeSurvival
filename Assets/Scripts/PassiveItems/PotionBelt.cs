using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotionBelt : PassiveItem
{
    int remainPotion;

    public void GetPotion()
    {
        remainPotion++;
        if (remainPotion > level)
            remainPotion = level;
    }

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
                ObserverPatternManager.instance.OnColleagueOrHeroDied += Heal; 
                SetItemInfo("물약을 2개 충전할 수 있게 됩니다");
                break;
            case 2:
                SetItemInfo("물약을 3개 충전할 수 있게 됩니다");
                break;
            case 3:
                SetItemInfo("물약을 4개 충전할 수 있게 됩니다");
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

    public void Heal(bool isbody = false, SnakeBody body = null)
    {
        if (remainPotion <= 0)
            return;
        remainPotion--;

        if (isbody)
        {
            body.Hit(-body.maxHP / 100 * 20f);
        }
        else
        {
            SnakeHead.instance.Hit(-SnakeHead.instance.maxHP / 100 * 20f);
        }
    }

}
