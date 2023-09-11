using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Shaman : BodyClass
{

    public float bindtime;
    public float size;
    public int spellNum;

    public List<GameObject> spellsOrigin;
    public List<GameObject> spells;

    List<Bullet> spellsBullet;
    protected override void Start()
    {
        base.Start();
        SetBodyInfo("");

        foreach (var spell in spellsOrigin)
        {
            var newgo = Instantiate(spell);
            spells.Add(newgo);
            spellsBullet.Add(newgo.GetComponent<Bullet>());
        }

    }
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
            CastSpell();
    }
    void CastSpell()
    {
        
    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                Activate();
                size = 3;
                spellNum = 0;
                shoottime.baseValue = 8;
                bindtime = 3;
                bonusDamage = 30;
                damageCoefficient = 30;
                SetBodyInfo("���ݷ��� �����մϴ�.", "", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 35, 2), "");
                break;
            case 2:
                bonusDamage = 35;
                damageCoefficient = 35;
                SetBodyInfo("������ ������ �����մϴ�.", "", "", "");
                break;
            case 3:
                size = 4;
                SetBodyInfo("�ӹ� �ð��� �����մϴ�.", "", "", "0.25/s");
                break;
            case 4:
                bindtime = 3;
                SetBodyInfo("���ݷ��� �����մϴ�.", "", "", "");
                break;
            case 5:
                bonusDamage = 40;
                damageCoefficient = 40;
                SetBodyInfo("���� �ӵ��� ������ �ߵ� �ӵ��� �����մϴ�.", "", Math.Round(35 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 6:
                shoottime.baseValue = 5;
                spellNum = 1;
                SetBodyInfo("�������� �ߵ��� �� ���� �ڸ��� �������� �����˴ϴ�", "", "", "0.5/s");
                break;
            case 7:
                spellNum = 2;
                break;
        }
        UpdateDamageInfo();
    }

    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "�ڳ��� �ּ���";
        bodyDescription = " <b>-[�ڴ��� �ּ�]-\n\n������ �ӹڽ�Ű�� �������� �����մϴ�</b>";
        if (discription != "")
            levelupDescription = discription;
        else
            levelupDescription = bodyDescription;
    }
    public override void UpdateDamageInfo()
    {
        foreach(var spell in spellsBullet)
        {
            spell.damage = damage;
        }
    }
}
