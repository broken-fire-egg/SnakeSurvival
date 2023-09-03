using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BeaverHitEffectObjectPool : ObjectPooling<GameObject>
{
    public static BeaverHitEffectObjectPool instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void PlayEffect(Vector3 startpos, Vector3 endpos)
    {
        var po = GetRestingPoolObject();

        Vector3 relativePos = endpos - startpos;
        float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
        


        po.gameObject.transform.rotation = Quaternion.AngleAxis(angle + 180f, Vector3.forward);
        po.SetPositionAndActive(endpos);
    }
}