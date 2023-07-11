using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelUpManager : SingletonParent<LevelUpManager>
{

    //NOTE TODO : 아이템 최대레벨은 각각 다 다름
    //Review : LevelupOption을 interface로 구현하는게 더 나았을것 같다.
    public class LevelUpOption
    {
        public bool Selectable { get {
                if (isItem)
                {
                    if (passiveItem.level >= 7)
                        return false;
                }
                else
                {
                    if (colleague.level >= 7)
                        return false;
                }
                return true;
                        
                        } }
        public bool isItem;
        public PassiveItem passiveItem;
        public BodyClass colleague;
        public LevelUpOption(PassiveItem item)
        {
            passiveItem = item;
            isItem = true;
        }
        public LevelUpOption(BodyClass colleague)
        {
            this.colleague = colleague;
            isItem = false;
        }
    }

    public float exp;
    public float expMax;
    public RectTransform expGage;

    public Image[] optionImages;
    public TMPro.TMP_Text[] optionName;
    public TMPro.TMP_Text[] optionText;



    [Serializable]
    public class OptionArgs
    {
        public TMPro.TMP_Text[] args = new TMPro.TMP_Text[3];
    }


    public OptionArgs[] optionArgs;

    public GameObject LevelupUI;
    List<LevelUpOption> options;
    List<LevelUpOption> selectableOptions;
    private void Start()
    {
        OptionInit();
    }
    void OptionInit()
    {
        options = new List<LevelUpOption>();

        var inven = PlayerInventory.instance;
        
        foreach(var item in inven.items)
        {
            options.Add(new LevelUpOption(item));
        }
        foreach (var colleague in inven.bodyClasses)
        {
            options.Add(new LevelUpOption(colleague));
        }
    }


    public void LevelUp()
    {
        selectableOptions = GetRandomOptions();
        exp -= expMax;

        for (int i = 0; i < 3; i++)
        {

            if(selectableOptions[i].isItem)
            {
                optionImages[i].sprite = selectableOptions[i].passiveItem.itemSprite;
                optionName[i].text = selectableOptions[i].passiveItem.itemName;
                //optionText[i].text += "\n\n";
                optionText[i].text = selectableOptions[i].passiveItem.itemDescription;

                //for(int j=0;j<3;j++)
                    //optionArgs[i].args[j].text = selectableOptions[i].passiveItem;

            }
            else
            {
                optionImages[i].sprite = selectableOptions[i].colleague.bodyIcon;
                optionName[i].text = selectableOptions[i].colleague.bodyName;
                //optionText[i].text += "\n\n";
                optionText[i].text = selectableOptions[i].colleague.levelupDescription;
                //for (int j = 0; j < 3; j++)
                //{
                //    if (selectableOptions[i].colleague.args[j] != "" && selectableOptions[i].colleague.level != 0)
                //        optionArgs[i].args[j].color = Color.green;
                //    else
                //        optionArgs[i].args[j].color = Color.black;
                //    optionArgs[i].args[j].text = selectableOptions[i].colleague.args[j];
                //}
            }

        }
        LevelupUI.SetActive(true);
        SnakeHead.instance.animator.updateMode = AnimatorUpdateMode.Normal;
        Time.timeScale = 0;

    }


    List<LevelUpOption> GetRandomOptions()
    {
        List<LevelUpOption> alreadySelected = new List<LevelUpOption>();
        for(int i = 0; i < 3; i++)
        {
           while(true)
            {
               var tempOption =  options[Random.Range(0, options.Count)];
                if (tempOption.Selectable && !alreadySelected.Contains(tempOption))
                {
                    alreadySelected.Add(tempOption);
                    break;
                }
            }
        }

        return alreadySelected;


    }

    public void SelectOption(int n)
    {
        if(selectableOptions[n].isItem)
        {
            selectableOptions[n].passiveItem.LevelUp();
        }
        else
        {
            selectableOptions[n].colleague.LevelUp();
        }

        Time.timeScale = 1;
        SnakeHead.instance.animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        LevelupUI.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        CheckLevelUp();
        UpdateExpGage();



        if (Input.GetKeyDown(KeyCode.RightBracket))
            exp += expMax;
    }

    void CheckLevelUp()
    {
        if (Time.timeScale == 0)
            return;
        if (exp >= expMax)
        {
            LevelUp();
            expMax += expMax / 2;
        }
    }
    void UpdateExpGage()
    {
        expGage.localScale = new Vector3(exp/expMax, 1, 1);
    }
}
