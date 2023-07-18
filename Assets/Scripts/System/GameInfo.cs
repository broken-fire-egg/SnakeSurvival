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
    public int fps;
    private void Start()
    {
        maxHP = 100;
        inventory = GetComponent<PlayerInventory>();
        Invoke("ChangeFPS", 1f);
    }
    void ChangeFPS()
    {
        fps = Application.targetFrameRate = 30;
    }
}
