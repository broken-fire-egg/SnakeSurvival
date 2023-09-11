using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Spinner : BodyClass
{
    public float radius;
    public float speed;
    public Transform center;
    List<Bullet> clamBullets;
    List<Transform> clams;
    
    private void Awake()
    {
        center = transform.GetChild(0);
        clams = new List<Transform>();
        clams.Add(center.GetChild(0));
        clamBullets = new List<Bullet>();
        clamBullets.Add(center.GetChild(0).GetComponent<Bullet>());
    }
    public override void Activate()
    {
        PlayerInventory.instance.AddColleague(this);
        snakeBody.Activate(); 
        center.gameObject.SetActive(true);
        SetClamsPosition();
    }
    public override void PlayHitEffect(GameObject enemy)
    {

        base.PlayHitEffect(enemy);

        MazeOtterHitEffectObjectPool.instance.PlayEffect(enemy.transform.position);

    }

    protected override void Start()
    {
        base.Start();
        SetClamsPosition();
        SetBodyInfo("");
    }
    void AddClam()
    {
        var newclam = Instantiate(center.GetChild(0), center);
        clams.Add(newclam);
        clamBullets.Add(newclam.GetComponent<Bullet>());
        SetClamsPosition();
    }
    void SetClamSize(float size)
    {
        foreach(var clam in clams)
        {
            clam.localScale = new Vector3(size, size);
        }
    }
    public void SetClamsPosition()
    {
        int _planetCount = center.childCount;
        for (int i = 0; i < _planetCount; i++)
        {
            var planet = center.GetChild(i);
            planet.localPosition = Quaternion.AngleAxis(360 / _planetCount * i, Vector3.back) * Vector2.right * radius;
            
        }
    }

    void FixedUpdate()
    {
        var cycle = Vector3.forward * speed * shoottime;
        center.Rotate(cycle);
        foreach (var clam in clams)
        {
            clam.Rotate(-cycle);
        }

        
    }

    public void UpdateDamage()
    {
        foreach (var clambullet in clamBullets)
        {
            clambullet.damage = damage;
        }
    }

    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                damageCoefficient = 20;
                bonusDamage = 20;
                shoottime.baseValue = 1f;
                Activate();
                SetBodyInfo("������ 1�� �߰��մϴ�.", "", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 35, 2), "");
                break;
            case 2:
                AddClam();
                SetBodyInfo("ȸ�� �ӵ��� �����մϴ�.", "", "", "");
                break;
            case 3:
                speed += 4;
                SetBodyInfo("���� ũ��� ���ݷ��� �����մϴ�.", "", "", "0.25/s");
                break;
            case 4:
                SetClamSize(1.25f);
                damageCoefficient = 25;
                bonusDamage = 25;
                //radius += 1;
                SetBodyInfo("������ 1�� �� �߰��ϰ� ��ġ�� �Ÿ��� �����մϴ�", "", "", "");
                break;
            case 5:
                AddClam();
                SetBodyInfo("���ݷ°� ȸ�� �ӵ��� �����մϴ�.", "", Math.Round(35 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 6:
                damageCoefficient = 30;
                bonusDamage = 30;
                speed += 4;
                SetBodyInfo("���� ũ�Ⱑ Ŀ���� ������ 2�� �� �߰��մϴ�.", "", "", "0.5/s");
                break;
            case 7:
                SetClamSize(1.5f);
                //radius += 1;
                AddClam();
                AddClam();
                break;
        }
        UpdateDamage();
    }

    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "���� ������";
        bodyDescription = " <b>-[ȸ�� ȸ���� ����]-\n\n�ڽ� ������ ���� ���� �����ϴ� ������ ��ȯ�մϴ�</b>";
        if (discription != "")
            levelupDescription = discription;
        else
            levelupDescription = bodyDescription;
    }

    public override void UpdateDamageInfo()
    {
        UpdateDamage();
    }
}
