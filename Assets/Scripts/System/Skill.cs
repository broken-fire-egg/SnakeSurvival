using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : SingletonParent<Skill>
{
    public Image skillIcon;
    public Image cooltimeImage;
    public float leftCoolTime;
    public float totalCoolTime;
    // Update is called once per frame
    void Update()
    {

        leftCoolTime -= Time.deltaTime;
        if (leftCoolTime < 0)
            leftCoolTime = 0f;

        cooltimeImage.fillAmount = leftCoolTime / totalCoolTime;
    }
    public void PauseWorldForCutscene()
    {
        Time.timeScale = 0f;
        StartCoroutine(ResumeWorld(1f));
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
    protected virtual void ActivateSkill()
    {
        leftCoolTime = totalCoolTime;
    }
}
