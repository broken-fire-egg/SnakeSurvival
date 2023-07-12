using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainUiCtrl : MonoBehaviour
{
    public GameObject Singleton;
    public GameObject Option;
    public GameObject[] MenuCtrlGame;
    public GameObject[] MenuCtrlButton;
    /*
     * 0 : 게임
     * 1 : 그래픽
     * 2 : 사운드
     * 3 : 계정
     */
    public void a()
    {
        Singleton.GetComponent<test>().i++;
        SceneManager.LoadScene("ValueSettingScene");
    }

    public void OptionButton()
    {
        Option.SetActive(true);
    }

    public void GameButtonCtrl(int num)
    {
        ResetButton(num);
    }

    public void ResetButton(int num)
    {
        for(int i = 0; i < MenuCtrlButton.Length; i++)
        {
            //MenuCtrlGame[i].SetActive(false);
            MenuCtrlButton[i].GetComponent<RectTransform>().sizeDelta = new Vector2(275, 150);
            MenuCtrlButton[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-390, 650 - ( i * 200));
        }
        //MenuCtrlGame[num].SetActive(true);
        MenuCtrlButton[num].GetComponent<RectTransform>().sizeDelta = new Vector2(325, 150);
        MenuCtrlButton[num].GetComponent<RectTransform>().anchoredPosition = new Vector2(-365, 650 - (num * 200));
    }


    public void BgmCtrl(GameObject button)
    {

        if (button.name == "")
        {

        }
        else
        {

        }
        Debug.Log(button.transform.name);
    }

    public void EffmCtrl()
    {

    }
}
