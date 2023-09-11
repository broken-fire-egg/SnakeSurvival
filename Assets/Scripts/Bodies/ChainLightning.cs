using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightning : BodyClass
{
    public GameObject enemies;
    public List<GameObject> AttackList;
    public int maxchaincount;
    float detectdistance;
    int chaincount;
    LineRenderer lineRenderer;
    float Effect;
    int animationStep;
    float linetexturecounter;
    public Texture[] textures;
    Transform attackEffect;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        animationStep = 0;
        linetexturecounter = 0;
        attackEffect = transform.GetChild(0);
    }



    protected override void Start()
    {
        base.Start();
        SetBodyInfo("<b>-[���� ���]-\n\n ������ ���̵Ǵ� ������ �߻��մϴ�</b>", "8Ÿ��", Math.Round(15 + GameInfo.Instance.damageUnit / 100 * 75, 2), "0.2/s");
    }

    public override void PlayHitEffect(GameObject enemy)
    {
        base.PlayHitEffect(enemy);
        LightningChainHitEffectObjectPool.instance.PlayEffect(enemy.transform.position);
    }

    void SetAttackList()
    {
        chaincount = maxchaincount;
        AttackList = new List<GameObject>();
        GameObject newgo = FindNearestEnemy(gameObject);
        AttackList.Add(newgo);
        while(chaincount > 0)
        {
            chaincount--;
            if (newgo != null)
                newgo = FindNearestEnemy(newgo);
            if (newgo != null)
                AttackList.Add(newgo);
            else
                break;
        }
    }
    private void Update()
    {
        if (!snakeBody.activated)
            return;
        cooltime -= Time.deltaTime * cooltimeMultiplier;

        if (cooltime < 0)
        {
            
            Shoot();
        }

        linetexturecounter += Time.deltaTime;

        if(linetexturecounter >= 1f / GameInfo.Instance.fps)
        {
            animationStep++;

            animationStep %= textures.Length;

            lineRenderer.material.SetTexture("_MainTex", textures[animationStep]);

            linetexturecounter = 0f;
        }



        if (Effect > 0)
            Effect -= 0.08f;
        else
            Effect = 0;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.widthMultiplier = Effect;
    }
    void Shoot()
    {
        SetAttackList();
        if (AttackList.Count == 0)
            return;
        cooltime = shoottime;
        lineRenderer.positionCount = AttackList.Count + 1;
        animationStep = 0;
        Vector3[] poslist = new Vector3[AttackList.Count + 1];
        attackEffect.gameObject.SetActive(true);
        foreach (GameObject go in AttackList)
        {
            var target = go.GetComponent<Enemy>();
            target.Hit(damage);
            //DamageTextObjectPool.instance.SpawnText(target.transform.position, damage);
            PlayHitEffect(go);
        }

        poslist[0] = transform.position;
        for (int i=1;i< poslist.Length; i++)
        {
            poslist[i] = AttackList[i-1].transform.position;
        }
        lineRenderer.SetPositions(poslist);
        Effect = 1f;
    }


    GameObject FindNearestEnemy(GameObject from)
    {
        float nearestEnemyDistance = detectdistance;

        if (chaincount == maxchaincount)
            nearestEnemyDistance = 4f;

        float tmp;
        GameObject res = null;
        for (int i = 0; i < enemies.transform.childCount; i++)
        {
            if(AttackList.Contains(enemies.transform.GetChild(i).gameObject))
                continue;
            
            tmp = Vector3.Distance(enemies.transform.GetChild(i).transform.position, from.transform.position);
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
                Activate();
                detectdistance = 2;
                shoottime.baseValue = 5f;
                bonusDamage = 25;
                damageCoefficient = 20;
                SetBodyInfo("���ݷ��� �����մϴ�.", "", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 35, 2), "");
                break;
            case 2:
                bonusDamage = 30;
                damageCoefficient = 25;
                SetBodyInfo("���� ���� Ƚ���� 5ȸ�� �����մϴ�.", "", "", "");
                break;
            case 3:
                maxchaincount = 5;
                SetBodyInfo("���ݼӵ��� �����մϴ�.", "", "", "0.25/s");
                break;
            case 4:
                shoottime.baseValue = 4f;
                SetBodyInfo("���� ���� Ƚ���� �����ϰ� ���̵Ǵ� ������ �����մϴ�", "", "", "");
                break;
            case 5:
                maxchaincount = 6;
                detectdistance = 2.5f;
                SetBodyInfo("���ݷ��� �����մϴ�.", "", Math.Round(35 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 6:

                bonusDamage = 35;
                damageCoefficient = 40;
                SetBodyInfo("���� �ӵ��� ���� �����ϰ� ���ݿ� ���� ������ �������� ��� ����ϴ�", "", "", "0.5/s");
                break;
            case 7:
                shoottime.baseValue = 2f;
                //TODO : STUN;
                break;
        }
    }
    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "�ٶ��� ��������";
        bodyDescription = " <b>-[���� ���]-\n\n������ ���̵Ǵ� ������ �߻��մϴ�</b>";
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

    public override void Activate()
    {
        PlayerInventory.instance.AddColleague(this);
        snakeBody.Activate();
    }
    public override void UpdateDamageInfo()
    {

    }
}
