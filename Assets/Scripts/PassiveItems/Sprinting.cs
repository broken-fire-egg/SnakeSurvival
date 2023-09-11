using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinting : PassiveItem
{

    public Multiplier amount;
    public Multiplier attackbuffamount;
    private void Awake()
    {
        SetItemInfo("<b>-[제일 좋아하는 속도]-\n\n이동속도와 공격속도가 상승합니다");
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
                itemDescription = "이동속도와 공격속도가 상승합니다.";
                break;
            case 2:
                amount.multiplier = 1.15f;
                attackbuffamount.multiplier = 0.85f;
                itemDescription = "이동속도와 공격속도가 더욱 상승합니다.";
                break;
            case 3:
                amount.multiplier = 1.2f;
                attackbuffamount.multiplier = 0.8f;
                itemDescription = "이동속도와 공격속도가 더더욱 상승합니다.";
                break;
            case 4:
                amount.multiplier = 1.25f;
                attackbuffamount.multiplier = 0.75f;
                itemDescription = "이동속도와 공격속도가 매우 상승합니다.";
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
        itemName = "질주본능";
        itemDescription = discription;
    }
}
