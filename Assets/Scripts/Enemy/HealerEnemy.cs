using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealerEnemy : Enemy
{
    List<Tuple<float, GameObject>> list = new List<Tuple<float, GameObject>>();
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Player = null;
    }
    protected override void Update()
    {
        base.Update();
        List<Tuple<float, GameObject>> list = new List<Tuple<float, GameObject>>();
        for (int i = 0; i < gameObject.transform.parent.transform.childCount; i++)
            list.Add(new Tuple<float, GameObject>(Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(gameObject.transform.parent.GetChild(i).transform.position.x, gameObject.transform.parent.GetChild(i).transform.position.x)), gameObject.transform.parent.transform.GetChild(i).gameObject));
        list.Sort();
        //if (Player == null)
          //  FindMob(list);
    }

    void FindMob(List<Tuple<float, GameObject>> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Item2.GetComponent<Enemy>().hp < 8)
                Player = list[i].Item2;
        }
    }
}
