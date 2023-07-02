using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawer : BodyClass
{
    bool active;
    bool prevActive;
    public GameObject saw;
    public float distance;
    
    private void Awake()
    {
        snakeBody = GetComponent<SnakeBody>();
        
    }
    
    void Update()
    {
        active = snakeBody.activated;
        if(active != prevActive)
            saw.SetActive(active);
        prevActive = active;

        switch (snakeBody.dir)
        {
            case SnakeHead.Direction.down:
            case SnakeHead.Direction.up:
                saw.transform.rotation = Quaternion.identity;
                break;
            case SnakeHead.Direction.right:
            case SnakeHead.Direction.left:
                saw.transform.rotation = Quaternion.Euler(0,0,90);
                break;
            default:
                break;
        }

    }
    public override void SetBodyInfo(params object[] args)
    {
        bodyName = "비버 기계공";
        bodyDescription = " <b>-[수력 발전 전기 톱날]-\n\n강의 흐름을 동력으로 회전하는 톱날을 생성해 피해를 줍니다.</b>\n\n<i>자신의 위와 아래에 ‘톱날’을 생성\n‘톱날’은 기계공에게 고정</i>";
    }
    public override void LevelUp()
    {
        level++;
        switch(level)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
        }
    }
}
