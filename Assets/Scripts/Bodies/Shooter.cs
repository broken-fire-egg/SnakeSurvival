using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : BodyClass
{
    public GameObject enemies;
    public float power;
    private void Awake()
    {
        snakeBody = GetComponent<SnakeBody>();
    }
    private void Update()
    {
        if (!snakeBody.activated)
            return;
       cooltime -= Time.deltaTime;

        if (cooltime < 0)
            Shoot();

    }
    void Shoot()
    {

        var nearestEnemy = FindNearestEnemy();
        if (nearestEnemy)
        {
            cooltime = shoottime;
            var newbullet = Instantiate(bulletpref);
            newbullet.transform.position = transform.position;
            newbullet.GetComponent<Rigidbody2D>().AddForce((nearestEnemy.transform.position - transform.position).normalized * power);


        }

    }

    GameObject FindNearestEnemy()
    {
        float nearestEnemyDistance = 99999999f;
        
        float tmp;
        GameObject res = null;
        for(int i = 0;i< enemies.transform.childCount;i++)
        {
            tmp = Vector3.Distance(enemies.transform.GetChild(i).transform.position, transform.position);
            if (tmp < nearestEnemyDistance)
            {
                nearestEnemyDistance = tmp;
                res = enemies.transform.GetChild(i).gameObject;
            }
        }
        return res;
    }
    public override void LevelUp()
    {
    }
    public override void SetBodyInfo()
    {

    }
}
