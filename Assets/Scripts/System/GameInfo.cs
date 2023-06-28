using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameInfo : SingletonParent<GameInfo>
{
    public SnakeBody[] Colleague;

    public Item[] Items;




    //인게임 정보 및 캐릭터 정보
    [HideInInspector]
    public float maxHP;
    [HideInInspector]
    public float damageUnit;
    public int fps;
    private void Start()
    {
        maxHP = 100;
        damageUnit = 1;
        
        Invoke("ChangeFPS", 1f);
    }
    void ChangeFPS()
    {
        fps = Application.targetFrameRate = 30;
    }
}
