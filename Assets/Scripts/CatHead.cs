using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class CatHead : SnakeHead
{
    protected override void Awake()
    {
        base.Awake();
    }
    public List<Vector3> offsets;//0right, 1down, 2left, 3up
    protected override void Start()
    {
        // Debug.Log(handPivot.GetChild(0));
        //hand = handPivot.GetChild(0);
        //attackDT = 4f/3f;
        sr = GetComponent<SpriteRenderer>();
        base.Init();
        attackCT = attackDT;
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void Attack()
    {
        base.Attack();
        int i = 0;
        switch (dir)
        {
            case Direction.right:
                i = 0;
                break;
            case Direction.down:
                i = 1;
                break;
            case Direction.left:
                i = 2;
                break;
            case Direction.up:
                i = 3;
                break;
        }
        CatWeaponObjectPool.instance.SweepAttack(transform.position + offsets[i], dir);
    }
    protected override void ChangeAttackDirection(Direction dir)
    {
        weaponRange.transform.localPosition = offsets[(int)dir];

        //OLD CODE

        //switch (dir)
        //{
        //    case Direction.right:
        //        hand.rotation = Quaternion.identity;
        //        hand.localPosition = offsets[0];
        //        handsr.flipX = true;
        //        handsr.flipY = true;
        //        sr.flipX = true;
        //        handsr.sortingOrder = 0;
        //        break;
        //    case Direction.down:
        //        hand.rotation = Quaternion.Euler(0, 0, 90);
        //        hand.localPosition = offsets[1];
        //        handsr.flipY = false;
        //        handsr.flipX = false;
        //        sr.flipX = false;
        //        handsr.sortingOrder = 3;
        //        break;
        //    case Direction.left:
        //        hand.rotation = Quaternion.identity;
        //        hand.localPosition = offsets[2];
        //        handsr.flipY = false;
        //        handsr.flipX = false;
        //        sr.flipX = false;
        //        handsr.sortingOrder = 0;
        //        break;
        //    case Direction.up:
        //        hand.rotation = Quaternion.Euler(0, 0, -90);
        //        hand.localPosition = offsets[3];
        //        handsr.flipY = false;
        //        handsr.flipX = false;
        //        sr.flipX = false;
        //        handsr.sortingOrder = 0;
        //        break;
        //}

    }
}