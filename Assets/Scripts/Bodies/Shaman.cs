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
                SetBodyInfo("공격력이 증가합니다.", "", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 35, 2), "");
                break;
            case 2:
                bonusDamage = 35;
                damageCoefficient = 35;
                SetBodyInfo("마법진 범위가 증가합니다.", "", "", "");
                break;
            case 3:
                size = 4;
                SetBodyInfo("속박 시간이 증가합니다.", "", "", "0.25/s");
                break;
            case 4:
                bindtime = 3;
                SetBodyInfo("공격력이 증가합니다.", "", "", "");
                break;
            case 5:
                bonusDamage = 40;
                damageCoefficient = 40;
                SetBodyInfo("공격 속도와 마법진 발동 속도가 증가합니다.", "", Math.Round(35 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 6:
                shoottime.baseValue = 5;
                spellNum = 1;
                SetBodyInfo("마법진이 발동한 후 같은 자리에 마법진이 생성됩니다", "", "", "0.5/s");
                break;
            case 7:
                spellNum = 2;
                break;
        }
        UpdateDamageInfo();
    }

    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "코끼리 주술사";
        bodyDescription = " <b>-[코대의 주술]-\n\n적들을 속박시키는 마법진을 생성합니다</b>";
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
