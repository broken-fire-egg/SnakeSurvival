using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        time += Time.deltaTime;
        base.Update();
        if(time >= 1f)
            EnemyStealth();
    }

    void EnemyStealth()
    {
        time = 0;
        if (gameObject.GetComponent<SpriteRenderer>().enabled)
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

        else
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
