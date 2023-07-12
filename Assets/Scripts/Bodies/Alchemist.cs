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
                SetBodyInfo("공격력 증가 효과가 강화됩니다.", "1.5타일", "", "");
                break;
            case 2:
                SetBodyInfo("자신의 공격력이 증가합니다.", "", Math.Round(2 + GameInfo.Instance.damageUnit / 10, 2), "");
                break;
            case 3:
                SetBodyInfo("10초마다 아군을 광분 상태로 만듭니다.", "", "", "6/s");
                break;
            case 4:
                SetBodyInfo("자신의 공격력이 증가합니다.", "2타일", Math.Round(2 + GameInfo.Instance.damageUnit / 100 * 15, 2), "");
                break;
            case 5:
                SetBodyInfo("공격력 증가 효과가 강화되고 광분 효과가 강화됩니다", "2.5 타일", "", "7/s");
                break;
            case 6:
                SetBodyInfo("공격력 증가 효과를 모든 아군에게 적용합니다.", "4 타일", "", "");
                break;
        }
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
}
