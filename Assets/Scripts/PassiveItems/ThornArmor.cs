using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornArmor : PassiveItem
{


    //TODO : ������ ���� ����
    private void Awake()
    {
        SetItemInfo("<b>-[�Բ� ������ ����]-\n\n�޴� ���ذ� �����ϰ� �ֺ� ������ �ݻ� ���ظ� �ݴϴ�");
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
                itemDescription = "�޴� ���ذ� �� �����ϰ� �ݻ� ȿ���� ��ȭ�˴ϴ�.";
                break;
            case 3:
                itemDescription = "�޴� ���ذ� ���� �����ϰ� �ݻ� ȿ���� �� ��ȭ�˴ϴ�.";
                break;
            case 4:
                itemDescription = "�޴� ���ذ� ������ �����ϰ� �ݻ� ȿ���� ���� ��ȭ�˴ϴ�.";
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
