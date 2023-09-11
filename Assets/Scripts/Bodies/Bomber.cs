using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bomber : BodyClass
{


    public float mineSize;
    float detectrange;
    public int extraMine;
    public override void Activate()
    {
        PlayerInventory.instance.AddColleague(this);
        snakeBody.Activate();
    }
    private void Awake()
    {
        snakeBody = GetComponent<SnakeBody>();
    }
    protected override void Start()
    {
        base.Start();
        SetBodyInfo("", "3타일", Math.Round(20 + GameInfo.Instance.damageUnit / 100 * 30, 2), "0.25/s");
    }
    // Update is called once per frame
    void Update()
    {
        if (!snakeBody.activated)
            return;
        cooltime -= Time.deltaTime * cooltimeMultiplier;

        if (cooltime < 0)
            PlayDeployAnimation();
    }

    public void PlayDeployAnimation()
    {
        cooltime = shoottime;
        snakeBody.animator.Play("Attack");
    }

    private void Deploy(int n)
    {
        if(extraMine >= n)
            MoleMineObjectPool.instance.Deploy(transform.position + (new Vector3(Random.Range(0, 1f), Random.Range(0, 1f))).normalized);
    }
    private void Deploy()
    {
        MoleMineObjectPool.instance.Deploy(transform.position + (new Vector3(Random.Range(0,1f),Random.Range(0,1f))).normalized);
        //Instantiate(bulletpref, transform.position, transform.rotation);
    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                Activate();
                detectrange = 1;
                mineSize = 1.5f;
                bonusDamage = 20;
                damageCoefficient = 20;
                shoottime.baseValue = 4;
                extraMine = 0;
                SetBodyInfo("공격 범위가 증가합니다.", "4타일", "", "");
                break;
            case 2:
                mineSize = 2f;
                SetBodyInfo("공격력이 증가합니다.", "", Math.Round(25 + GameInfo.Instance.damageUnit /100 * 35, 2), "");
                break;
            case 3:
                bonusDamage = 25;
                damageCoefficient = 25;
                SetBodyInfo("한번에 2개의 지뢰를 설치합니다.", "", "", "");
                break;
            case 4:
                extraMine = 1;
                SetBodyInfo("공격력과 공격 범위가 증가합니다.", "5타일", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 5:

                bonusDamage = 30;
                damageCoefficient = 30;
                mineSize = 2.5f;
                SetBodyInfo("추가로 1개의 지뢰를 더 설치합니다", "", "", "");
                break;
            case 6:
                extraMine = 2;
                SetBodyInfo("추가로 1개의 지뢰를 더 설치하고 지뢰의 탐지 반경이 증가합니다", "", "", "");
                break;
            case 7:
                detectrange = 2;
                extraMine = 3;
                break;
        }
        UpdateDamageInfo();
    }
    public override void UpdateDamageInfo()
    {
        MoleMineObjectPool.instance.UpdateMineInfo(damage, mineSize, detectrange, this);
    }
    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "두더지 폭파병";
        bodyDescription = " <b>-[두더지식 땅굴 지뢰]-\n\n주기적으로 지뢰를 설치하여 접촉한 적에게 피해를 줍니다.</b>";
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
