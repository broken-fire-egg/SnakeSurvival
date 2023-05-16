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

    public void PlayEffect(Vector3 pos, Quaternion rot)
    {

    }
}
