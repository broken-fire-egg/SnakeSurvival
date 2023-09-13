using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacrifice : PassiveItem
{
    float reduce = 0f;

    LinkedFunctionList<float> LFL;

    private void Start()
    {
        SetItemInfo("<b>-[아프니까 동료다]-\n\n동료가 치명적인 피해를 받을 시 캐릭터가 대신 받습니다");
        LFL = new LinkedFunctionList<float>(SacrificeHit);
    }

    public float SacrificeHit(float amount)
    {
        if (amount <= 0f)
            return amount;

        if(SnakeHead.instance.HP < amount - amount * reduce)
        {
            return amount;
        }
        else
        {
            SnakeHead.instance.Hit(amount - amount * reduce);
            return 0;
        }



    }
    public override void LevelUp()
    {
        level++;
        switch(level)
        {
            case 1:
                reduce = 0.2f;
                SetItemInfo("대신 받는 피해량이 감소합니다");
               activated = true;
                break;
            case 2:
                reduce = 0.25f;
                SetItemInfo("대신 받는 피해량이 더 감소합니다");
                break;
            case 3:
                reduce = 0.3f;
                SetItemInfo("대신 받는 피해량이 더욱 감소합니다");
                break;
            case 4:
                reduce = 0.35f;
                SetItemInfo("대신 받는 피해량이 더더욱 감소합니다");
                break;
            case 5:
                reduce = 0.4f;
                break;
        }
    }

    public override void SetItemInfo(string discription, params object[] args)
    {
        throw new System.NotImplementedException();
    }
}
