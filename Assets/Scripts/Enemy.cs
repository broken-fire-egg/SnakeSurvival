using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EXPManager;

public class Enemy : MonoBehaviour
{
    public float hp;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
            Destroy(collision.gameObject);
        if (hp <= 0)
        {
            EXPManager.instance.itemOP.GetRestingPoolObject().SetPositionAndActive(transform.position);
            Destroy(gameObject);
        }
    }
}
