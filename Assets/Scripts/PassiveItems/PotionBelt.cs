using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotionBelt : PassiveItem
{
    int remainPotion;

    public void GetPotion()
    {
        remainPotion++;
        if (remainPotion > level)
            remainPotion = level;
    }

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
                ObserverPatternManager.instance.OnColleagueOrHeroDied += Heal; 
                SetItemInfo("������ 2�� ������ �� �ְ� �˴ϴ�");
                break;
            case 2:
                SetItemInfo("������ 3�� ������ �� �ְ� �˴ϴ�");
                break;
            case 3:
                SetItemInfo("������ 4�� ������ �� �ְ� �˴ϴ�");
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

    public void Heal(bool isbody = false, SnakeBody body = null)
    {
        if (remainPotion <= 0)
            return;
        remainPotion--;

        if (isbody)
        {
            body.Hit(-body.maxHP / 100 * 20f);
        }
        else
        {
            SnakeHead.instance.Hit(-SnakeHead.instance.maxHP / 100 * 20f);
        }
    }

}
