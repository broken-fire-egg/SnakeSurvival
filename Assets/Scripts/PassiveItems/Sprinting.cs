using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinting : PassiveItem
{
    private void Awake()
    {
        SetItemInfo("<b>-[���� �����ϴ� �ӵ�]-\n\n�̵��ӵ��� ���ݼӵ��� ����մϴ�");
        maxlevel = 5;
    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                activated = true;
                itemDescription = "�̵��ӵ��� ���ݼӵ��� ����մϴ�.";
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
