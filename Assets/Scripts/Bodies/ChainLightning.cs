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
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();


    }
    protected override void Start()
    {
        base.Start();
        SetBodyInfo("<b>-[람쥐 썬더]- 적에게 전이되는 번개를 발사합니다<b>\n<i><공격 범위 내 적에게 번개를 발사\r\n번개는 공격 대상이 된 적에게 피해를 주고 대상 중심 4타일 원형 범위 내 번개 공격을 받은 대상이 아닌 가까운 적에게 전이 공격\n위 효과를 최대 4번까지 발동(총 적 5명 공격)></i>", "8타일", Math.Round(15 + GameInfo.Instance.damageUnit / 100 * 75, 2), "0.2/s");
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

        Vector3[] poslist = new Vector3[AttackList.Count + 1];

        foreach (GameObject go in AttackList)
        {
            var target = go.GetComponent<Enemy>();
            target.Hit(damage);
            DamageTextObjectPool.instance.SpawnText(target.transform.position, damage);

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

                SetBodyInfo("공격력이 증가합니다.", "", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 35, 2), "");
                break;
            case 2:
                SetBodyInfo("번개 전이 횟수가 증가합니다.", "", "", "");
                break;
            case 3:
                SetBodyInfo("공격속도가 증가합니다.", "", "", "0.25/s");
                break;
            case 4:
                SetBodyInfo("번개 전이 횟수가 증가하고 전이되는 범위가 증가합니다\n<i><대상 중심 5타일 원형 범위\r\n전이 최대 6번까지 발동></i>", "", "", "");
                break;
            case 5:
                SetBodyInfo("공격력이 증가합니다.", "", Math.Round(35 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 6:
                SetBodyInfo("공격 속도가 대폭 감소하고 공격에 맞은 적들의 움직임을 잠시 멈춥니다\n<i><번개에 맞은 적은 0.5초 동안 이동 불가></i>", "", "", "0.5/s");
                break;
        }
    }
    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "다람쥐 번개술사";
        bodyDescription = " <b>-[람쥐 썬더]-\r\n\r\n적에게 전이되는 번개를 발사합니다</b>\n\n<i><공격 범위 내 적에게 번개를 발사\n번개는 공격 대상이 된 적에게 피해를 주고 대상 중심 4타일 원형 범위 내 번개 공격을 받은 대상이 아닌 가까운 적에게 전이 공격\n위 효과를 최대 4번까지 발동(총 적 5명 공격)></i>";
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
