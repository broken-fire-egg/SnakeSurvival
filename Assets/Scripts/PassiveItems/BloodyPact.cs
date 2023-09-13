using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodyPact : PassiveItem
{

    float chance = 0f;
    float heal = 0f;
    private void Start()
    {
        SetItemInfo("<b>-[피가 부르노니]-\n\n적을 처치 시 일정확률로 체력을 회복합니다");
    }
    public override void LevelUp()
    {
        level++;
        switch (level)
        {
            case 1:

                chance = 5f;
                heal = 2f;
                activated = true;
                ObserverPatternManager.instance.OnEnemyDied += OnEnemyDead;
                SetItemInfo("회복양과 회복 확률이 증가합니다");
                break;
            case 2:
                chance = 6f;
                heal = 3f;
                SetItemInfo("회복양과 회복 확률이 더 증가합니다");
                break;
            case 3:
                chance = 7f;
                heal = 4f;
                SetItemInfo("회복양과 회복 확률이 더욱 증가합니다");
                break;
            case 4:
                chance = 8f;
                heal = 5f;
                SetItemInfo("회복 확률이 크게 증가합니다");
                break;
            case 5:
                chance = 10f;
                heal = 5f;
                break;
        }
    }


    public void OnEnemyDead()
    {
        if (chance > Random.Range(0f, 100f))
        {
            if (SnakeHead.instance.HP < SnakeHead.instance.maxHP)
            {
                SnakeHead.instance.Hit(-SnakeHead.instance.maxHP / 100 * heal);
            }
            else
            {
                foreach(var body in PlayerInventory.instance.currentColleagues)
                {
                    if (body.snakeBody.HP == body.snakeBody.maxHP)
                        continue;
                    body.Hit(-body.snakeBody.maxHP / 100 * heal);
                }
            }
        }


    }




    public override void SetItemInfo(string discription, params object[] args)
    {
        itemName = "피의 계약";
        itemDescription = discription;
    }
}
