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
                SetBodyInfo("���ݷ��� �����մϴ�.", "", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 35, 2), "");
                break;
            case 2:

                bonusDamage = 35;
                damageCoefficient = 25;
                SetBodyInfo("������� ũ�Ⱑ �����մϴ�.", "", "", "");
                break;
            case 3:
                wave.localScale = new Vector3(1, 1.25f, 1f);
                backwave.localScale = new Vector3(1, 1.25f, 1f);

                SetBodyInfo("���� ������ ���ݷ��� �����մϴ�.", "", "", "0.25/s");
                break;
            case 4:
                range = 3f;
                bonusDamage = 40;
                damageCoefficient = 30;
                SetBodyInfo("���� �ӵ��� �����մϴ�.", "", "", "");
                break;
            case 5:
                shoottime.baseValue = 2;
                SetBodyInfo("������ �ݴ� ���⿡�� ����ĸ� �߻��մϴ�.", "", Math.Round(35 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 6:

                backFire = true;
                SetBodyInfo("���ݷ��� �����ϰ� ����İ� ���� ź���� �����ϴ�", "", "", "0.5/s");
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
        bodyName = "�ڻԼ� ���к�";
        bodyDescription = " <b>-[���� ���� �����]-\n\n������ ��ġ�� ����ĸ� �߻��մϴ�</b>";
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
