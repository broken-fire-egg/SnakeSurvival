using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorldCtrlUI : MonoBehaviour
{
    int StageNum = 0;

    List<List<string>> StageInformation = new List<List<string>>();              //{언락유무, 클리어유무, 스테이지설명}
    public GameObject InformationText;
    public GameObject UnlockGame;
    public GameObject ClearGame;
    // Start is called before the first frame update
    void Start()
    {
        Input();
        InformationText.GetComponent<TMP_Text>().text = StageInformation[StageNum][2];
        StageInfor();
    }
    // Update is called once per frame
    void Update()
    {

    }

    void Input()
    {
        StageInformation.Add(new List<string> { "true", "true", "아무튼 1스테이지" });
        StageInformation.Add(new List<string> { "true", "false", " 2스테이지" });
        StageInformation.Add(new List<string> { "false", "false", "어째튼 3스테이지" });
    }

    void StageInfor()
    {
        UnlockGame.SetActive(!bool.Parse(StageInformation[StageNum][0]));
        ClearGame.SetActive(bool.Parse(StageInformation[StageNum][1]));
        InformationText.GetComponent<TMP_Text>().text = StageInformation[StageNum][2];
    }
    public void ChangeWorld(bool check)
    {
        if (check)
        {
            StageNum++;
            if (StageInformation.Count <= StageNum)
                StageNum = 0;
        }
        else
        {
            StageNum--;
            if (0 > StageNum)
                StageNum = StageInformation.Count - 1;
        }
        StageInfor();
        Debug.Log(StageInformation[StageNum][0] + " " + StageInformation[StageNum][1] + "" + StageNum);
    }


}