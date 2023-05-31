using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageTextObjectPool : ObjectPooling<TextMeshProUGUI>
{
    public static DamageTextObjectPool instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void SpawnText(float damage)
    {

    }
}
