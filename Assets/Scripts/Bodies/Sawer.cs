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
        bodyName = "��� ����";
        bodyDescription = " <b>-[���� ���� ���� �鳯]-\n\n���� �帧�� �������� ȸ���ϴ� �鳯�� ������ ���ظ� �ݴϴ�.</b>\n\n<i>�ڽ��� ���� �Ʒ��� ���鳯���� ����\n���鳯���� �������� ����</i>";
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
