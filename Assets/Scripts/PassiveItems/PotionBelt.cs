using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBelt : PassiveItem
{
    private void Awake()
    {
        SetItemInfo("<b>-[��������]-\n\n������ �����մϴ�\n�������� �� �� ����� ü���� ȸ���մϴ�");
        maxlevel = 4;
    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                activated = true;
                itemDescription = "�ִ� 2������ ������ �����մϴ�.";
                break;
            case 2:
                itemDescription = "�ִ� 3������ ������ �����մϴ�.";
                break;
            case 3:
                itemDescription = "�ִ� 4������ ������ �����մϴ�.";
                break;
            case 4:

                break;
        }
    }

    public override void SetItemInfo(string discription, params object[] args)
    {       
        itemName = "���� �ָӴ�";
        itemDescription = discription;
    }
}
