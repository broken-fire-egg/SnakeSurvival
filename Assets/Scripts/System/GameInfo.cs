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
    public float criticalChance;
    public Multiplier criticalMultiplier;

    public MultipleMultiplierValue damageMultiply;
    public MultipleMultiplierValue damageReduce;


    public int fps;
    public int map;
    private void Start()
    {
        maxHP = 100;

        criticalMultiplier = new Multiplier(1.5f);

        damageMultiply = new MultipleMultiplierValue(1f);
        criticalChance = 10;
        inventory = GetComponent<PlayerInventory>();
        damageReduce = new MultipleMultiplierValue(1f);
        Invoke("ChangeFPS", 1f);
    }
    void ChangeFPS()
    {
        fps = Application.targetFrameRate = 30;
    }
    private void Update()
    {
    }
}
