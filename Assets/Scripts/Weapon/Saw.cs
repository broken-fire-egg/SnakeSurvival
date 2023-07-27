using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Bullet
{

    
    public float cooltime;
    public float attackedtime;
    public Collider2D coll2D;

    

    

    private void Update()
    {


        CheckAttack();

    }
    public void CheckAttack()
    {
        attackedtime -= Time.deltaTime;
        if (attackedtime > 0)
            return;

        RaycastHit2D[] hits = new RaycastHit2D[7];

        coll2D.Cast(Vector2.zero, hits);

        foreach(var hit in hits)
        {
            if(hit.collider)
            if(hit.collider.CompareTag("Enemy"))
            {
                Hit(hit.collider.transform.GetComponent<Enemy>());
            }
        }
        attackedtime = from.shoottime;
    }


    public override void Start()
    {
        base.Start();
        coll2D = GetComponent<Collider2D>();

        from = GameObject.Find("Sawer").GetComponent<Sawer>();
    }

    protected override void Hit(Enemy target)
    {
        attackedtime = cooltime;
        
        if (Random.Range(0, 100) < GameInfo.Instance.criticalChance + from.bonusCriticalChance)
        {
            target.Hit(damage*2,isCrit:true);
        }
        else
            target.Hit(damage);
        if (from)
        {
                ((Sawer)from).PlayHitEffect(target.gameObject, gameObject);
        }
        gameObject.SetActive(pene);
    }
}
