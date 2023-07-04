using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Shooter : BodyClass
{
    public GameObject enemies;
    public float power;
    protected override void Start()
    {
        base.Start();
        SetBodyInfo("", "7타일", Math.Round(10 + GameInfo.Instance.damageUnit / 100 * 20, 2), "1/s");
    }
    private void Awake()
    {
        snakeBody = GetComponent<SnakeBody>();
    }
    private void Update()
    {
        if (!snakeBody.activated)
            return;
       cooltime -= Time.deltaTime;

        if (cooltime < 0)
            Shoot();

    }
    void Shoot()
    {

        var nearestEnemy = FindNearestEnemy();
        if (nearestEnemy)
        {
            cooltime = shoottime;
            var newbullet = Instantiate(bulletpref);
            newbullet.transform.position = transform.position;
            newbullet.GetComponent<Rigidbody2D>().AddForce((nearestEnemy.transform.position - transform.position).normalized * power);


        }

    }

    GameObject FindNearestEnemy()
    {
        float nearestEnemyDistance = 99999999f;
        
        float tmp;
        GameObject res = null;
        for(int i = 0;i< enemies.transform.childCount;i++)
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
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                
                SetBodyInfo("공격력이 증가합니다.", "", Math.Round(15 + GameInfo.Instance.damageUnit / 100 * 25, 2), "");
                break;
            case 2:
                SetBodyInfo("공격 속도가 증가합니다.", "", "", "1.5/s");
                break;
            case 3:
                SetBodyInfo("공격력과 공격 범위가 증가합니다.", "8타일", "", "2/s");
                break;
            case 4:
                SetBodyInfo("확률적으로 추가타를 발사합니다. <i><공격 시 50% 확률로 공격 대상이 아닌 다음 대상을 향해 추가 공격\r\n기존 탄막 발사와 동시에 추가 탄막 발사></i>", "", "", "");
                break;
            case 5:
                SetBodyInfo("공격속도와 공격력이 증가합니다.", "", Math.Round(20 + GameInfo.Instance.damageUnit / 100 * 30, 2), "2.5/s");
                break;
            case 6:
                SetBodyInfo("공격 속도, 공격 범위가 증가하고 추가타 개수가 증가합니다\r\n<i><공격 시 50% 확률로 공격 대상 (기존 추가타 대상도 포함)이 아닌 다음 대상을 향해 추가 공격\r\n기존 탄막 발사와 동시에 추가 탄막 발사\r\n첫번째 추가타 확률과 별개로 확률 계산></i>", "9타일", "", "3/s");
                break;
        }
    }
    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "두루미 총사";
        bodyDescription = " <b>-[두루두루 사격]-자신 주변의 적을 빠르게 사격합니다</b>\n\n<i><공격 범위내에서 가장 가까운 적에게 탄막을 발사\n탄막에 맞은 적은 탄막의 진행 방향으로 0.2타일 넉백></i>";
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
