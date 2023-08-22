using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinting : PassiveItem
{

    public float amount;

    private void Awake()
    {
        SetItemInfo("<b>-[���� �����ϴ� �ӵ�]-\n\n�̵��ӵ��� ���ݼӵ��� ����մϴ�");
        maxlevel = 5;
       
    }
    private void Start()
    {
    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:
                activated = true;
                StartCoroutine(SetValue());
                amount = 1.1f;
                itemDescription = "�̵��ӵ��� ���ݼӵ��� ����մϴ�.";
                break;
            case 2:
                amount = 1.15f;
                itemDescription = "�̵��ӵ��� ���ݼӵ��� ���� ����մϴ�.";
                break;
            case 3:
                amount = 1.2f;
                itemDescription = "�̵��ӵ��� ���ݼӵ��� ������ ����մϴ�.";
                break;
            case 4:
                amount = 1.25f;
                itemDescription = "�̵��ӵ��� ���ݼӵ��� �ſ� ����մϴ�.";
                break;
            case 5:
                amount = 1.3f;
                break;

        }




    }

    WaitForSeconds wfs;
    public IEnumerator SetValue()
    {
        wfs = new WaitForSeconds(0.2f);

        while(true)
        {
            SnakeHead.instance.speedMultiplier = amount;
            var list = PlayerInventory.instance.currentColleagues;
            foreach (var c in list)
            {
                c.cooltimeMultiplier = amount;
            }

            yield return wfs;
        }
    }



    public override void SetItemInfo(string discription, params object[] args)
    {
        itemName = "���ֺ���";
        itemDescription = discription;
    }
}
