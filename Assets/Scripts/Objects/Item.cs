using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Item : MonoBehaviour
{
    bool touched;
    public float speed;
    public bool magneted;
    public float range;
    private void Update()
    {
        if(touched)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, SnakeHead.instance.transform.position, step);
        }
        if(Vector3.Distance(transform.position, SnakeHead.instance.transform.position) < range)
            touched = true;
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            touched = false;
            gameObject.SetActive(false);
        }

    }
}
