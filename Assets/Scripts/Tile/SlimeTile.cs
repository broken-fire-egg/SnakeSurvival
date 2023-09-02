using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeTile : MonoBehaviour
{

    public float slowpoint = 25;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SnakeHead.instance.slowed = slowpoint;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SnakeHead.instance.slowed = 0;
        }
    }
}
