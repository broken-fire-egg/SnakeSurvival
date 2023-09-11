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
                SetBodyInfo("공격력 증가 효과가 강화됩니다.", "1.5타일", "", "");
                break;
            case 2:
                amount.multiplier = 1.6f;
                SetBodyInfo("자신의 공격력이 증가합니다.", "", Math.Round(2 + GameInfo.Instance.damageUnit / 10, 2), "");
                break;
            case 3:
                amount.multiplier = 1.7f;
                SetBodyInfo("10초마다 아군을 광분 상태로 만듭니다.", "", "", "6/s");
                break;
            case 4:
                ragetime = 3f;
                speedBuff.multiplier = 1.3f;
                StartCoroutine(Rage());
                SetBodyInfo("자신의 공격력이 증가합니다.", "2타일", Math.Round(2 + GameInfo.Instance.damageUnit / 100 * 15, 2), "");
                break;
            case 5:
                amount.multiplier = 1.8f;


                SetBodyInfo("공격력 증가 효과가 강화되고 광분 효과가 강화됩니다", "2.5 타일", "", "7/s");
                break;
            case 6:
                amount.multiplier = 1.9f;
                ragetime = 5f;
                speedBuff.multiplier = 1.4f;
                SetBodyInfo("공격력 증가 효과를 모든 아군에게 적용합니다.", "4 타일", "", "");
                break;
            case 7:
                amount.multiplier = 2f;
                //다른곳에서 레벨이 7인지로 분기
                break;
        }
        BuffColleagues();
    }

    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "까마귀 연금술사";
        bodyDescription = " <b>-[특제 까마귀 영약]-\n\n주위 아군들에게 까마귀만의 특제 영약을 투여해 공격력을 증가시킵니다.</b>";
        if (discription != "")
            levelupDescription = discription;
        else
            levelupDescription = bodyDescription;
    }

    public override void UpdateDamageInfo()
    {

    }
}
