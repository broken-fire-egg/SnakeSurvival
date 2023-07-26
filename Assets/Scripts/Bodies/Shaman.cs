using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaman : BodyClass
{
    protected override void Start()
    {
        base.Start();
        SetBodyInfo("");
    }
    public override void Activate()
    {
        snakeBody.Activate();
        PlayerInventory.instance.AddColleague(this);
    }
    private void Update()
    {
        if (!snakeBody.activated)
            return;

        cooltime -= Time.deltaTime;

        if (cooltime < 0)
            CastSpell();
    }
    void CastSpell()
    {
        
    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                Activate();
                SetBodyInfo("공격력이 증가합니다.", "", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 35, 2), "");
                break;
            case 2:
                SetBodyInfo("마법진 범위가 증가합니다.", "", "", "");
                break;
            case 3:
                SetBodyInfo("속박 시간이 증가합니다.", "", "", "0.25/s");
                break;
            case 4:
                SetBodyInfo("공격력이 증가합니다.", "", "", "");
                break;
            case 5:
                SetBodyInfo("공격 속도와 마법진 발동 속도가 증가합니다.", "", Math.Round(35 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 6:
                SetBodyInfo("마법진이 발동한 후 같은 자리에 마법진이 생성됩니다", "", "", "0.5/s");
                break;
            case 7:
                break;
        }
    }

    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "코끼리 주술사";
        bodyDescription = " <b>-[코대의 주술]-\n\n적들을 속박시키는 마법진을 생성합니다</b>";
        if (discription != "")
            levelupDescription = discription;
        else
            levelupDescription = bodyDescription;
    }
}
