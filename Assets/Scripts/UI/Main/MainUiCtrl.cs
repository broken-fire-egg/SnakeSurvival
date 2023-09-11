using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainUiCtrl : MonoBehaviour
{
    public GameObject Singleton;
    public GameObject MainGame;
    public GameObject OptionGame;
    public GameObject WorldGame;
    public GameObject CharacterGame;
    public GameObject BackgroundMoveGame;
    float time;

    public void Start()
    {   
    }
    public void Update()
    {
        time += Time.deltaTime;
        //BackgroundMoveGame.transform.position = new Vector2(BackgroundMoveGame.transform.position.x + 5, BackgroundMoveGame.transform.position.y + 8.55f);
        BackgroundMoveGame.transform.Translate(Vector2.up * 855f * Time.deltaTime);
        BackgroundMoveGame.transform.Translate(Vector2.right * 500 * Time.deltaTime);
        if (time >= 4.5f)
        {
            BackgroundMoveGame.transform.position = new Vector2(720, 1600);
            time = 0;
        }
    }
    public void a()
    {
        Singleton.GetComponent<test>().i++;
    }

    public void OptionButton()
    {
        OptionGame.SetActive(true);
        MainGame.SetActive(false);
    }

    public void WorldButton()
    {
        WorldGame.SetActive(true);
        MainGame.SetActive(false);
    }

    public void CharacterButton()
    {
        CharacterGame.SetActive(true);
        MainGame.SetActive(false);
    }

    public void ShopButton()
    {

    }

    public void FriendsButton()
    {

    }
    
    public void ToggleActive()
    {

    }
}
