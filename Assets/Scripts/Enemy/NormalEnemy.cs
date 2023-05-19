using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
        MoveBool = true;
    }

    protected override void Update()
    {
            base.Update();
    }
}
