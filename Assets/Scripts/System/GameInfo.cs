using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameInfo : SingletonParent<GameInfo>
{
    public PlayerInventory inventory;




    //인게임 정보 및 캐릭터 정보
    [HideInInspector]
    public float maxHP;
    
    public float damageUnit;
    public float damageMultiply;
    public float criticalChance;
    public int fps;
    private void Start()
    {
        maxHP = 100;
        damageMultiply = 1;
        criticalChance = 10;
        inventory = GetComponent<PlayerInventory>();
        Invoke("ChangeFPS", 1f);
    }
    void ChangeFPS()
    {
        fps = Application.targetFrameRate = 30;
    }
    private void Update()
    {
        print(Application.targetFrameRate);
    }
}
