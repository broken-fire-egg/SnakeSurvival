using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionUICtrl : MonoBehaviour
{

    int num = 60;
    public GameObject[] MenuCtrlGame;
    public GameObject[] MenuCtrlButton;
    public GameObject[] BGMGauge;
    public GameObject[] SDEGauge;
    /*
     * 0 : ����
     * 1 : �׷���
     * 2 : ����
     * 3 : ����
     */

    public void GameButtonCtrl(int num)
    {
        ResetButton(num); 
    }

    public void ResetButton(int num)
    {
        for (int i = 0; i < MenuCtrlButton.Length; i++)
        {
            MenuCtrlButton[i].GetComponent<RectTransform>().sizeDelta = new Vector2(275, 150);
            MenuCtrlButton[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-390, 650 - (i * 200));
            MenuCtrlGame[i].SetActive(false);
        }
        MenuCtrlButton[num].GetComponent<RectTransform>().sizeDelta = new Vector2(325, 150);
        MenuCtrlButton[num].GetComponent<RectTransform>().anchoredPosition = new Vector2(-365, 650 - (num * 200));
        MenuCtrlGame[num].SetActive(true);
    }

    public void Language(bool lang)
    {
        if(lang)        //true�̸� �ѱ���
        {

        }
        else
        {

        }
    }

    public void SkillUseful(bool useful)
    {
        if(useful)      //ȭ�� ������ġ
        {

        }
        else
        {

        }
    }

    public void CharacterQuality(int i)
    {
        switch (i)
        {
            case 1:             //��

                break;
            case 2:             //��

                break;
            case 3:             //��

                break;

            default:
                break;
        }
    }

    public void BackgroundQuality(int i)
    {
        switch (i)
        {
            case 1:             //��

                break;
            case 2:             //��

                break;
            case 3:             //��

                break;

            default:
                break;
        }
    }
    public void BgmCtrl(bool check)
    {
        if (check)          //+
        {
            num += 20;
        }
        else                //-
        {
            num -= 20;
        }

        GaugeCtrl(BGMGauge);
    }

    public void EffmCtrl(bool check)
    {
        if (check)          //+
        {
            num += 20;
        }
        else                //-
        {
            num -= 20;
        }

        GaugeCtrl(SDEGauge);
    }
    
    public void GaugeCtrl(GameObject[] Gauge)
    {
        for (int i = 0; i < Gauge.Length; i++)
            Gauge[i].SetActive(false);

        for (int i = 0; i < num / 20; i++)
            Gauge[i].SetActive(true);

    }
}
