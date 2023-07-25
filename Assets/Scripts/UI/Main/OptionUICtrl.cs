using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionUICtrl : MonoBehaviour
{

    int num = 60;
    int num2 = 60;
    public GameObject[] MenuCtrlGame;
    public GameObject[] MenuCtrlButton;
    public GameObject[] BGMGauge;
    public GameObject[] SDEGauge;
    /*
     * 0 : 게임
     * 1 : 그래픽
     * 2 : 사운드
     * 3 : 계정
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
        if(lang)        //true이면 한국어
        {

        }
        else
        {

        }
    }

    public void SkillUseful(bool useful)
    {
        if(useful)      //화면 더블터치
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
            case 1:             //저

                break;
            case 2:             //중

                break;
            case 3:             //고

                break;

            default:
                break;
        }
    }

    public void BackgroundQuality(int i)
    {
        switch (i)
        {
            case 1:             //저

                break;
            case 2:             //중

                break;
            case 3:             //고

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
            if (num > 100)
                num = 100;
        }
        else                //-
        {
            num -= 20;
            if (num < 0)
                num = 0;
        }

        GaugeCtrl(BGMGauge, num);
    }

    public void EffmCtrl(bool check)
    {
        if (check)          //+
        {
            num2 += 20;
            if (num2 > 100)
                num2 = 100;
        }
        else                //-
        {
            num2 -= 20;
            if (num2 < 0)
                num2 = 0;
        }

        GaugeCtrl(SDEGauge, num2);
    }
    
    public void GaugeCtrl(GameObject[] Gauge, int a)
    {
        
        for (int i = 0; i < Gauge.Length; i++)
            Gauge[i].SetActive(false);

        for (int i = 0; i < a / 20; i++)
            Gauge[i].SetActive(true);
    }
}
