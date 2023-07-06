using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    //TODO : GetmousebuttonDown to Touch
    Vector2 touchStartpos;

    public float sensitivity;
    float clicked = 0;
    float clicktime = 0;
    float clickdelay = 1f;
    public bool touching;
    private void Start()
    {
        touching = false;
    }
    private void Update()
    {
        if (Time.timeScale == 0)
            return;
        if (SnakeHead.instance)
        {
            CheckTouch();
            CheckTouchPos();
        }
    }


    void CheckTouch()
    {

#if UNITY_STANDALONE_WIN

        if (Input.GetMouseButtonDown(0))
        {
            clicked++;
            if (clicked == 1) clicktime = Time.time;

            if (clicked > 1 && Time.time - clicktime < clickdelay)
            {
                clicked = 0;
                clicktime = 0;
                print("double taped");
                Skill.Instance.TryActivateSkill();
                return;
            }
            else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;


            touching = true;
            touchStartpos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            touching = false;
        }

#endif

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).tapCount == 2)
            {
                print("double taped");
                Skill.Instance.TryActivateSkill();
                return;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                print("touch down");
                touching = true;
                touchStartpos = Input.GetTouch(0).position;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                print("touch up");
                touching = false;
            }
        }


    }
    void CheckTouchPos()
    {
        if (!touching) return;
        
        Vector2 gapPos = (Vector2)Input.mousePosition - touchStartpos;
        if (gapPos.x > sensitivity)
        {
            SnakeHead.instance.ChangeDirection(SnakeHead.Direction.right);
            clicked = 0;
            touching = false;
        }
        else if (gapPos.x < -sensitivity)
        {
            SnakeHead.instance.ChangeDirection(SnakeHead.Direction.left);
            clicked = 0;
            touching = false;
        }
        else if (gapPos.y > sensitivity)
        {
            SnakeHead.instance.ChangeDirection(SnakeHead.Direction.up);
            clicked = 0;
            touching = false;
        }
        else if (gapPos.y < -sensitivity)
        {
            SnakeHead.instance.ChangeDirection(SnakeHead.Direction.down);
            clicked = 0;
            touching = false;
        }


    }

}
