using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameInfo : SingletonParent<GameInfo>
{
    [HideInInspector]
    public float maxHP;
    [HideInInspector]
    public float damageUnit;
    public int fps;
    private void Start()
    {
        maxHP = 100;
        damageUnit = 1;
        fps = Application.targetFrameRate = 30;
    }
}
