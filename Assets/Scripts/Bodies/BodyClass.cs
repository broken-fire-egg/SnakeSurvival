using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof (SnakeBody))]
public abstract class BodyClass : MonoBehaviour
{
    public SnakeBody snakeBody; 
    public GameObject bulletpref;

    public Sprite bodyIcon;

    public MultipleMultiplierValue damageMultiplier;
    
    public float damageCoefficient;

    public DebuffList debuffList;

    public float bonusCriticalChance;
    public float bonusDamage;   //기본 대미지
    public float damageAmount { get { return GameInfo.Instance.damageUnit * damageCoefficient / 100; } }
    public float damage { get { return (damageAmount + bonusDamage) * damageMultiplier; } }
    public MultipleMultiplierValue shoottime;
    public float cooltime;
    public float cooltimeMultiplier = 1f;
    public int level;

    public string bodyName;
    public string bodyDescription;

    //TODO : Remove this old variable
    public string[] args;
    public string levelupDescription;

    public void Hit(float amount)
    {

        snakeBody.Hit(amount);
    }
    public virtual void PlayHitEffect(GameObject enemy)
    {

    }
    public IEnumerator DamageBuff(float amount)
    {
        yield return null;
    }
    protected virtual void Start()
    {
        snakeBody = GetComponent<SnakeBody>();
        args = new string[3];
        shoottime = new MultipleMultiplierValue();
        damageMultiplier = new MultipleMultiplierValue();

        for (int i = 0; i < args.Length; i++)
            args[i] = "";
    }
    public abstract void UpdateDamageInfo(); //자신의 무기에 대미지 수정
    public abstract void Activate();
    public abstract void SetBodyInfo(string discription, params object[] args);
    public abstract void LevelUp();



    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
