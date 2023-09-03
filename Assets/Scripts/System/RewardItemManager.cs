using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardItemManager : SingletonParent<RewardItemManager>
{
    int potionWeight;
    int magnetWeight;
    int bombWeight;
    StackValue rebirthPorionWeight;
    StackValue portalWeight;
    StackValue treasureWeight;
    private void Awake()
    {
        potionWeight = 50;
        magnetWeight = 50;
        bombWeight = 100;   
        rebirthPorionWeight = new StackValue(6, 50, 50);
        portalWeight = new StackValue(1, 500, 0);
        treasureWeight = new StackValue(100, 50, 10);
    }




    public void PickRandomReward()
    {
        var luckynumber = Random.Range(0, 10000);
        int stackedNumber = 0;




        if (luckynumber < stackedNumber)
        {

        }
    }
}
