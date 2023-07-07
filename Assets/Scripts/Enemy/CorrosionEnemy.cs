using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorreosionEnemy : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        time += Time.deltaTime;

        if (time >= 1f)
        {
            time = 0;
            Instantiate(SelfRelatedObj, gameObject.transform.position, Quaternion.identity);
        }
    }
}
