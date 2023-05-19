using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public float leftCoolTime;
    public float totalCoolTime;
    // Update is called once per frame
    void Update()
    {
        leftCoolTime -= Time.deltaTime;
    }

    public virtual void ActivateSkill()
    {
        leftCoolTime = totalCoolTime;
    }
}
