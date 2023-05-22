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
    public void PauseWorldForCutscene()
    {
        Time.timeScale = 0f;
        StartCoroutine(ResumeWorld(5f));
    }
    public IEnumerator ResumeWorld(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1f;
    }



    public bool TryActivateSkill()
    {
        if (leftCoolTime > 0)
            return false;
        ActivateSkill();

        return true;
    }
    public virtual void ActivateSkill()
    {
        leftCoolTime = totalCoolTime;
    }
}
