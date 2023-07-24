using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        time += Time.deltaTime;
            base.Update();
        
        if (Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(Player.transform.position.x, Player.transform.position.y)) <= 10)
        {
            if (time >= 1f)
            {
                time = 0;
                Instantiate(SelfRelatedObj, transform.position, Quaternion.identity);
            }
            MoveBool = false;
        }
        else
            MoveBool = true;
    }
}
