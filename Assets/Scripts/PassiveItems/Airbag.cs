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
        SetItemInfo("<b>-[��ǰ�]-</b>\n\n��ֹ� �浹 ���ظ� �����ִ� ��ȣ���� �����մϴ�");
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
        itemName = "�����";
        itemDescription = discription;
    }
}
