using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornArmor : PassiveItem
{


    //TODO : ������ ���� ����
    private void Awake()
    {
        SetItemInfo("<b>-[���� �����ϴ� �ӵ�]-\n\n�޴� ���ذ� �����ϰ� �ֺ� ������ �ݻ� ���ظ� �ݴϴ�");
        maxlevel = 4;
    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                activated = true;
                itemDescription = "���� ���� �� �޴� ���� ���� \n .";
                break;
            case 2:
                itemDescription = "�̵��ӵ��� ���ݼӵ��� ����մϴ�.";
                break;
            case 3:
                itemDescription = "�̵��ӵ��� ���ݼӵ��� ����մϴ�.";
                break;
            case 4:
                itemDescription = "�̵��ӵ��� ���ݼӵ��� ����մϴ�.";
                break;
            case 5:
                break;

        }
    }

    public override void SetItemInfo(string discription, params object[] args)
    {
        itemName = "���ֺ���";
        itemDescription = discription;
    }
}
