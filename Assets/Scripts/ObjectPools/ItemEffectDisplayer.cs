using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEffectDisplayer : SingletonParent<ItemEffectDisplayer>
{
    public SpriteRenderer[] effectDisplayerSRs;




    private void Update() { 
        transform.position = SnakeHead.instance.transform.position;
    }

    public void EffectDisplay(Sprite spr)
    {
        foreach(var sr in effectDisplayerSRs)
        {
            if (sr.gameObject.activeInHierarchy)
                continue;
            sr.sprite = spr;
            sr.gameObject.SetActive(true);
            break;
        }
    }



}
