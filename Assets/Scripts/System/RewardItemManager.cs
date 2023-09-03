using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardItemManager : SingletonParent<RewardItemManager>
{
    public void PickRandomReward()
    {
        var luckynumber = Random.Range(0, 10000);
        int stackedNumber = 0;




        if (luckynumber < stackedNumber)
        {

        }
    }
}
