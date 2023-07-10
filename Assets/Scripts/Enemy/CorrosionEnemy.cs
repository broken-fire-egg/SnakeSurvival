using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrosionEnemy : Enemy
{
    public float Duration;
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
            GameObject game = Instantiate(SelfRelatedObj, gameObject.transform.position, Quaternion.identity);
            game.GetComponent<EnemyMucus>().MucusTime = Duration;
        }
    }
}
