using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King_God_Slime : Enemy
{
    CircleCollider2D AttackArea;
    BoxCollider2D box;
    bool Check = false;
    // Start is called before the first frame update
    protected override void Start()
    {
        AttackArea = GetComponent<CircleCollider2D>();
        box = GetComponent<BoxCollider2D>();
        AttackArea.enabled = false;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        time += Time.deltaTime;
        base.Update();

        if (time >= 5.0f && !Check)
        {
            Check = !Check;
            Invoke("Stamp", 3.5f);
            box.enabled = false;
            MoveBool = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void Stamp()
    {
        //transform.position = new Vector2(FinalNodeList[FinalNodeList.Count - 3].x, FinalNodeList[FinalNodeList.Count - 3].y);
        GetComponent<SpriteRenderer>().enabled = true;
        AttackArea.enabled = true;
        Invoke(() => {
            AttackArea.enabled = false;
            Check = !Check;
            MoveBool = true;
        }, 0.5f);
        box.enabled = true;
        time = 0f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (Check)
            col.GetComponent<SnakeHead>().HP -= 20 + Attack;
        else
            col.GetComponent<SnakeHead>().HP -= Attack;
    }
    private void Invoke(System.Action action, float delay)
    {
        StartCoroutine(InvokeCoroutine(action, delay));
    }

    private System.Collections.IEnumerator InvokeCoroutine(System.Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action.Invoke();
    }
}
