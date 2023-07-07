using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : BodyClass
{
    private void Awake()
    {
        snakeBody = GetComponent<SnakeBody>();
    }
    protected override void Start()
    {
        base.Start();
        SetBodyInfo("", "3Ÿ��", Math.Round(20 + GameInfo.Instance.damageUnit / 100 * 30, 2), "0.25/s");
    }
    // Update is called once per frame
    void Update()
    {
        if (!snakeBody.activated)
            return;
        cooltime -= Time.deltaTime;

        if (cooltime < 0)
            PlayDeployAnimation();
    }

    public void PlayDeployAnimation()
    {
        snakeBody.animator.Play("Attack");
    }


    private void Deploy()
    {
        cooltime = shoottime;
        Instantiate(bulletpref, transform.position, transform.rotation);
    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                snakeBody.Activate();
                SetBodyInfo("���� ������ �����մϴ�.", "4Ÿ��", "", "");
                break;
            case 2:
                SetBodyInfo("���ݷ��� �����մϴ�.", "", Math.Round(25 + GameInfo.Instance.damageUnit /100 * 35, 2), "");
                break;
            case 3:
                SetBodyInfo("�ѹ��� 2���� ���ڸ� ��ġ�մϴ�.", "", "", "");
                break;
            case 4:
                SetBodyInfo("���ݷ°� ���� ������ �����մϴ�.", "5Ÿ��", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 5:
                SetBodyInfo("�߰��� 1���� ���ڸ� �� ��ġ�մϴ�", "", "", "");
                break;
            case 6:
                SetBodyInfo("�߰��� 1���� ���ڸ� �� ��ġ�ϰ� ������ Ž�� �ݰ��� �����մϴ�", "", "", "");
                break;
        }
    }
    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "�δ��� ���ĺ�";
        bodyDescription = " <b>-[�δ����� ���� ����]-\n\n�ֱ������� ���ڸ� ��ġ�Ͽ� ������ ������ ���ظ� �ݴϴ�.</b>";
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
