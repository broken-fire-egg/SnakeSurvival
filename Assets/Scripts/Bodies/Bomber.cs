using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : BodyClass
{
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
        cooltime -= Time.deltaTime;

        if (cooltime < 0)
            Deploy();
    }

    private void Deploy()
    {
        cooltime = shoottime;
        Instantiate(bulletpref, transform.position, transform.rotation);
    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                SetBodyInfo("공격 범위가 증가합니다.", "4타일", "", "");
                break;
            case 2:
                SetBodyInfo("공격력이 증가합니다.", "", Math.Round(25 + GameInfo.Instance.damageUnit /100 * 35, 2), "");
                break;
            case 3:
                SetBodyInfo("한번에 2개의 지뢰를 설치합니다.\n<i><지뢰 설치 후 0.2초 뒤에 한번 더 설치\n1번째 지뢰 설치이후에 공격 속도 계산></i>", "", "", "");
                break;
            case 4:
                SetBodyInfo("공격력과 공격 범위가 증가합니다.", "5타일", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 5:
                SetBodyInfo("추가로 1개의 지뢰를 더 설치합니다\n<i><2번째 지뢰 설치 후 0.2초 뒤에 한번 더 설치\n1번째 지뢰 설치이후에 공격 속도 계산></i>", "", "", "");
                break;
            case 6:
                SetBodyInfo("추가로 1개의 지뢰를 더 설치하고 지뢰의 탐지 반경이 증가합니다\n<i><탐지 범위가 지뢰 중심 4타일 원형 범위로 증가\n3번째 지뢰 설치 후 0.2초 뒤에 한번 더 설치\n1번째 지뢰 설치이후에 공격 속도 계산></i>", "", "", "");
                break;
        }
    }
    public override void SetBodyInfo(string discription, params object[] args)
    {
        bodyName = "두더지 폭파병";
        bodyDescription = " <b>-[두더지식 땅굴 지뢰]-주기적으로 지뢰를 설치하여 접촉한 적에게 피해를 줍니다.</b>\n<i><자신이 있는 위치에 ‘지뢰’를 설치\n‘지뢰’는 설치된 자리에서 부동\n‘지뢰’는 공격 범위 내로 적을 탐지하며 적을 탐지하면 0.5초 후 폭발하여 피해\n적이 없어도 ‘지뢰’는 계속 설치\n‘지뢰’는 맵상에서 최대 20개만 존재 가능\n20개가 넘어가게 설치할 경우 넘어간 ‘지뢰’ 수 만큼 가장 먼저 설치한 ‘지뢰’부터 탐지 유무 없이 폭파></i>";
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
