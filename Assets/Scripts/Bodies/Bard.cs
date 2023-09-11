using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bard : BodyClass
{
    public float stuntime;
    public float range;

    Transform wave;
    public Bullet waveBullet;

    protected override void Start()
    {
        base.Start();
        SetBodyInfo("");
        wave = transform.GetChild(0);
        waveBullet = wave.GetComponent<Bullet>();
    }
    private void Update()
    {
        if (!snakeBody.activated)
            return;

        //Aim();

        cooltime -= Time.deltaTime * cooltimeMultiplier;

        if (cooltime < 0)
            Attack();


    }
    public void Attack()
    {
        wave.gameObject.SetActive(true);
        //waveAnimator.Play("Attack");
        cooltime = shoottime;
    }
    public override void Activate()
    {
        PlayerInventory.instance.AddColleague(this);
        snakeBody.Activate();
    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                Activate();
                bonusDamage = 10;
                damageCoefficient = 30;
                shoottime.baseValue = 8f;
                stuntime = 1;
                range = 3.5f;
                SetBodyInfo("공격 범위가 증가합니다.", "", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 35, 2), "");
                break;
            case 2:
                range = 4;
                SetBodyInfo("공격력이 증가합니다.", "", "", "");
                break;
            case 3:
                bonusDamage = 10;
                damageCoefficient = 40;
                SetBodyInfo("공격 범위와 공격 속도가 증가합니다.", "", "", "0.25/s");
                break;

            case 4:
                range = 4.5f;
                shoottime.baseValue = 6.06f;
                SetBodyInfo("기절 시간이 증가합니다.", "", "", "");
                break;

            case 5:
                stuntime = 1.25f;
                SetBodyInfo("공격 범위와 공격력이 증가합니다.", "", Math.Round(35 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;

            case 6:
                range = 5;
                bonusDamage = 10;
                damageCoefficient = 50;
                SetBodyInfo("기절 시간이 증가하고 치명타일 시 기절 시간이 더 증가합니다", "", "", "0.5/s");
                break;
            case 7:
                stuntime = 1.5f;
                break;
        }
        UpdateDamageInfo();
        wave.transform.localScale = new Vector3(range, range, 1);
    }
    public override void UpdateDamageInfo()
    {
        waveBullet.damage = damage;
        waveBullet.stun = stuntime;
    }
    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "방울뱀 음유시인";
        bodyDescription = " <b>-[딸랑딸랑]-\n\n파동을 발사해 주변의 적들을 기절시킵니다</b>";
        if (discription != "")
            levelupDescription = discription;
        else
            levelupDescription = bodyDescription;
    }
}
