using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornArmor : PassiveItem
{

    public float damageReduce;
    public float damageReflect;

    //TODO : ������ ���� ����
    private void Awake()
    {
        SetItemInfo("<b>-[�Բ� ������ ����]-\n\n�޴� ���ذ� �����ϰ� �ֺ� ������ �ݻ� ���ظ� �ݴϴ�");

    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                activated = true;
                itemDescription = "�޴� ���ذ� �� �����ϰ� �ݻ� ȿ���� ��ȭ�˴ϴ�.";
                break;
            case 2:
                itemDescription = "�޴� ���ذ� ���� �����ϰ� �ݻ� ȿ���� �� ��ȭ�˴ϴ�.";
                break;
            case 3:
                itemDescription = "�޴� ���ذ� ������ �����ϰ� �ݻ� ȿ���� ���� ��ȭ�˴ϴ�.";
                break;
            case 4:
                itemDescription = "";
                break;

        }
    }

    public override void SetItemInfo(string discription, params object[] args)
    {
        itemName = "���ֺ���";
        itemDescription = discription;
    }
}
