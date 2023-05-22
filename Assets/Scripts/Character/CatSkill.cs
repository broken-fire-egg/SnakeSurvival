using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSkill : Skill
{
    public GameObject tresureChest;
    public enum SkillType { tresureChest, };
    public SkillType skillType;

    private void Start()
    {
        //PauseWorldForCutscene();
    }
    private void Update()
    {
    }

    public override void ActivateSkill()
    {
        base.ActivateSkill();
        switch (skillType)
        {
            case SkillType.tresureChest:
                TresureChest();
                break;
        }
    }

    void TresureChest()
    {
        Vector3 offset = Vector2.zero;
        int distance = 6;
        switch (CatHead.instance.dir)
        {
            case SnakeHead.Direction.right:
                offset = Vector2.right * distance;
                break;
            case SnakeHead.Direction.down:
                offset = Vector2.down * distance;
                break;
            case SnakeHead.Direction.left:
                offset = Vector2.left * distance;
                break;
            case SnakeHead.Direction.up:
                offset = Vector2.up * distance;
                break;
        }


        Instantiate(tresureChest, CatHead.instance.transform.position + offset, Quaternion.identity);
    }
}
