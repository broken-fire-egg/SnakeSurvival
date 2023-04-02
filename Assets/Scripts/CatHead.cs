using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class CatHead : SnakeHead
{
    public Transform handPivot;
    public List<Vector3> offsets; //0right, 1down, 2left, 3up
    Transform hand;
    SpriteRenderer handsr;
    protected override void Start()
    {
        Debug.Log(handPivot.GetChild(0));
        hand = handPivot.GetChild(0);
        handsr = hand.GetComponent<SpriteRenderer>();
        sr = GetComponent<SpriteRenderer>();
        base.Init();
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void ChangeAttackDirection(Direction dir)
    {
        switch (dir)
        {
            case Direction.right:
                hand.rotation = Quaternion.identity;
                hand.localPosition = offsets[0];
                handsr.flipX = true;
                handsr.flipY = true;
                sr.flipX = true;
                handsr.sortingOrder = 0;
                break;
            case Direction.down:
                hand.rotation = Quaternion.Euler(0, 0, 90);
                hand.localPosition = offsets[1];
                handsr.flipY = false;
                handsr.flipX = false;
                sr.flipX = false;
                handsr.sortingOrder = 3;
                break;
            case Direction.left:
                hand.rotation = Quaternion.identity;
                hand.localPosition = offsets[2];
                handsr.flipY = false;
                handsr.flipX = false;
                sr.flipX = false;
                handsr.sortingOrder = 0;
                break;
            case Direction.up:
                hand.rotation = Quaternion.Euler(0, 0, -90);
                hand.localPosition = offsets[3];
                handsr.flipY = false;
                handsr.flipX = false;
                sr.flipX = false;
                handsr.sortingOrder = 0;
                break;
        }
    }
}