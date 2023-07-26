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
                SetBodyInfo("공격력이 증가합니다.", "", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 35, 2), "");
                break;
            case 2:

                bonusDamage = 35;
                damageCoefficient = 35;
                SetBodyInfo("충격파의 크기가 증가합니다.", "", "", "");
                break;
            case 3:


                SetBodyInfo("공격 범위와 공격력이 증가합니다.", "", "", "0.25/s");
                break;
            case 4:
                range = 3f;
                bonusDamage = 40;
                damageCoefficient = 40;
                SetBodyInfo("공격 속도가 증가합니다.", "", "", "");
                break;
            case 5:
                shoottime = 2;
                SetBodyInfo("공격한 반대 방향에도 충격파를 발사합니다.", "", Math.Round(35 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 6:

                bonusDamage = 45;
                damageCoefficient = 50;
                SetBodyInfo("공격력이 증가하고 충격파가 적의 탄막을 막습니다", "", "", "0.5/s");
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
        bodyName = "코뿔소 방패병";
        bodyDescription = " <b>-[돌진 방패 충격파]-\n\n적들을 밀치는 충격파를 발사합니다</b>";
        if (discription != "")
            levelupDescription = discription;
        else
            levelupDescription = bodyDescription;
    }
}
