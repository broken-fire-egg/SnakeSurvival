using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleMineObjectPool : ObjectPooling<MoleMine>
{

    public static MoleMineObjectPool instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void Deploy(Vector3 pos)
    {
        var newMine = GetRestingPoolObject();

        if (newMine == null)
        {
            newMine = poolObjects[0];
            newMine.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            newMine.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        newMine.SetPositionAndActive(pos);
        newMine.component.SetSpriteRendererActive(true);
    }


    public void UpdateMineInfo(float damage, float range, float detectrange, BodyClass from)
    {
        foreach (var po in poolObjects)
        {
            po.component.UpdateInfo(damage, range, detectrange, from);
        }
    }
}
