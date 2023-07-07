using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealerEnemy : Enemy
{
    List<Tuple<float, GameObject>> list = new List<Tuple<float, GameObject>>();
    Enemy Target;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Player = null;
    }
    protected override void Update()
    {
        base.Update();
        if (Player == null)
            FindMob();
        else
        {
            if (Vector2.Distance(gameObject.transform.position, Player.transform.position) <= 3)
            {
                Target.hp++;
            }
        }
    }

    void FindMob()
    {
        //print(gameObject.transform.parent.transform.name);
        for (int i = 0; i < gameObject.transform.parent.transform.childCount; i++)
        {
            if (gameObject.transform.parent.transform.GetChild(i).gameObject.GetComponent<Enemy>().hp < 8 && gameObject.transform.parent.transform.GetChild(i).gameObject != gameObject)
                list.Add(new Tuple<float, GameObject>(Vector2.Distance(gameObject.transform.position, gameObject.transform.parent.transform.GetChild(i).gameObject.transform.position), gameObject.transform.parent.transform.GetChild(i).gameObject));
        }
        list.Sort((a, b) => a.Item1.CompareTo(b.Item1));
        Player = list[0].Item2;
        Target = Player.GetComponent<Enemy>();
    }
}
