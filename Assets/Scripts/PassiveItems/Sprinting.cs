using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinting : PassiveItem
{

    public float amount;

    private void Awake()
    {
        SetItemInfo("<b>-[제일 좋아하는 속도]-\n\n이동속도와 공격속도가 상승합니다");
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
                itemDescription = "이동속도와 공격속도가 상승합니다.";
                break;
            case 2:
                amount = 1.15f;
                itemDescription = "이동속도와 공격속도가 더욱 상승합니다.";
                break;
            case 3:
                amount = 1.2f;
                itemDescription = "이동속도와 공격속도가 더더욱 상승합니다.";
                break;
            case 4:
                amount = 1.25f;
                itemDescription = "이동속도와 공격속도가 매우 상승합니다.";
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
        itemName = "질주본능";
        itemDescription = discription;
    }
}
