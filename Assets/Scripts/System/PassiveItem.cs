using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassiveItem : MonoBehaviour
{
    public string itemName;
    public string itemDescription;
    public Sprite itemSprite;
    public int level;

    abstract public void SetItemInfo();
    abstract public void LevelUp();

}
