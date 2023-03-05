using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawer : BodyClass
{
    bool active;
    bool prevActive;
    public GameObject saw;
    private void Awake()
    {
        snakeBody = GetComponent<SnakeBody>();
    }
    void Update()
    {
        active = snakeBody.activated;
        if(active != prevActive)
            saw.SetActive(active);
        prevActive = active;
    }



}
