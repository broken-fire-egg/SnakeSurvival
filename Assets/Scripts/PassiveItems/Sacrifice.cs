using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacrifice : PassiveItem
{
    float reduce = 0f;

    LinkedFunctionList<float> LFL;

    private void Start()
    {
        SetItemInfo("<b>-[�����ϱ� �����]-\n\n���ᰡ ġ������ ���ظ� ���� �� ĳ���Ͱ� ��� �޽��ϴ�");
        LFL = new LinkedFunctionList<float>(SacrificeHit);
    }

    public float SacrificeHit(float amount)
    {
        if (amount <= 0f)
            return amount;

        if(SnakeHead.instance.HP < amount - amount * reduce)
        {
            return amount;
        }
        else
        {
            SnakeHead.instance.Hit(amount - amount * reduce);
            return 0;
        }



    }
    public override void LevelUp()
    {
        level++;
        switch(level)
        {
            case 1:
                reduce = 0.2f;
                SetItemInfo("��� �޴� ���ط��� �����մϴ�");
               activated = true;
                break;
            case 2:
                reduce = 0.25f;
                SetItemInfo("��� �޴� ���ط��� �� �����մϴ�");
                break;
            case 3:
                reduce = 0.3f;
                SetItemInfo("��� �޴� ���ط��� ���� �����մϴ�");
                break;
            case 4:
                reduce = 0.35f;
                SetItemInfo("��� �޴� ���ط��� ������ �����մϴ�");
                break;
            case 5:
                reduce = 0.4f;
                break;
        }
    }

    public override void SetItemInfo(string discription, params object[] args)
    {
        throw new System.NotImplementedException();
    }
}
