using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCorrosionEnemy : CorrosionEnemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if(hp <= 0 && !DeadBool)
        {
            DeadBool = true;
            for (int i = (int)gameObject.transform.position.x - 1; i < (int)gameObject.transform.position.x + 2; i++)
                for (int j = (int)gameObject.transform.position.y - 1; j < (int)gameObject.transform.position.y + 2; j++)
                    Instantiate(SelfRelatedObj, new Vector2(i, j), Quaternion.identity);
        }
    }
}
