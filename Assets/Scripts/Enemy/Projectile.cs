using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Head");
        Vector2 v2 = player.transform.position - transform.position;
        gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, (Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg) - 90);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector2.up * 0.1f * Time.deltaTime * Application.targetFrameRate);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            col.GetComponent<SnakeHead>().HP -= 1;
            Destroy(gameObject);
        }

    }
}
