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
        SetBodyInfo("", "3Ÿ��", Math.Round(20 + GameInfo.Instance.damageUnit / 100 * 30, 2), "0.25/s");
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
                SetBodyInfo("���� ������ �����մϴ�.", "4Ÿ��", "", "");
                break;
            case 2:
                mineSize = 2f;
                SetBodyInfo("���ݷ��� �����մϴ�.", "", Math.Round(25 + GameInfo.Instance.damageUnit /100 * 35, 2), "");
                break;
            case 3:
                bonusDamage = 25;
                damageCoefficient = 25;
                SetBodyInfo("�ѹ��� 2���� ���ڸ� ��ġ�մϴ�.", "", "", "");
                break;
            case 4:
                extraMine = 1;
                SetBodyInfo("���ݷ°� ���� ������ �����մϴ�.", "5Ÿ��", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 5:

                bonusDamage = 30;
                damageCoefficient = 30;
                mineSize = 2.5f;
                SetBodyInfo("�߰��� 1���� ���ڸ� �� ��ġ�մϴ�", "", "", "");
                break;
            case 6:
                extraMine = 2;
                SetBodyInfo("�߰��� 1���� ���ڸ� �� ��ġ�ϰ� ������ Ž�� �ݰ��� �����մϴ�", "", "", "");
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
        bodyName = "�δ��� ���ĺ�";
        bodyDescription = " <b>-[�δ����� ���� ����]-\n\n�ֱ������� ���ڸ� ��ġ�Ͽ� ������ ������ ���ظ� �ݴϴ�.</b>";
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
