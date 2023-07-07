using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassiveItem : MonoBehaviour
{
    [HideInInspector]
    public string itemName;
    [HideInInspector]
    public string itemDescription;

    public Sprite itemSprite;
    public int level;

    abstract public void SetItemInfo(string discription, params object[] args);
    abstract public void LevelUp();

}
