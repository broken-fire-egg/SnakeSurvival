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
        SetItemInfo("<b>-[��ǰ�]-</b>\n\n��ֹ� �浹 ���ظ� �����ִ� ��ȣ���� �����մϴ�");
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
                itemDescription = "��Ÿ���� �����մϴ�.";
                break;
            case 2:
                cooltime = 35f;
                itemDescription = "��Ÿ���� �����մϴ�.";
                break;
            case 3:
                cooltime = 30f;
                itemDescription = "��Ÿ���� �����մϴ�.";
                break;
            case 4:
                cooltime = 25f;
                itemDescription = "��Ÿ���� �����մϴ�.";
                break;
            case 5:
                cooltime = 20f;
                break;
        }
    }

    public override void SetItemInfo(string discription, params object[] args)
    {
        //TODO : Alternate to Levelup
        itemName = "�����";
        itemDescription = discription;
    }
}
