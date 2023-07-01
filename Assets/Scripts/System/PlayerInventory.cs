using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public BodyClass[] bodyClasses;
    public PassiveItem[] items;

    public Image[] currentColleagueImages;
    public Image[] currentItemImages;

    public int currentColleagueCount;
    public int currentItemCount;

    public PassiveItem[] currentItems;
    public BodyClass[] currentColleagues;


    public static PlayerInventory instance;

    private void Awake()
    {
        if(!instance)
            instance = this;
    }


}
