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

    public List<PassiveItem> currentItems;
    public List<BodyClass> currentColleagues;


    public static PlayerInventory instance;

    private void Awake()
    {
        if(!instance)
            instance = this;
        
    }

    public void AddItem(PassiveItem newItem)
    {
        currentItems.Add(newItem);
    }
    public void AddColleague(BodyClass newCol)
    {
        currentColleagues.Add(newCol);
    }


}
