using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorldCtrlUI : MonoBehaviour
{
    int StageNum = 0;

    List<List<string>> StageInformation = new List<List<string>>();              //{�������, Ŭ��������, ������������}
    public GameObject InformationText;
    public GameObject UnlockGame;
    public GameObject ClearGame;

    public GameObject[] ChangeButton;
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
        StageInformation.Add(new List<string> { "true", "true", "�ƹ�ư 1��������" });
        StageInformation.Add(new List<string> { "true", "false", " 2��������" });
        StageInformation.Add(new List<string> { "false", "false", "��°ư 3��������" });
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
            if (StageInformation.Count - 1 <= StageNum)
                StageNum = StageInformation.Count - 1;
        }
        else
        {
            StageNum--;
            if (0 >= StageNum)
                StageNum = 0;
        }

        if (StageNum >= 1 && StageNum <= StageInformation.Count - 2)
        {
            Debug.Log("!");
            ChangeButton[0].GetComponent<Button>().enabled = true;
            ChangeButton[1].GetComponent<Button>().enabled = true;
        }
        else if (StageNum == 0)
            ChangeButton[0].GetComponent<Button>().enabled = false;

        else if (StageNum == StageInformation.Count - 1)
            ChangeButton[1].GetComponent<Button>().enabled = false;

        StageInfor();
    }


}