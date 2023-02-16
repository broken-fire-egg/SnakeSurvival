using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Vector2 touchStartpos;

    public float sensitivity;
    public bool touching;
    private void Start()
    {
        touching = false;
    }
    private void Update()
    {
        CheckTouch();
        CheckTouchPos();
    }


    void CheckTouch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touching = true;
            touchStartpos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            touching = false;
            touchStartpos = Vector2.zero;
        }
    }
    void CheckTouchPos()
    { 
        if(!touching) return;

        Vector2 gapPos = (Vector2)Input.mousePosition - touchStartpos;
        if (gapPos.x > sensitivity)
        {
            SnakeHead.instance.ChangeDirection(SnakeHead.Direction.right);
            touching = false;
        }
        else if (gapPos.x < -sensitivity)
        {
            SnakeHead.instance.ChangeDirection(SnakeHead.Direction.left);
            touching = false;
        }
        else if (gapPos.y > sensitivity)
        {
            SnakeHead.instance.ChangeDirection(SnakeHead.Direction.up);
            touching = false;
        }
        else if (gapPos.y < -sensitivity)
        {
            SnakeHead.instance.ChangeDirection(SnakeHead.Direction.down);
            touching = false;
        }
        
        
    }

}
