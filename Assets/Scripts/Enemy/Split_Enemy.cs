using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split_Enemy : Enemy
{
    public GameObject SplitObject;
    public int SplitCount;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();

        if(hp <= 0 && !DeadBool)
        {
            DeadBool = true;
            Split();
        }
    }

    void Split()
    {
        for (int i = 0; i < SplitCount; i++)
        {
            GameObject game = Instantiate(SelfRelatedObj, gameObject.transform.position, Quaternion.identity);
            game.transform.parent = transform.parent;
        }
    }
}
