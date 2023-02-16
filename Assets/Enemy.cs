using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        hp--;
        if(hp <= 0)
            Destroy(gameObject);
    }
}
