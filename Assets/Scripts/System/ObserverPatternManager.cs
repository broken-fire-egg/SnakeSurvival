using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObserverPatternManager : MonoBehaviour
{
    public static ObserverPatternManager instance;

    public UnityEvent OnColleagueOrHeroHitUE;




    private void Awake()
    {
        instance = this;

        OnColleagueOrHeroDied = Dummy2;
        OnWallHit = Dummy1;
        OnEnemyContact = Dummy4;
        OnHealed = Dummy3;
        OnEnemyDied = Dummy1;
        OnGetEXP = Dummy3;
        OnColleagueOrHeroHit = Dummy5;
    }

    void Dummy1()
    {

    }
    void Dummy2(bool isbody = false, SnakeBody body = null)
    {

    }
    void Dummy3(float amount)
    {

    }
    void Dummy4(Enemy enemy)
    {

    }
    float Dummy5(bool isbody = false, BodyClass body = null, float amount = 0f)
    {
        return 0f;
    }
    public delegate void onColleagueOrHeroDied(bool isbody = false, SnakeBody body = null);
    public event onColleagueOrHeroDied OnColleagueOrHeroDied;

    public void ColleagueOrHeroDied(bool isbody = false, SnakeBody body = null)
    {
        OnColleagueOrHeroDied.Invoke(isbody,body);
    }


    public delegate void onWallHit();
    public event onWallHit OnWallHit;
    public void WallHit()
    {
        OnWallHit.Invoke();
    }


    public delegate void onEnemyContact(Enemy enemy);
    public event onEnemyContact OnEnemyContact;
    public void EnemyContact(Enemy enemy)
    {
        OnEnemyContact.Invoke(enemy);

    }

    public delegate void onEnemyDied();
    public event onEnemyDied OnEnemyDied;

    public void EnemyDied()
    {
        OnEnemyDied.Invoke();
    }



    public delegate void onHealed(float amount);
    public event onHealed OnHealed;

    public void Healed(float amount)
    {
        OnHealed.Invoke(amount);
        //서순형 함수로 구현예정?? 아님 말고??
    }



    public delegate float onColleagueOrHeroHit(bool isbody = false, BodyClass body = null, float amount = 0);
    public event onColleagueOrHeroHit OnColleagueOrHeroHit;

    public float ColleagueOrHeroHit(bool isbody = false, BodyClass body = null, float amount = 0)
    {
        return OnColleagueOrHeroHit.Invoke(isbody, body, amount);
        //서순형 함수로 구현예정?? 아님 말고??
    }



    public delegate void onGetEXP(float amount);
    public event onGetEXP OnGetEXP;

    public void GetEXP(float amount)
    {
        OnGetEXP.Invoke(amount);

        //서순형 함수로 구현예정?? 아님 말고??
    }
}
