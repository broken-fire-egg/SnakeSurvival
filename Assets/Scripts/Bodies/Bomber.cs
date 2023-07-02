using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : BodyClass
{
    private void Awake()
    {
        snakeBody = GetComponent<SnakeBody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!snakeBody.activated)
            return;
        cooltime -= Time.deltaTime;

        if (cooltime < 0)
            Deploy();
    }

    private void Deploy()
    {
        cooltime = shoottime;
        Instantiate(bulletpref, transform.position, transform.rotation);
    }
    public override void LevelUp()
    {
        level++;
    }
    public override void SetBodyInfo(params object[] args)
    {

    }
}
