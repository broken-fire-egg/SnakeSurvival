using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof (SnakeBody))]
public abstract class BodyClass : MonoBehaviour
{
    protected SnakeBody snakeBody; 
    public GameObject bulletpref;

    public Sprite bodyIcon;

    public float damageMultiplier = 1;

    public float damageCoefficient;

    public float bonusDamage;
    public float damageAmount { get { return GameInfo.Instance.damageUnit * damageCoefficient / 100; } }
    public float damage { get { return (damageAmount + bonusDamage) * damageMultiplier; } }
    public float shoottime;
    public float cooltime;

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
        for (int i = 0; i < args.Length; i++)
            args[i] = "";
    }
    
    public abstract void SetBodyInfo(string discription, params object[] args);
    public abstract void LevelUp();
}
