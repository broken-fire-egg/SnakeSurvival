using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBelt : PassiveItem
{
    private void Awake()
    {
        SetItemInfo("<b>-[��������]-</b> \n������ �����մϴ�\n�������� �� �� ����� ü���� ȸ���մϴ�");
    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
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
