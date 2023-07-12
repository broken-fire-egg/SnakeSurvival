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
    List<Transform> clams;
    
    private void Awake()
    {
        center = transform.GetChild(0);
        clams = new List<Transform>();
        clams.Add(center.GetChild(0));
    }
    protected override void Start()
    {
        base.Start();
        SetClamsPosition();
        SetBodyInfo("");
    }
    public void Activate()
    {
        center.gameObject.SetActive(true);
        SetClamsPosition();
        snakeBody.Activate();
    }
    void AddClam()
    {
        clams.Add(Instantiate(center.GetChild(0), center));
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
        var cycle = Vector3.forward * speed;
        center.Rotate(cycle);
        foreach (var clam in clams)
        {
            clam.Rotate(-cycle);
        }
    }

    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                Activate();
                SetBodyInfo("������ 1�� �߰��մϴ�.", "", Math.Round(30 + GameInfo.Instance.damageUnit / 100 * 35, 2), "");
                break;
            case 2:
                AddClam();
                SetBodyInfo("ȸ�� �ӵ��� �����մϴ�.", "", "", "");
                break;
            case 3:
                speed += 12;
                SetBodyInfo("���� ũ��� ���ݷ��� �����մϴ�.", "", "", "0.25/s");
                break;
            case 4:
                SetClamSize(1.5f);
                //radius += 1;
                SetBodyInfo("������ 1�� �� �߰��ϰ� ��ġ�� �Ÿ��� �����մϴ�", "", "", "");
                break;
            case 5:
                AddClam();
                SetBodyInfo("���ݷ°� ȸ�� �ӵ��� �����մϴ�.", "", Math.Round(35 + GameInfo.Instance.damageUnit / 100 * 40, 2), "");
                break;
            case 6:
                speed += 12;
                SetBodyInfo("���� ũ�Ⱑ Ŀ���� ������ 2�� �� �߰��մϴ�.", "", "", "0.5/s");
                break;
            case 7:
                SetClamSize(2f);
                //radius += 1;
                AddClam();
                AddClam();
                break;
        }
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
}
