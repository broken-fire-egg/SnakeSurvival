using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectObjectPool : ObjectPooling<GameObject>
{
    public static HitEffectObjectPool instance;
    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void PlayEffect(Vector3 pos)
    {
        var po = GetRestingPoolObject();
        po.gameObject.transform.rotation = Quaternion.Euler(0,0,Random.Range(0f,360f));
        po.SetPositionAndActive(pos);
    }
}