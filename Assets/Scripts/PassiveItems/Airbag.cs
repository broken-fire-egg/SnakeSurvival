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

    public override void SetItemInfo()
    {
        //TODO : Alternate to Levelup
        itemName = "�����";
        itemDescription = "<b>-[��ǰ�]-</b>\n\n��ֹ� �浹 ���ظ� �����ִ� ��ȣ���� �����մϴ�\n\n<i><��ֹ� �浹 ���ظ� 1�� �����ִ� ��ȣ�� ����></i>";
    }
}
