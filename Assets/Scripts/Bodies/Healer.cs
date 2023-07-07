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
                SetBodyInfo("회복 위력이 증가합니다.", "1.5타일", "", "");
                break;
            case 2:
                SetBodyInfo("공격 속도가 증가합니다.", "", Math.Round(2 + GameInfo.Instance.damageUnit / 10, 2), "");
                break;
            case 3:
                SetBodyInfo("자신의 공격력이 증가합니다.", "", "", "6/s");
                break;
            case 4:
                SetBodyInfo("20초마다 아군에게 피해를 막아주는 보호막을 생성합니다.", "2타일", Math.Round(2 + GameInfo.Instance.damageUnit / 100 * 15, 2), "");
                break;
            case 5:
                SetBodyInfo("회복 위력과 공격 속도가 증가합니다.", "2.5 타일", "", "7/s");
                break;
            case 6:
                SetBodyInfo("보호막이 있는 동안 추가효과를 제공하고 자신에게도 보호막을 생성합니다.", "4 타일", "", "");
                break;
        }
    }

    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "페럿 수녀";
        bodyDescription = " <b>-[부드러운 기도]-\n\n주위 아군들에게 기도를 하여 체력을 회복시켜줍니다.</b>";
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
