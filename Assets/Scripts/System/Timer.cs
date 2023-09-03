using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Timer : MonoBehaviour
{
    TMPro.TMP_Text text;
    float flowedTime;
    private void Start()
    {
        text = GetComponent<TMPro.TMP_Text>();
        flowedTime = 0f;


    }

    private void Update()
    {
        flowedTime += Time.deltaTime;
        var value = (int)flowedTime;

        string txt = string.Format("{0:00}{1:00}", value / 60, value % 60);
        var sb = new StringBuilder().AppendFormat("<sprite={0}><sprite={1}> : <sprite={2}><sprite={3}>", txt[0], txt[1], txt[2], txt[3]);

        text.text = sb.ToString();
    }



}
