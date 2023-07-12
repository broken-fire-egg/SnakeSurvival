using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightning : BodyClass
{
    public GameObject enemies;
    List<GameObject> AttackList;
    public int maxchaincount;
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
            if (newgo != null)
                newgo = FindNearestEnemy(newgo);
            if (newgo != null)
                AttackList.Add(newgo);
            else
                break;
            chaincount--;
        }
    }
    private void Update()
    {
        if (!snakeBody.activated)
            return;
        cooltime -= Time.deltaTime;

        if (cooltime < 0)
        {
            cooltime = shoottime;
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
        lineRenderer.positionCount = AttackList.Count + 1;
        animationStep = 0;
        Vector3[] poslist = new Vector3[AttackList.Count + 1];
        attackEffect.gameObject.SetActive(true);
        foreach (GameObject go in AttackList)
        {
            var target = go.GetComponent<Enemy>();
            target.Hit(damage);
            DamageTextObjectPool.instance.SpawnText(target.transform.position, damage);
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
        float nearestEnemyDistance = 15f;

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
                snakeBody.Activate();
                SetBodyInfo("���ݷ��� �����մϴ�.", "", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 35, 2), "");
                break;
            case 2:
                SetBodyInfo("���� ���� Ƚ���� �����մϴ�.", "", "", "");
                break;
            case 3:
                SetBodyInfo("���ݼӵ��� �����մϴ�.", "", "", "0.25/s");
                break;
            case 4:
                SetBodyInfo("���� ���� Ƚ���� �����ϰ� ���̵Ǵ� ������ �����մϴ�", "", "", "");
                break;
            case 5:
                SetBodyInfo("���ݷ��� �����մϴ�.", "", Math.Round(35 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 6:
                SetBodyInfo("���� �ӵ��� ���� �����ϰ� ���ݿ� ���� ������ �������� ��� ����ϴ�", "", "", "0.5/s");
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
}
