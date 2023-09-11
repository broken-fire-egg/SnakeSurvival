using Mono.Cecil.Cil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : BodyClass
{
    public BodyClass frontColleague;
    public BodyClass backColleague;
    public bool shield;
    public bool shieldUpgraded;
    public bool headTarget;
    protected override void Start()
    {
        base.Start();
        SetBodyInfo("");
    }
    void Update()
    {
        if (!snakeBody.activated)
            return;
        cooltime -= Time.deltaTime * cooltimeMultiplier;

        if (cooltime < 0)
            Heal();
    }

    public void SetTarget()
    {
        var colleagues = PlayerInventory.instance.currentColleagues;


        if (!frontColleague)
            if (colleagues.IndexOf(this) > 0)
            {
                Debug.Log(colleagues[colleagues.IndexOf(this) - 1]);
                frontColleague = colleagues[colleagues.IndexOf(this) - 1];
            }
            else
                frontColleague = null;

        if (!frontColleague)
            if (colleagues.IndexOf(this) == 0)
                headTarget = true;

        if (!backColleague)
            if (colleagues.IndexOf(this) < colleagues.Count - 1)
                backColleague = colleagues[colleagues.IndexOf(this) + 1] ?? null;
            else
                backColleague = null;
    }
    public void Heal()
    {
        cooltime = shoottime;


        if (headTarget)
        {
            SnakeHead.instance.Hit(-damage);
        }
        else if(frontColleague)
        {
            frontColleague.Hit(-damage);
        }
        if(backColleague)
        {
            backColleague.Hit(-damage);
        }
    }


    public override void Activate()
    {
        PlayerInventory.instance.AddColleague(this);
        snakeBody.Activate();
        SetTarget();
    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                shoottime.baseValue = 10;
                bonusDamage = 5;
                Activate();
                SnakeBodyManager.instance.onNewColleagueDetected += SetTarget;
                SetBodyInfo("회복 위력이 증가합니다.", "1.5타일", "", "");
                break;
            case 2:

                bonusDamage = 10;
                SetBodyInfo("공격 속도가 증가합니다.", "", Math.Round(2 + GameInfo.Instance.damageUnit / 10, 2), "");
                break;
            case 3:
                shoottime.baseValue = 8;
                SetBodyInfo("자신의 공격력이 증가합니다.", "", "", "6/s");
                break;
            case 4:

                bonusDamage = 15;
                SetBodyInfo("20초마다 아군에게 피해를 막아주는 보호막을 생성합니다.", "2타일", Math.Round(2 + GameInfo.Instance.damageUnit / 100 * 15, 2), "");
                break;
            case 5:
                shield = true;
                SetBodyInfo("회복 위력과 공격 속도가 증가합니다.", "2.5 타일", "", "7/s");
                break;
            case 6:
                bonusDamage = 20;
                shoottime.baseValue = 6.25f;
                SetBodyInfo("보호막이 있는 동안 추가효과를 제공하고 자신에게도 보호막을 생성합니다.", "4 타일", "", "");
                break;
            case 7:
                shieldUpgraded = true;
                break;
        }
        UpdateDamageInfo();
    }

    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "페럿 수녀";
        bodyDescription = " <b>-[부드러운 기도]-\n\n주위 아군들에게 기도를 하여 체력을 회복시켜줍니다.</b>";
        if (discription != "")
            levelupDescription = discription;
        else
            levelupDescription = bodyDescription;
    }

    public override void UpdateDamageInfo()
    {

    }
}
