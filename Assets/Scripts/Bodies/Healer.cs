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
                SetBodyInfo("ȸ�� ������ �����մϴ�.", "1.5Ÿ��", "", "");
                break;
            case 2:

                bonusDamage = 10;
                SetBodyInfo("���� �ӵ��� �����մϴ�.", "", Math.Round(2 + GameInfo.Instance.damageUnit / 10, 2), "");
                break;
            case 3:
                shoottime.baseValue = 8;
                SetBodyInfo("�ڽ��� ���ݷ��� �����մϴ�.", "", "", "6/s");
                break;
            case 4:

                bonusDamage = 15;
                SetBodyInfo("20�ʸ��� �Ʊ����� ���ظ� �����ִ� ��ȣ���� �����մϴ�.", "2Ÿ��", Math.Round(2 + GameInfo.Instance.damageUnit / 100 * 15, 2), "");
                break;
            case 5:
                shield = true;
                SetBodyInfo("ȸ�� ���°� ���� �ӵ��� �����մϴ�.", "2.5 Ÿ��", "", "7/s");
                break;
            case 6:
                bonusDamage = 20;
                shoottime.baseValue = 6.25f;
                SetBodyInfo("��ȣ���� �ִ� ���� �߰�ȿ���� �����ϰ� �ڽſ��Ե� ��ȣ���� �����մϴ�.", "4 Ÿ��", "", "");
                break;
            case 7:
                shieldUpgraded = true;
                break;
        }
        UpdateDamageInfo();
    }

    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "�䷵ ����";
        bodyDescription = " <b>-[�ε巯�� �⵵]-\n\n���� �Ʊ��鿡�� �⵵�� �Ͽ� ü���� ȸ�������ݴϴ�.</b>";
        if (discription != "")
            levelupDescription = discription;
        else
            levelupDescription = bodyDescription;
    }

    public override void UpdateDamageInfo()
    {

    }
}
