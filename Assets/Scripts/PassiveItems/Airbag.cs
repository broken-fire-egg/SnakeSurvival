using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airbag : PassiveItem
{




    float cooltime;
    float waitedtime;
    private void Awake()
    {
        SetItemInfo("<b>-[��ǰ�]-</b>\n\n��ֹ� �浹 ���ظ� �����ִ� ��ȣ���� �����մϴ�");
    
    }

    public override void LevelUp()
    {
        level++;
        switch(level)
        {
            case 1:
                activated = true;
                itemDescription = "��Ÿ���� �����մϴ�.";
                break;
            case 2:
                itemDescription = "��Ÿ���� �����մϴ�.";
                break;
            case 3:
                itemDescription = "��Ÿ���� �����մϴ�.";
                break;
            case 4:
                itemDescription = "��Ÿ���� �����մϴ�.";
                break;
            case 5:

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
