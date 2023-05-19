using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(Player.transform.position.x, Player.transform.position.y)) <= 2)
            Destroy(gameObject);
    }

}
