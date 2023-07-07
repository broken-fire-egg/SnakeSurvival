using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : BodyClass
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
                SetBodyInfo("조개를 1개 추가합니다.", "", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 35, 2), "");
                break;
            case 2:
                SetBodyInfo("회전 속도가 증가합니다.", "", "", "");
                break;
            case 3:
                SetBodyInfo("조개 크기와 공격력이 증가합니다.", "", "", "0.25/s");
                break;
            case 4:
                SetBodyInfo("조개를 1개 더 추가하고 밀치는 거리가 증가합니다.", "", "", "");
                break;
            case 5:
                SetBodyInfo("공격력과 회전 속도가 증가합니다.", "", Math.Round(35 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 6:
                SetBodyInfo("조개 크기가 커지고 조개를 2개 더 추가합니다", "", "", "0.5/s");
                break;
        }
    }

    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "수달 마법사";
        bodyDescription = " <b>-[회전 회오리 조개]-\n\n자신 주위를 돌며 적을 공격하는 조개를 소환합니다</b>";
        if (discription != "")
            levelupDescription = discription;
        else
            levelupDescription = bodyDescription;
    }
}
