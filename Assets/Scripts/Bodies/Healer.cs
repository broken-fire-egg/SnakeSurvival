using Mono.Cecil.Cil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : BodyClass
{
    protected override void Start()
    {
        base.Start();
        SetBodyInfo("");
    }
    void Update()
    {
        if (!snakeBody.activated)
            return;
        cooltime -= Time.deltaTime;

        if (cooltime < 0)
            PlayAnimation();
    }


    public void PlayAnimation()
    {

    }
    public void Heal()
    {
        BodyClass frontColleague;
        BodyClass backColleague;
        var colleagues = PlayerInventory.instance.currentColleagues;

        if(colleagues.IndexOf(this) > 0)
            frontColleague = colleagues[colleagues.IndexOf(this) - 1];
        else
            frontColleague = null;
        if (colleagues.IndexOf(this) < colleagues.Count-1)
            backColleague = colleagues[colleagues.IndexOf(this) + 1] ?? null;
        else
            backColleague = null;

        if(frontColleague)
            frontColleague.Hit(damage);
        
        if(backColleague)
            backColleague.Hit(damage);
        

    }


    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                snakeBody.Activate();
                SetBodyInfo("ȸ�� ������ �����մϴ�.", "1.5Ÿ��", "", "");
                break;
            case 2:
                SetBodyInfo("���� �ӵ��� �����մϴ�.", "", Math.Round(2 + GameInfo.Instance.damageUnit / 10, 2), "");
                break;
            case 3:
                SetBodyInfo("�ڽ��� ���ݷ��� �����մϴ�.", "", "", "6/s");
                break;
            case 4:
                SetBodyInfo("20�ʸ��� �Ʊ����� ���ظ� �����ִ� ��ȣ���� �����մϴ�.", "2Ÿ��", Math.Round(2 + GameInfo.Instance.damageUnit / 100 * 15, 2), "");
                break;
            case 5:
                SetBodyInfo("ȸ�� ���°� ���� �ӵ��� �����մϴ�.", "2.5 Ÿ��", "", "7/s");
                break;
            case 6:
                SetBodyInfo("��ȣ���� �ִ� ���� �߰�ȿ���� �����ϰ� �ڽſ��Ե� ��ȣ���� �����մϴ�.", "4 Ÿ��", "", "");
                break;
        }
    }

    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "�䷵ ����";
        bodyDescription = " <b>-[�ε巯�� �⵵]-\n\n���� �Ʊ��鿡�� �⵵�� �Ͽ� ü���� ȸ�������ݴϴ�.</b>";
        if (discription != "")
            levelupDescription = discription;
        else
            levelupDescription = bodyDescription;
        for (int i = 0; i < 3; i++)
        {
            if (args[i] != null)
                this.args[i] = args[i].ToString();
            else
                break;
        }
    }
}
