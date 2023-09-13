using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornArmor : PassiveItem
{

    public Multiplier damageReduce;
    public Multiplier damageReflect;
    public float range;


    LinkedFunctionList<float> LFL;
    //TODO : ������ ���� ����
    private void Awake()
    {
        SetItemInfo("<b>-[�Բ� ������ ����]-\n\n�޴� ���ذ� �����ϰ� �ֺ� ������ �ݻ� ���ظ� �ݴϴ�");
        damageReduce = new Multiplier(1f);
        damageReflect = new Multiplier(1f);
        LFL = new LinkedFunctionList<float>(DamageReflect);
    }

    public float DamageReflect(float damage)
    {
        float reflectDamage = damage * damageReflect;




        return damageReduce * damage;
    }

    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                activated = true;
                range = 1.5f;
                damageReduce.multiplier = 0.95f;
                damageReflect.multiplier = 0.5f;
                itemDescription = "�޴� ���ذ� �� �����ϰ� �ݻ� ȿ���� ��ȭ�˴ϴ�.";
                break;
            case 2:
                damageReduce.multiplier = 0.9f;
                damageReflect.multiplier = 0.55f;
                itemDescription = "�޴� ���ذ� ���� �����ϰ� �ݻ� ȿ���� �� ��ȭ�˴ϴ�.";
                break;
            case 3:
                range = 2f;
                damageReduce.multiplier = 0.85f;
                itemDescription = "�޴� ���ذ� ������ �����ϰ� �ݻ� ȿ���� ���� ��ȭ�˴ϴ�.";
                break;
            case 4:
                damageReduce.multiplier = 0.8f;
                damageReflect.multiplier = 0.6f;
                itemDescription = "";
                break;
        }
    }

    public override void SetItemInfo(string discription, params object[] args)
    {
        itemName = "���ð���";
        itemDescription = discription;
    }
}
