using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bard : BodyClass
{
    float stuntime;
    CircleCollider2D attackRange;
    protected override void Start()
    {
        base.Start();
        attackRange = transform.GetChild(0).GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        if (!snakeBody.activated)
            return;

        //Aim();

        cooltime -= Time.deltaTime;

        if (cooltime < 0)
            Attack();


    }
    public void Attack()
    {
        cooltime = shoottime;
    }


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
                SetBodyInfo("���� ������ �����մϴ�.", "", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 35, 2), "");
                break;
            case 2:
                attackRange.radius = 8;
                SetBodyInfo("���ݷ��� �����մϴ�.", "", "", "");
                break;
            case 3:
                damageAmount += 1;
                SetBodyInfo("���� ������ ���� �ӵ��� �����մϴ�.", "", "", "0.25/s");
                break;

            case 4:
                attackRange.radius = 9;
                shoottime = 6;
                SetBodyInfo("���� �ð��� �����մϴ�.", "", "", "");
                break;

            case 5:
                SetBodyInfo("���� ������ ���ݷ��� �����մϴ�.", "", Math.Round(35 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;

            case 6:
                attackRange.radius = 10;
                SetBodyInfo("���� �ð��� �����ϰ� ġ��Ÿ�� �� ���� �ð��� �� �����մϴ�", "", "", "0.5/s");
                break;
        }
    }

    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "���� ��������";
        bodyDescription = " <b>-[��������]-\n\n�ĵ��� �߻��� �ֺ��� ������ ������ŵ�ϴ�</b>";
        if (discription != "")
            levelupDescription = discription;
        else
            levelupDescription = bodyDescription;
    }
}
