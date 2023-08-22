using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameInfo : SingletonParent<GameInfo>
{
    public PlayerInventory inventory;




    //�ΰ��� ���� �� ĳ���� ����
    [HideInInspector]
    public float maxHP;
    
    public float damageUnit;
    public float criticalChance;

    public MultipleMultiplierValue damageMultiply;
    public MultipleMultiplierValue damageReduce;


    public int fps;
    public int map;
    private void Start()
    {
        maxHP = 100;
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
        print(Application.targetFrameRate);
    }
}
