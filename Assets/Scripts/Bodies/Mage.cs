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
                SetBodyInfo("������ 1�� �߰��մϴ�.", "", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 35, 2), "");
                break;
            case 2:
                SetBodyInfo("ȸ�� �ӵ��� �����մϴ�.", "", "", "");
                break;
            case 3:
                SetBodyInfo("���� ũ��� ���ݷ��� �����մϴ�.", "", "", "0.25/s");
                break;
            case 4:
                SetBodyInfo("������ 1�� �� �߰��ϰ� ��ġ�� �Ÿ��� �����մϴ�.", "", "", "");
                break;
            case 5:
                SetBodyInfo("���ݷ°� ȸ�� �ӵ��� �����մϴ�.", "", Math.Round(35 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 6:
                SetBodyInfo("���� ũ�Ⱑ Ŀ���� ������ 2�� �� �߰��մϴ�", "", "", "0.5/s");
                break;
        }
    }

    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "���� ������";
        bodyDescription = " <b>-[ȸ�� ȸ���� ����]-\n\n�ڽ� ������ ���� ���� �����ϴ� ������ ��ȯ�մϴ�</b>";
        if (discription != "")
            levelupDescription = discription;
        else
            levelupDescription = bodyDescription;
    }
}
