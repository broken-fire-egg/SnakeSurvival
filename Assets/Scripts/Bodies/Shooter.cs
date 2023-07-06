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
        SetBodyInfo("", "7Ÿ��", Math.Round(10 + GameInfo.Instance.damageUnit / 100 * 20, 2), "1/s");
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
    public void Activate()
    {
        snakeBody.Activate();
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                Activate();
                SetBodyInfo("���ݷ��� �����մϴ�.", "", Math.Round(15 + GameInfo.Instance.damageUnit / 100 * 25, 2), "");
                break;
            case 2:
                SetBodyInfo("���� �ӵ��� �����մϴ�.", "", "", "1.5/s");
                break;
            case 3:
                SetBodyInfo("���ݷ°� ���� ������ �����մϴ�.", "8Ÿ��", "", "2/s");
                break;
            case 4:
                SetBodyInfo("Ȯ�������� �߰�Ÿ�� �߻��մϴ�.", "", "", "");
                break;
            case 5:
                SetBodyInfo("���ݼӵ��� ���ݷ��� �����մϴ�.", "", Math.Round(20 + GameInfo.Instance.damageUnit / 100 * 30, 2), "2.5/s");
                break;
            case 6:
                SetBodyInfo("���� �ӵ�, ���� ������ �����ϰ� �߰�Ÿ ������ �����մϴ�", "9Ÿ��", "", "3/s");
                break;
        }
    }
    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "�η�� �ѻ�";
        bodyDescription = " <b>-[�η�η� ���]-\n\n�ڽ� �ֺ��� ���� ������ ����մϴ�</b>";
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
