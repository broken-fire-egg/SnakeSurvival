using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventCollection : MonoBehaviour
{
    Bullet bullet;
    private void Start()
    {
        if(!TryGetComponent<Bullet>(out bullet))
        {
            if(transform.childCount != 0)
                transform.GetChild(0).TryGetComponent<Bullet>(out bullet);
        }
    }

    public void DisableChild(int i)
    {
        transform.GetChild(i).gameObject.SetActive(false);
    }
    public void EnableChild(int i)
    {
        transform.GetChild(i).gameObject.SetActive(true);
    }
    public void Disable()
    {
        gameObject.SetActive(false);
    }
    public void EnableSibling(int targetNumber)
    {
        transform.parent.GetChild(targetNumber).gameObject.SetActive(true);
    }

    public void BulletPhysicSimulate()
    {
        if (bullet)
            bullet.PhysicsSimulate();
    }
}
