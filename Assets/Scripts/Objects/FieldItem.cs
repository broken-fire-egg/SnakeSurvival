using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{

    public enum ItemType { healpotion, revivepotion, portal, chest, magnet, bomb, smallEXP, EXP, bigEXP}
    ItemType type;




    bool touched;
    public float speed;


    public float range;
    private void Update()
    {
        if (touched)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, SnakeHead.instance.transform.position, step);
        }
        if (Vector3.Distance(transform.position, SnakeHead.instance.transform.position) < range)
            touched = true;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            touched = false;
            ActiveItemEffect();
            gameObject.SetActive(false);
        }

    }

    public void SetType(ItemType type)
    {
        this.type = type;
        //TODO : img change
    }

    void ActiveItemEffect()
    {
        switch (type)
        {
            case ItemType.healpotion:

                foreach(var colleague in PlayerInventory.instance.currentColleagues)
                {
                    colleague.Hit(-colleague.snakeBody.maxHP / 5);
                    SnakeHead.instance.Hit(SnakeHead.instance.maxHP / 5);
                }

                break;
            case ItemType.revivepotion:
                var deadpool = new List<BodyClass>();

                foreach (var colleague in PlayerInventory.instance.currentColleagues)
                {
                    if(!colleague.snakeBody.activated)
                        deadpool.Add(colleague);
                }
                if (deadpool.Count > 0)
                {
                    var revivecoll = deadpool[Random.Range(0, deadpool.Count)];
                    revivecoll.snakeBody.Revive(revivecoll.snakeBody.maxHP / 5);
                }
                break;
            case ItemType.portal:

                break;
            case ItemType.chest:

                break;
            case ItemType.magnet:

                break;
            case ItemType.bomb:
                RaycastHit2D[] res = null;
                Physics2D.CircleCast(SnakeHead.instance.transform.position, 5f, Vector2.zero,new ContactFilter2D(), res);

                foreach(var enemy in res)
                {
                    enemy.transform.GetComponent<Enemy>().Hit(GameInfo.Instance.damageUnit * 5);
                }
                break;
            case ItemType.EXP:

                break;
        }


    }
}