using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bard : BodyClass
{
    public void Activate()
    {
        snakeBody.Activate();
    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                Activate();
                SetBodyInfo("공격 범위가 증가합니다.", "", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 35, 2), "");
                break;
            case 2:
                SetBodyInfo("공격력이 증가합니다.", "", "", "");
                break;
            case 3:
                SetBodyInfo("공격 범위와 공격 속도가 증가합니다.", "", "", "0.25/s");
                break;
            case 4:
                SetBodyInfo("기절 시간이 증가합니다.", "", "", "");
                break;
            case 5:
                SetBodyInfo("공격 범위와 공격력이 증가합니다.", "", Math.Round(35 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 6:
                SetBodyInfo("기절 시간이 증가하고 치명타일 시 기절 시간이 더 증가합니다", "", "", "0.5/s");
                break;
        }
    }

    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "방울뱀 음유시인";
        bodyDescription = " <b>-[딸랑딸랑]-\n\n파동을 발사해 주변의 적들을 기절시킵니다</b>";
        if (discription != "")
            levelupDescription = discription;
        else
            levelupDescription = bodyDescription;
    }
}
