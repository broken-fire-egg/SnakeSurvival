using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alchemist : BodyClass
{

    Multiplier amount;
    Multiplier speedBuff;
    public BodyClass frontColleague;
    public BodyClass backColleague;
    float ragetime = 0;

    float buffedamountfront;
    float buffedamountback;
    protected override void Start()
    {
        base.Start();
        SetBodyInfo("");
        amount = new Multiplier();
        speedBuff = new Multiplier();
        frontColleague = null;
        backColleague = null;
    }
    public override void Activate()
    {
        PlayerInventory.instance.AddColleague(this);
        snakeBody.Activate();
        //GameInfo.Instance.damageMultiply += amount;
    }
    void Update()
    {
        if (!snakeBody.activated)
            return;
        cooltime -= Time.deltaTime * cooltimeMultiplier;


    }

    IEnumerator Rage()
    {
        while (true)
        {
            speedBuff.Active = true;
            yield return new WaitForSeconds(ragetime);
            speedBuff.Active = false;
            yield return new WaitForSeconds(10f);
        }
    }


    public void BuffColleagues()
    {

        var colleagues = PlayerInventory.instance.currentColleagues;

        if (level == 7)
        {
            foreach (var c in colleagues)
            {
                c.damageMultiplier += amount;
                c.UpdateDamageInfo();
            }
            return;
        }

        if (!frontColleague)
            if (colleagues.IndexOf(this) > 0)
            {
                Debug.Log(colleagues[colleagues.IndexOf(this) - 1]);
                frontColleague = colleagues[colleagues.IndexOf(this) - 1];
            }
            else
                frontColleague = null;

        if (!backColleague)
            if (colleagues.IndexOf(this) < colleagues.Count - 1)
                backColleague = colleagues[colleagues.IndexOf(this) + 1] ?? null;
            else
                backColleague = null;

        if (frontColleague)
        {
            frontColleague.damageMultiplier += amount;
            frontColleague.shoottime += speedBuff;
            frontColleague.UpdateDamageInfo();
        }
        else if (colleagues.IndexOf(this) == 0)
        {
            GameInfo.Instance.damageMultiply += amount;
            SnakeHead.instance.speedMultiplier += speedBuff;
        }
            if (backColleague)
            {
                backColleague.damageMultiplier += amount;
                backColleague.UpdateDamageInfo();
            }
    }

    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                amount.multiplier = 1.5f;
                Activate();
                SnakeBodyManager.instance.onNewColleagueDetected += BuffColleagues;
                SetBodyInfo("���ݷ� ���� ȿ���� ��ȭ�˴ϴ�.", "1.5Ÿ��", "", "");
                break;
            case 2:
                amount.multiplier = 1.6f;
                SetBodyInfo("�ڽ��� ���ݷ��� �����մϴ�.", "", Math.Round(2 + GameInfo.Instance.damageUnit / 10, 2), "");
                break;
            case 3:
                amount.multiplier = 1.7f;
                SetBodyInfo("10�ʸ��� �Ʊ��� ���� ���·� ����ϴ�.", "", "", "6/s");
                break;
            case 4:
                ragetime = 3f;
                speedBuff.multiplier = 1.3f;
                StartCoroutine(Rage());
                SetBodyInfo("�ڽ��� ���ݷ��� �����մϴ�.", "2Ÿ��", Math.Round(2 + GameInfo.Instance.damageUnit / 100 * 15, 2), "");
                break;
            case 5:
                amount.multiplier = 1.8f;


                SetBodyInfo("���ݷ� ���� ȿ���� ��ȭ�ǰ� ���� ȿ���� ��ȭ�˴ϴ�", "2.5 Ÿ��", "", "7/s");
                break;
            case 6:
                amount.multiplier = 1.9f;
                ragetime = 5f;
                speedBuff.multiplier = 1.4f;
                SetBodyInfo("���ݷ� ���� ȿ���� ��� �Ʊ����� �����մϴ�.", "4 Ÿ��", "", "");
                break;
            case 7:
                amount.multiplier = 2f;
                //�ٸ������� ������ 7������ �б�
                break;
        }
        BuffColleagues();
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

    public override void UpdateDamageInfo()
    {

    }
}
