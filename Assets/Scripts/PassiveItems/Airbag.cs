using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airbag : PassiveItem
{

    public static Airbag instance;


    float cooltime;
    float waitedtime;
    private void Awake()
    {
        SetItemInfo("<b>-[쿠션감]-</b>\n\n장애물 충돌 피해를 막아주는 보호막을 생성합니다");
        instance = this;
        cooltime = 40f;
        waitedtime = 40f;
    }
    private void Update()
    {
        waitedtime += Time.deltaTime;
    }

    public bool BlockDamage()
    {
        if(activated)
        {
            if(waitedtime > cooltime)
            {
                ItemEffectDisplayer.Instance.EffectDisplay(itemSprite);
                waitedtime = 0f;
                return true;
            }
        }

        return false;
    }
    



    public override void LevelUp()
    {
        level++;
        switch(level)
        {
            case 1:
                cooltime = 40f;
                activated = true;
                itemDescription = "쿨타임이 감소합니다.";
                break;
            case 2:
                cooltime = 35f;
                itemDescription = "쿨타임이 감소합니다.";
                break;
            case 3:
                cooltime = 30f;
                itemDescription = "쿨타임이 감소합니다.";
                break;
            case 4:
                cooltime = 25f;
                itemDescription = "쿨타임이 감소합니다.";
                break;
            case 5:
                cooltime = 20f;
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
