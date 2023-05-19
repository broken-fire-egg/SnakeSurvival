using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CatWeaponObjectPool : ObjectPooling<CapsuleCollider2D>
{
    public static CatWeaponObjectPool instance;
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
                
                WeaponObject.transform.DOLocalMoveX(WeaponObject.transform.position.x + 2, 0.5f).SetEase(Ease.OutQuad);
                break;
            case SnakeHead.Direction.down:
                WeaponObject.transform.localPosition = pos;
                WeaponObject.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
                weaponsr.flipX = true;
                weaponsr.flipY = false;
                WeaponObject.transform.DOLocalMoveY(WeaponObject.transform.position.y - 2, 0.5f).SetEase(Ease.OutQuad);
                break;
            case SnakeHead.Direction.left:
                WeaponObject.transform.localPosition = pos;
                WeaponObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                weaponsr.flipX = false;
                weaponsr.flipY = false;
                WeaponObject.transform.DOLocalMoveX(WeaponObject.transform.position.x - 2, 0.5f).SetEase(Ease.OutQuad);
                break;
            case SnakeHead.Direction.up:
                WeaponObject.transform.localPosition = pos;
                WeaponObject.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
                weaponsr.flipX = true;
                weaponsr.flipY = true;
                WeaponObject.transform.DOLocalMoveY(WeaponObject.transform.position.y + 2, 0.5f).SetEase(Ease.OutQuad);
                break;
        }
        po.SetPositionAndActive(pos);
    }
}
