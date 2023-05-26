using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRange : MonoBehaviour
{
    public bool EnemySpoted { get { return Enemycount >= 1; } }
    int Enemycount;
    private void Start()
    {
        Enemycount = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
            Enemycount++;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            Enemycount--;
    }
}
