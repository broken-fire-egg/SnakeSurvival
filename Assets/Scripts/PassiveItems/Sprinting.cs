using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinting : PassiveItem
{

    public Multiplier amount;
    public Multiplier attackbuffamount;
    private void Awake()
    {
        SetItemInfo("<b>-[���� �����ϴ� �ӵ�]-\n\n�̵��ӵ��� ���ݼӵ��� ����մϴ�");
        maxlevel = 5;
       
    }
    private void Start()
    {
        amount = new Multiplier();
        attackbuffamount = new Multiplier();
    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                activated = true;
                SetBuff();
                SnakeBodyManager.instance.onNewColleagueDetected += SetBuff;
                amount.multiplier = 1.1f;
                attackbuffamount.multiplier = 0.9f;
                SnakeHead.instance.speedMultiplier += amount;
                SnakeHead.instance.attackDT += attackbuffamount;
                itemDescription = "�̵��ӵ��� ���ݼӵ��� ����մϴ�.";
                break;
            case 2:
                amount.multiplier = 1.15f;
                attackbuffamount.multiplier = 0.85f;
                itemDescription = "�̵��ӵ��� ���ݼӵ��� ���� ����մϴ�.";
                break;
            case 3:
                amount.multiplier = 1.2f;
                attackbuffamount.multiplier = 0.8f;
                itemDescription = "�̵��ӵ��� ���ݼӵ��� ������ ����մϴ�.";
                break;
            case 4:
                amount.multiplier = 1.25f;
                attackbuffamount.multiplier = 0.75f;
                itemDescription = "�̵��ӵ��� ���ݼӵ��� �ſ� ����մϴ�.";
                break;
            case 5:
                amount.multiplier = 1.3f;
                attackbuffamount.multiplier = 0.7f;
                break;

        }




    }

    WaitForSeconds wfs;
    public IEnumerator SetValue()
    {
        wfs = new WaitForSeconds(0.2f);

        while(true)
        {
            SetBuff();


            yield return wfs;
        }
    }


    public void SetBuff()
    {
        var list = PlayerInventory.instance.currentColleagues;
        foreach (var c in list)
        {
            c.shoottime += amount;
        }
    }


    public override void SetItemInfo(string discription, params object[] args)
    {
        itemName = "���ֺ���";
        itemDescription = discription;
    }
}
