using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alchemist : BodyClass
{

    float amount = 1;
    BodyClass frontColleague;
    BodyClass backColleague;
    protected override void Start()
    {
        base.Start();
        SetBodyInfo("");
        frontColleague = null;
        backColleague = null;
    }

    void Update()
    {
        if (!snakeBody.activated)
            return;
        cooltime -= Time.deltaTime;

        if (cooltime < 0)
            ActiveRageSkill();
    }

    void PlayAnimation()
    {
    }

    public void ActiveRageSkill()
    {
        if (frontColleague)
            StartCoroutine(Rage(frontColleague));
        if (backColleague)
            StartCoroutine(Rage(backColleague));
    }

    IEnumerator Rage(BodyClass target)
    {
        while (true)
        {


            yield return null;
        }
    }


    void BuffColleagues()
    {

        var colleagues = PlayerInventory.instance.currentColleagues;

        if (!frontColleague)
            if (colleagues.IndexOf(this) > 0)
                frontColleague = colleagues[colleagues.IndexOf(this) - 1];
            else
                frontColleague = null;

        if (!backColleague)
            if (colleagues.IndexOf(this) < colleagues.Count - 1)
                backColleague = colleagues[colleagues.IndexOf(this) + 1] ?? null;
            else
                backColleague = null;

        if (frontColleague)
            frontColleague.bonusDamage = amount;

        if (backColleague)
            backColleague.bonusDamage = amount;

    }

    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                snakeBody.Activate();
                SetBodyInfo("���ݷ� ���� ȿ���� ��ȭ�˴ϴ�.", "1.5Ÿ��", "", "");
                break;
            case 2:
                SetBodyInfo("�ڽ��� ���ݷ��� �����մϴ�.", "", Math.Round(2 + GameInfo.Instance.damageUnit / 10, 2), "");
                break;
            case 3:
                SetBodyInfo("10�ʸ��� �Ʊ��� ���� ���·� ����ϴ�.", "", "", "6/s");
                break;
            case 4:
                SetBodyInfo("�ڽ��� ���ݷ��� �����մϴ�.", "2Ÿ��", Math.Round(2 + GameInfo.Instance.damageUnit / 100 * 15, 2), "");
                break;
            case 5:
                SetBodyInfo("���ݷ� ���� ȿ���� ��ȭ�ǰ� ���� ȿ���� ��ȭ�˴ϴ�", "2.5 Ÿ��", "", "7/s");
                break;
            case 6:
                SetBodyInfo("���ݷ� ���� ȿ���� ��� �Ʊ����� �����մϴ�.", "4 Ÿ��", "", "");
                break;
        }
    }

    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "��� ���ݼ���";
        bodyDescription = " <b>-[Ư�� ��� ����]-\n\n���� �Ʊ��鿡�� ��͸��� Ư�� ������ ������ ���ݷ��� ������ŵ�ϴ�.</b>";
        if (discription != "")
            levelupDescription = discription;
        else
            levelupDescription = bodyDescription;
    }
}
