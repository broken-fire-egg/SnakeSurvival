using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using static UnityEngine.GraphicsBuffer;

public class Shieldbearer : BodyClass
{

    public GameObject enemies;
    public bool backFire;
    public float wavespeed;
   public Transform backwave;
   public Transform wave;
    Rigidbody2D wavergbd;
    Rigidbody2D backwavergbd;
    public KnockbackBullet waveBullet;
    public KnockbackBullet backWaveBullet;
    public float range;
    public override void Activate()
    {
        PlayerInventory.instance.AddColleague(this);
        snakeBody.Activate();
    }
    private void Update()
    {
        if (!snakeBody.activated)
            return;
        cooltime -= Time.deltaTime * cooltimeMultiplier;
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
            dir.Normalize();
            wave.localRotation = Quaternion.Euler(0, 0, angle);
            backwave.localRotation = Quaternion.Euler(0, 0, -angle);

            wave.gameObject.SetActive(true);
            wave.transform.position = transform.position;
            wavergbd.AddForce(dir * wavespeed);
            if (backFire)
            {
                backwave.gameObject.SetActive(true);
                backwave.transform.position = transform.position;
                backwavergbd.AddForce(-dir * wavespeed);
            }


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
        SetBodyInfo("");
        waveBullet = wave.GetComponent<KnockbackBullet>();
        backWaveBullet = backwave.GetComponent<KnockbackBullet>();
        wavergbd = wave.GetComponent<Rigidbody2D>();
        backwavergbd = backwave.GetComponent<Rigidbody2D>();
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
                damageCoefficient = 20;
                shoottime.baseValue = 3;
                SetBodyInfo("공격력이 증가합니다.", "", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 35, 2), "");
                break;
            case 2:

                bonusDamage = 35;
                damageCoefficient = 25;
                SetBodyInfo("충격파의 크기가 증가합니다.", "", "", "");
                break;
            case 3:
                wave.localScale = new Vector3(1, 1.25f, 1f);
                backwave.localScale = new Vector3(1, 1.25f, 1f);

                SetBodyInfo("공격 범위와 공격력이 증가합니다.", "", "", "0.25/s");
                break;
            case 4:
                range = 3f;
                bonusDamage = 40;
                damageCoefficient = 30;
                SetBodyInfo("공격 속도가 증가합니다.", "", "", "");
                break;
            case 5:
                shoottime.baseValue = 2;
                SetBodyInfo("공격한 반대 방향에도 충격파를 발사합니다.", "", Math.Round(35 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 6:

                backFire = true;
                SetBodyInfo("공격력이 증가하고 충격파가 적의 탄막을 막습니다", "", "", "0.5/s");
                break;
            case 7:
                bonusDamage = 45;
                damageCoefficient = 50;
                break;
        }


        UpdateDamageInfo();
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

    public override void UpdateDamageInfo()
    {

        waveBullet.damage = damage;
        backWaveBullet.damage = damage;
    }
}
