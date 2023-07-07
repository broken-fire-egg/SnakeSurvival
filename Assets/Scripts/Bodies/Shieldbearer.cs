using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shieldbearer : BodyClass
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
                SetBodyInfo("공격력이 증가합니다.", "", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 35, 2), "");
                break;
            case 2:
                SetBodyInfo("충격파의 크기가 증가합니다.", "", "", "");
                break;
            case 3:
                SetBodyInfo("공격 범위와 공격력이 증가합니다.", "", "", "0.25/s");
                break;
            case 4:
                SetBodyInfo("공격 속도가 증가합니다.", "", "", "");
                break;
            case 5:
                SetBodyInfo("공격한 반대 방향에도 충격파를 발사합니다.", "", Math.Round(35 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 6:
                SetBodyInfo("공격력이 증가하고 충격파가 적의 탄막을 막습니다", "", "", "0.5/s");
                break;
        }
    }

    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "코뿔소 방패병";
        bodyDescription = " <b>-[돌진 방패 충격파]-\n\n적들을 밀치는 충격파를 발사합니다</b>";
        if (discription != "")
            levelupDescription = discription;
        else
            levelupDescription = bodyDescription;
    }
}
