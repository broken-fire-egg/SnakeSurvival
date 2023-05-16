using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatWeaponObjectPool : ObjectPooling<GameObject>
{
    public static CatWeaponObjectPool instance;
    public void Start()
    {
        base.Start();
    }
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void SweepAttack(Vector3 pos, SnakeHead.Direction dir)
    {
        var po = GetRestingPoolObject();
        var WeaponObject = po.gameObject;
        var weaponsr = po.spriteRenderer;
        switch (dir)
        {
            case SnakeHead.Direction.right:
                WeaponObject.transform.localPosition = pos;
                WeaponObject.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
                weaponsr.flipX = false;
                weaponsr.flipY = true;
                break;
            case SnakeHead.Direction.down:
                WeaponObject.transform.localPosition = pos;
                WeaponObject.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
                weaponsr.flipX = true;
                weaponsr.flipY = false;
                break;
            case SnakeHead.Direction.left:
                WeaponObject.transform.localPosition = pos;
                WeaponObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                weaponsr.flipX = false;
                weaponsr.flipY = false;
                break;
            case SnakeHead.Direction.up:
                WeaponObject.transform.localPosition = pos;
                WeaponObject.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
                weaponsr.flipX = true;
                weaponsr.flipY = true;
                break;
        }
        po.SetPositionAndActive(pos);
    }
}
