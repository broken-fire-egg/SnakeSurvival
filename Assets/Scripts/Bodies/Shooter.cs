using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SocialPlatforms;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class Shooter : BodyClass
{
    public GameObject enemies;
    public float power;
    public Transform gunPoint;
    public Animator gunflashAnimator;
    public int extraShot;
    public float eftDistance;

    public float range;

    public override void Activate()
    {
        PlayerInventory.instance.AddColleague(this);
        snakeBody.Activate();
        transform.GetChild(0).gameObject.SetActive(true);
    }
    protected override void Start()
    {
        base.Start();
        SetBodyInfo("", "7타일", Math.Round(10 + GameInfo.Instance.damageUnit / 100 * 20, 2), "1/s");
    }
    private void Awake()
    {
        snakeBody = GetComponent<SnakeBody>();
        wfs = new WaitForSeconds(0.1f);
    }
    private void Update()
    {
        if (!snakeBody.activated)
            return;

        //Aim();

        cooltime -= Time.deltaTime * cooltimeMultiplier;

        if (cooltime < 0)
            Shoot();
        //if (snakeBody.dir == SnakeHead.Direction.right)
        //{
        //    gunPoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180f));
        //    gunPoint.transform.localPosition = new Vector3(1.9f, -0.333f, 0);
        //}
        //if (snakeBody.dir == SnakeHead.Direction.left)
        //{

        //    gunPoint.transform.rotation = Quaternion.identity;
        //    gunPoint.transform.localPosition = new Vector3(-1.9f, -0.333f, 0);
        //}


    }

    public override void PlayHitEffect(GameObject enemy)
    {
        base.PlayHitEffect(enemy);

        CraneHitEffectObjectPool.instance.PlayEffect(enemy.transform.position);

    }
    void Aim()
    {
        var nearestEnemy = FindNearestEnemy();
        if (nearestEnemy)
        {
            Vector3 dir = nearestEnemy.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 180;
            transform.GetChild(0).rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void Shoot()
    {

        var nearestEnemy = FindNearestEnemy();
        if (nearestEnemy)
        {
            Vector3 dir = nearestEnemy.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 180;
           
            gunPoint.rotation = Quaternion.Euler(0, 0, angle);
            gunPoint.localPosition = dir.normalized * eftDistance;
            cooltime = shoottime;
            var newbullet = Instantiate(bulletpref);
            newbullet.transform.position = gunPoint.position;
            var nb = newbullet.GetComponent<Bullet>();
            nb.damage = damage;
            nb.from = this;
            newbullet.GetComponent<Rigidbody2D>().AddForce((nearestEnemy.transform.position - gunPoint.position).normalized * power);


            gunflashAnimator.gameObject.SetActive(true);
            gunflashAnimator.Play("GunFire");
            StartCoroutine(ExtraShot(nearestEnemy.transform));
        }

    }
    WaitForSeconds wfs;
    IEnumerator ExtraShot(Transform target1)
    {
        Transform target2 = null;
        if (extraShot > 0)
            if (Random.Range(0, 2) == 0)
            {
                yield return wfs;
                float nearestEnemyDistance = range;

                float tmp;
                GameObject res = null;
                for (int i = 0; i < enemies.transform.childCount; i++)
                {
                    tmp = Vector3.Distance(enemies.transform.GetChild(i).transform.position, transform.position);
                    if (tmp < nearestEnemyDistance && res != target1)
                    {
                        nearestEnemyDistance = tmp;
                        res = enemies.transform.GetChild(i).gameObject;
                        target2 = res.transform;
                        break;
                    }
                }
                if (res)
                {
                    Vector3 dir = res.transform.position - transform.position;
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 180;
                    gunPoint.rotation = Quaternion.Euler(0, 0, angle);
                    gunPoint.localPosition = dir.normalized * eftDistance;
                    var newbullet = Instantiate(bulletpref);
                    newbullet.transform.position = gunPoint.position;
                    var nb = newbullet.GetComponent<Bullet>();
                    nb.damage = damage;
                    nb.from = this;
                    newbullet.GetComponent<Rigidbody2D>().AddForce((res.transform.position - gunPoint.position).normalized * power);

                    gunflashAnimator.gameObject.SetActive(true);
                    gunflashAnimator.Play("GunFire");
                }



            }
        if (extraShot > 1)
            if (Random.Range(0, 2) == 0)
            {
                yield return wfs;
                float nearestEnemyDistance = range;

                float tmp;
                GameObject res = null;
                for (int i = 0; i < enemies.transform.childCount; i++)
                {
                    tmp = Vector3.Distance(enemies.transform.GetChild(i).transform.position, transform.position);
                    if (tmp < nearestEnemyDistance && res != target1 && res != target2)
                    {
                        nearestEnemyDistance = tmp;
                        res = enemies.transform.GetChild(i).gameObject;
                        break;
                    }
                }
                if (res)
                {
                    Vector3 dir = res.transform.position - transform.position;
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 180;
                    gunPoint.rotation = Quaternion.Euler(0, 0, angle);
                    gunPoint.localPosition = dir.normalized * eftDistance;
                    var newbullet = Instantiate(bulletpref);
                    newbullet.transform.position = gunPoint.position;
                    var nb = newbullet.GetComponent<Bullet>();
                    nb.damage = damage;
                    nb.from = this;
                    newbullet.GetComponent<Rigidbody2D>().AddForce((res.transform.position - gunPoint.position).normalized * power);

                    gunflashAnimator.gameObject.SetActive(true);
                    gunflashAnimator.Play("GunFire");
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

    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                bonusDamage = 10;
                damageCoefficient = 15;
                shoottime.baseValue = 1;
                range = 7;
                Activate();
                SetBodyInfo("공격력이 증가합니다.", "", Math.Round(15 + GameInfo.Instance.damageUnit / 100 * 25, 2), "");
                break;
            case 2:

                bonusDamage = 15;
                damageCoefficient = 20;
                SetBodyInfo("공격 속도가 증가합니다.", "", "", "1.5/s");
                break;
            case 3:
                shoottime.baseValue = 2f / 3f;
                SetBodyInfo("공격력과 공격 범위가 증가합니다.", "8타일", "", "2/s");
                break;
            case 4:
                shoottime.baseValue = 1f / 2f;
                range = 8;
                SetBodyInfo("확률적으로 추가타를 발사합니다.", "", "", "");
                break;
            case 5:
                extraShot = 1;
                SetBodyInfo("공격속도와 공격력이 증가합니다.", "", Math.Round(20 + GameInfo.Instance.damageUnit / 100 * 30, 2), "2.5/s");
                break;
            case 6:
                shoottime.baseValue = 2f / 5f;
                bonusDamage = 20;
                damageCoefficient = 25;
                SetBodyInfo("공격 속도, 공격 범위가 증가하고 추가타 개수가 증가합니다", "9타일", "", "3/s");
                break;
            case 7:
                range = 9;
                shoottime.baseValue = 1f / 3f;
                extraShot = 2;
                break;
        }
    }
    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "두루미 총사";
        bodyDescription = " <b>-[두루두루 사격]-\n\n자신 주변의 적을 빠르게 사격합니다</b>";
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

    public override void UpdateDamageInfo()
    {

        //throw new NotImplementedException();
    }
}
