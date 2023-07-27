using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageTextObjectPool : ObjectPooling<TMP_Text>
{
    //TODO : Font Change
    public static DamageTextObjectPool instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void SpawnText(Vector3 pos, float damage, bool isCrit = false)
    {
        var newgo =  GetRestingPoolObject();
        if (newgo != null)
        {
            string damagestr = ((int)damage).ToString();
            newgo.component.text = "";
            if (isCrit)
            {
                newgo.component.text = "<sprite=\"ui_font_number_critical_1\" index=0>";
                foreach (var c in damagestr)
                {
                    newgo.component.text += "<sprite=\"ui_font_number_critical_0\" index=" + c + ">";
                }
            }
            else
            {
                foreach (var c in damagestr)
                {
                    newgo.component.text += "<sprite=\"ui_font_number_3\" index=" + c + ">";
                }
            }
            newgo.SetPositionAndActive(pos + Vector3.up);
        }
    }
}
