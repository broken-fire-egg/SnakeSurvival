using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawer : BodyClass
{
    bool active;
    bool prevActive;
    public GameObject saw;
    public float distance;
    protected override void Start()
    {
        base.Start();
        SetBodyInfo("","1Ÿ��", Math.Round(1 + GameInfo.Instance.damageUnit / 100 * 5, 2), "5/s");
    }
    private void Awake()
    {
        snakeBody = GetComponent<SnakeBody>();
    }
    
    void Update()
    {
        active = snakeBody.activated;
        if(active != prevActive)
            saw.SetActive(active);
        prevActive = active;

        switch (snakeBody.dir)
        {
            case SnakeHead.Direction.down:
            case SnakeHead.Direction.up:
                saw.transform.rotation = Quaternion.identity;
                break;
            case SnakeHead.Direction.right:
            case SnakeHead.Direction.left:
                saw.transform.rotation = Quaternion.Euler(0,0,90);
                break;
            default:
                break;
        }

    }
    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "��� ����";
        bodyDescription = " <b>-[���� ���� ���� �鳯]- \n\n���� �帧�� �������� ȸ���ϴ� �鳯�� ������ ���ظ� �ݴϴ�.</b>";
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
    public override void LevelUp()
    {
        level++;
        switch(level)
        {
            case 1:
                snakeBody.Activate();
                SetBodyInfo("���� ������ �����մϴ�.", "1.5Ÿ��", "", "");
                break;
            case 2:
                SetBodyInfo("���ݷ��� �����մϴ�.", "", Math.Round(2 + GameInfo.Instance.damageUnit / 10,2), "");
                break;
            case 3:
                SetBodyInfo("���� �ӵ��� �����մϴ�.", "", "", "6/s");
                break;
            case 4:
                SetBodyInfo("���ݷ°� ���� ������ �����մϴ�.", "2Ÿ��", Math.Round(2 + GameInfo.Instance.damageUnit / 100 * 15, 2), "");
                break;
            case 5:
                SetBodyInfo("���� ������ ���ݼӵ��� �����մϴ�.", "2.5 Ÿ��", "", "7/s");
                break;
            case 6:
                SetBodyInfo("���� ������ ���������ϰ� �����մϴ�.", "4 Ÿ��", "", "");
                break;
        }
    }
}
