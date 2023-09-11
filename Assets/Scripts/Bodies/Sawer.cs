using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawer : BodyClass
{
    bool active;
    bool prevActive;
    public GameObject saw;
    public Saw saw1;
    public Saw saw2;
    public float distance;
    protected override void Start()
    {
        base.Start();
        SetBodyInfo("","1타일", Math.Round(1 + GameInfo.Instance.damageUnit / 100 * 5, 2), "5/s");

        saw1 = saw.transform.GetChild(0).GetComponent<Saw>();
        saw2 = saw.transform.GetChild(1).GetComponent<Saw>();
    }
    private void Awake()
    {
        snakeBody = GetComponent<SnakeBody>();
    }
    public override void Activate()
    {
        PlayerInventory.instance.AddColleague(this);
        snakeBody.Activate();
    }
    public void PlayHitEffect(GameObject enemy,GameObject saw)
    {
        base.PlayHitEffect(enemy);
        BeaverHitEffectObjectPool.instance.PlayEffect(saw.transform.position, enemy.transform.position);
    }

    void Update()
    {

        active = snakeBody.activated;
        if(active != prevActive)
            saw.SetActive(active);
        prevActive = active;

        switch (snakeBody.dir)
        {
            case SnakeHead.Direction.down:
            case SnakeHead.Direction.up:
                saw.transform.rotation = Quaternion.identity;
                break;
            case SnakeHead.Direction.right:
            case SnakeHead.Direction.left:
                saw.transform.rotation = Quaternion.Euler(0,0,90);
                break;
            default:
                break;
        }

    }
    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "비버 기계공";
        bodyDescription = " <b>-[수력 발전 전기 톱날]- \n\n강의 흐름을 동력으로 회전하는 톱날을 생성해 피해를 줍니다.</b>";
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

    public override void LevelUp()
    {
        level++;
        switch(level)
        {
            case 1:
                damageCoefficient = 5;
                bonusDamage = 1;
                shoottime.baseValue = 0.2f;

                Activate();
                SetBodyInfo("공격 범위가 증가합니다.", "1.5타일", "", "");
                break;
            case 2:
                saw.transform.localScale = new Vector3(1.5f, 1.5f);
                saw1.transform.localPosition = new Vector3(1.8f, 0, 0);
                saw2.transform.localPosition = new Vector3(-1.8f, 0, 0);
                SetBodyInfo("공격력이 증가합니다.", "", Math.Round(2 + GameInfo.Instance.damageUnit / 10,2), "");
                break;
            case 3:
                bonusDamage = 2;
                damageCoefficient = 10;
                SetBodyInfo("공격 속도가 증가합니다.", "", "", "6/s");
                break;
            case 4:
                shoottime.baseValue = 1f / 6f;
                SetBodyInfo("공격력과 공격 범위가 증가합니다.", "2타일", Math.Round(2 + GameInfo.Instance.damageUnit / 100 * 15, 2), "");
                break;
            case 5:
                bonusDamage = 3;
                damageCoefficient = 15;
                saw1.transform.localPosition = new Vector3(1.6f, 0, 0);
                saw2.transform.localPosition = new Vector3(-1.6f, 0, 0);
                saw.transform.localScale = new Vector3(2f, 2f);
                SetBodyInfo("공격 범위와 공격속도가 증가합니다.", "2.5 타일", "", "7/s");
                break;
            case 6:
                shoottime.baseValue = 1f / 7f;
                saw1.transform.localPosition = new Vector3(1.4f, 0, 0);
                saw2.transform.localPosition = new Vector3(-1.4f, 0, 0);
                saw.transform.localScale = new Vector3(2.5f, 2.5f);
                SetBodyInfo("공격 범위가 무지막지하게 증가합니다.", "4 타일", "", "");
                break;
            case 7:
                saw1.transform.localPosition = new Vector3(1.2f, 0, 0);
                saw2.transform.localPosition = new Vector3(-1.2f, 0, 0);
                saw.transform.localScale = new Vector3(4f, 4f);
                break;
        }
        UpdateDamageInfo();
    }

    public override void UpdateDamageInfo()
    {
            saw1.damage = saw2.damage = damage;
    }
}
