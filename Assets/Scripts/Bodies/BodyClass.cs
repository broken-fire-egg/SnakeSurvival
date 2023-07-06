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
    public float bonusDamage;
    float damageAmount = 1;
    public float damage { get { return (damageAmount + bonusDamage) * damageMultiplier; }set { damageAmount = value; } }
    public float shoottime;
    public float cooltime;

    public int level;

    public string bodyName;
    public string bodyDescription;
    public string[] args;
    public string levelupDescription;

    public void Hit(float amount)
    {

        snakeBody.Hit(amount);
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
