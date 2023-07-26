using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Shieldbearer : BodyClass
{

    public GameObject enemies;
    public bool backFire;
    Transform backwave;
    Transform wave;
    public KnockbackBullet waveBullet;
    public KnockbackBullet backWaveBullet;
    public float range;
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
            Attack();
    }

    void Attack()
    {
        GameObject target = FindNearestEnemy();
        if(target)
        {
            cooltime = shoottime;

            Vector3 dir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 180;

            wave.localRotation = Quaternion.Euler(0, 0, angle);
            backwave.localRotation = Quaternion.Euler(0, 0, -angle);
        }


    }

    GameObject FindNearestEnemy()
    {
        float nearestEnemyDistance = range;

        float tmp;
        GameObject res = null;
        for (int i = 0; i < enemies.transform.childCount; i++)
        {
            tmp = Vector3.Distance(enemies.transform.GetChild(i).transform.position, transform.position);
            if (tmp < nearestEnemyDistance)
            {
                nearestEnemyDistance = tmp;
                res = enemies.transform.GetChild(i).gameObject;
            }
        }
        return res;
    }



    protected override void Start()
    {
        base.Start();
        wave = transform.GetChild(0);
        backwave = transform.GetChild(1);
        waveBullet = wave.GetComponent<KnockbackBullet>();
        backWaveBullet = backwave.GetComponent<KnockbackBullet>();
    }







    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                Activate();
                range = 2.5f;
                bonusDamage = 30;
                damageCoefficient = 30;
                shoottime = 3;
                SetBodyInfo("���ݷ��� �����մϴ�.", "", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 35, 2), "");
                break;
            case 2:

                bonusDamage = 35;
                damageCoefficient = 35;
                SetBodyInfo("������� ũ�Ⱑ �����մϴ�.", "", "", "");
                break;
            case 3:


                SetBodyInfo("���� ������ ���ݷ��� �����մϴ�.", "", "", "0.25/s");
                break;
            case 4:
                range = 3f;
                bonusDamage = 40;
                damageCoefficient = 40;
                SetBodyInfo("���� �ӵ��� �����մϴ�.", "", "", "");
                break;
            case 5:
                shoottime = 2;
                SetBodyInfo("������ �ݴ� ���⿡�� ����ĸ� �߻��մϴ�.", "", Math.Round(35 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 6:

                bonusDamage = 45;
                damageCoefficient = 50;
                SetBodyInfo("���ݷ��� �����ϰ� ����İ� ���� ź���� �����ϴ�", "", "", "0.5/s");
                break;
            case 7:
                backFire = true;
                break;
        }


        waveBullet.damage = damage;
        backWaveBullet.damage = damage;


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
