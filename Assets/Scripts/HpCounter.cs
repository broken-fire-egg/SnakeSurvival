using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpCounter : MonoBehaviour
{
    public Transform maxhpT;
    public Transform hpT;

    public enum CountTarget { enemy, body, head }
    public CountTarget countTarget;
    Enemy enemy;
    SnakeBody body;
    SnakeHead head;
    float ratio { get {
            switch (countTarget)
            {
                case CountTarget.enemy:
                    return enemy.hp / enemy.maxhp;
                case CountTarget.body:
                    return body.HP / body.maxHP; 
                case CountTarget.head:
                    return head.HP / head.maxHP;
                default:
                    return 0;
            }
        }
    }

    private void Start()
    {
        switch(countTarget)
        {
            case CountTarget.enemy:
                enemy = transform.parent.GetComponent<Enemy>();
                break;
            case CountTarget.body:
                body = transform.parent.GetComponent<SnakeBody>();
                break;
            case CountTarget.head:
                head = transform.parent.GetComponent<SnakeHead>();
                break;
        }
    }
    private void Update()
    {
        if(ratio <= 0)
            maxhpT.localScale = Vector3.zero;
        else
            maxhpT.localScale = new Vector3(1.5f,0.2f,0);
        
        hpT.localScale = new Vector3(ratio, 1, 1);
    }
}
