using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardEnemy : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        time += Time.deltaTime;
        if (Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(Player.transform.position.x, Player.transform.position.y)) <= 30)
            if (time >= 1f)
            {
                time = 0;
                Instantiate(SelfRelatedObj, transform.position, Quaternion.identity);
            }
    }
}
