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
                SetBodyInfo("���ݷ��� �����մϴ�.", "", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 35, 2), "");
                break;
            case 2:
                SetBodyInfo("������� ũ�Ⱑ �����մϴ�.", "", "", "");
                break;
            case 3:
                SetBodyInfo("���� ������ ���ݷ��� �����մϴ�.", "", "", "0.25/s");
                break;
            case 4:
                SetBodyInfo("���� �ӵ��� �����մϴ�.", "", "", "");
                break;
            case 5:
                SetBodyInfo("������ �ݴ� ���⿡�� ����ĸ� �߻��մϴ�.", "", Math.Round(35 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 6:
                SetBodyInfo("���ݷ��� �����ϰ� ����İ� ���� ź���� �����ϴ�", "", "", "0.5/s");
                break;
        }
    }

    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "�ڻԼ� ���к�";
        bodyDescription = " <b>-[���� ���� �����]-\n\n������ ��ġ�� ����ĸ� �߻��մϴ�</b>";
        if (discription != "")
            levelupDescription = discription;
        else
            levelupDescription = bodyDescription;
    }
}
